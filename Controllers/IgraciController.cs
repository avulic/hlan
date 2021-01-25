using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

using System.Threading.Tasks;
using HLAN.Models;
using HLAN.Models.EF;
using HLAN.Models.Entitie;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IgraciController(HLANContext context, SignInManager<User> siginManager, UserManager<User> usernManager, ILookupNormalizer normalizer)
        {
            _context = context;
            _siginManager = siginManager;
            _usernManager = usernManager;
            _normalizer = normalizer;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            ViewData["CurrentFilter"] = searchString;

            var igraci = await _usernManager.GetUsersInRoleAsync("Igrac");
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
                    Pozicija = item.Pozicija
                };
                igraciList.Add(igrac);
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                igraciList = igraciList.Where(igrac => igrac.Klub == searchString).ToList();
            }
            
            switch (sortOrder)
            {
                case "Ime_desc":
                    igraciList = igraciList.OrderByDescending(igrac => igrac.Ime).ToList();
                    break;
                case "Prezime_desc":
                    igraciList = igraciList.OrderBy(s => s.Prezime).ToList();
                    break;
                case "Broj_desc":
                    igraciList = igraciList.OrderByDescending(s => s.Broj).ToList();
                    break;
                case "Klub_desc":
                    igraciList = igraciList.OrderByDescending(s => s.Broj).ToList();
                    break;
                default:
                    igraciList = igraciList.OrderBy(igrac => igrac.Ime).ToList();
                    break;
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
            var normalizer = _normalizer;
            var userManager = _usernManager;

            IdentityResult result = null;
            if (!_context.Users.Any(u => u.UserName == igrac.UserName))
            { 

                var userStore = new UserStore<User>(_context);
                igrac.EmailConfirmed = true;
                var password = new PasswordHasher<User>();
                var hashed = password.HashPassword(igrac, igrac.PasswordHash);
                igrac.PasswordHash = hashed;
                result = await userStore.CreateAsync(igrac);
            }

            //AssignRoles(service, user.Email, "Admin");
            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DetailsAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return View("Create");
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
            
            igrac.Klub = _context.Klubovi.FirstOrDefault(klub => klub.Id == igrac.KlubId);
            if (igrac == null)
            {
                return NotFound();
            }
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

            if (ModelState.IsValid)
            {
                try
                {
                    var userOld = await _usernManager.FindByIdAsync(user.Id);

                    userOld.Ime = user.Ime;
                    userOld.Prezime = user.Prezime;
                    userOld.UserName = user.UserName;
                    userOld.Email = user.Email;
                    userOld.OIB = user.OIB;
                    userOld.PhoneNumber = user.PhoneNumber;
                    userOld.Platio_clanarinu = user.Platio_clanarinu;
                    userOld.KlubId = userOld.KlubId;
                    userOld.Pozicija = user.Pozicija;
                    userOld.Broj = user.Broj;
                    userOld.Slika = user.Slika;
                    var resutl = await _usernManager.UpdateAsync(userOld);
                }
                catch (DbUpdateConcurrencyException)
                {
                    
                    throw;
                    
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }
    }
}