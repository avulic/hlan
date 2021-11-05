using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;

using System.Threading.Tasks;
using HLAN.Models;
using HLAN.Models.EF;
using HLAN.Models.Entitie;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit.Encodings;
using Newtonsoft.Json;
using SQLitePCL;

namespace HLAN.Controllers
{
    public class IgraciController : Controller
    {
        private HLANContext _context;
        private SignInManager<User> _siginManager;
        private UserManager<User> _usernManager;
        private ILookupNormalizer _normalizer;
        private IWebHostEnvironment _webHostEnvironment;
        public IgraciController(HLANContext context, SignInManager<User> siginManager, UserManager<User> usernManager, ILookupNormalizer normalizer, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _siginManager = siginManager;
            _usernManager = usernManager;
            _normalizer = normalizer;
            _webHostEnvironment = hostEnvironment;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string sortOrder, string searchString, string uloga)
        {
            ViewData["CurrentSort"] = sortOrder;
            uloga = !String.IsNullOrEmpty(uloga) ? uloga : "Igrac";
            ViewData["Uloga"] = !String.IsNullOrEmpty(uloga) ? uloga : "";

            ViewData["CurrentFilter"] = searchString;

            var igraci = await _usernManager.GetUsersInRoleAsync(uloga);
            if (igraci.Count == 0)
            {
                return View();
            }

            List<Igrac> igraciList= new List<Igrac>();
            foreach (var item in igraci)
            {
                var igrac = new Igrac
                {
                    Id = item.Id,
                    Ime = item.Ime,
                    Prezime = item.Prezime,
                    Broj = item.Broj,
                    Klub = _context.Klubovi.FirstOrDefault(klub => klub.Id == item.KlubId)?.Naziv,
                    Pozicija = item.Pozicija,
                    Profilna = item.Profilna
                };
                igraciList.Add(igrac);
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                igraciList = igraciList.Where(igrac => igrac.Klub == searchString).ToList();
            }

            var igraciList1 = igraciList.GroupBy(igrac => igrac.Klub);

            return View(igraciList1);
        }
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(User igrac)
        {
            if (igrac.Ime == null)
            {
                return NotFound();
            }

            igrac.Profilna = UploadedFile(igrac);


            IdentityResult result = null;
            if (!_context.Users.Any(u => u.UserName == igrac.UserName))
            { 
                var userStore = new UserStore<User>(_context);
                igrac.EmailConfirmed = true;
                var password = new PasswordHasher<User>();
                var hashed = password.HashPassword(igrac, igrac.Password);
                igrac.PasswordHash = hashed;
                result = await userStore.CreateAsync(igrac);
            }
            
            var result1 = await _usernManager.AddToRolesAsync(igrac, igrac.Uloge);
            ViewData["Error"] = result1.Errors.ToList();
            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DetailsAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var igrac = await _usernManager.FindByIdAsync(id);
            
            var klub = await _context.Klubovi.FirstOrDefaultAsync(klub => klub.Id == igrac.KlubId);
            igrac.Klub = klub;
            var options = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            var details = JsonConvert.SerializeObject(igrac,options);

            return Json(new { details });
        }

        public async Task<IActionResult> EditAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var igrac = await _usernManager.FindByIdAsync(id);
            if (igrac == null)
            {
                return NotFound();
            }

            igrac.Klub = _context.Klubovi.FirstOrDefault(klub => klub.Id == igrac.KlubId);

            return View(igrac);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind]User user)
        {
            if (user.Ime == null)
            {
                return NotFound();
            }


            var userOld = await _usernManager.FindByIdAsync(user.Id);
            var uloge = await _usernManager.GetRolesAsync(user);
            userOld.Ime = user.Ime;
            userOld.Prezime = user.Prezime;
            userOld.UserName = user.UserName;
            userOld.Email = user.Email;
            userOld.OIB = user.OIB;
            userOld.PhoneNumber = user.PhoneNumber;
            userOld.Platio_clanarinu = user.Platio_clanarinu;
            userOld.KlubId = user.Klub.Id;
            userOld.Pozicija = user.Pozicija;
            userOld.Broj = user.Broj;
            userOld.Uloge = user.Uloge;
            if (user.Slika != null)
            {
                userOld.Profilna = UploadedFile(user);
            }

            var result = await _usernManager.RemoveFromRolesAsync(userOld, uloge);

            result = await _usernManager.AddToRolesAsync(userOld, userOld.Uloge);

            var resutl = await _usernManager.UpdateAsync(userOld);
            

            return RedirectToAction(nameof(Index));
        
        }

        private string UploadedFile(User model)
        {
            string uniqueFileName = null;

            if (model.Slika != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "img");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Slika.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Slika.CopyTo(fileStream);
                }
                return uniqueFileName.ToString();

            }
            return "";

        }

    }
}