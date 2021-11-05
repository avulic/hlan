using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HLAN.Models.EF;
using HLAN.Models.Entitie;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HLAN.Controllers
{
   [Authorize]
    public class UpisniceController : Controller
    {
        private HLANContext _context;
        private UserManager<User> _usernManager;
        private IWebHostEnvironment _webHostEnvironment;
        public UpisniceController(HLANContext context, UserManager<User> usernManager, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _usernManager = usernManager;
            _webHostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole("Admin"))
            {
                var upisnice = await _context.Upisnice.Include(upisnica => upisnica.User).ToListAsync<Upisnica>();

                return View(upisnice.ToArray().Split(4));
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var upisnica = await _context.Upisnice.FirstOrDefaultAsync(item => item.UserId == userId);

            return RedirectToAction("Details", upisnica?.Id);
        }
   
        public async Task<IActionResult> CreateAsync(Upisnica upisnica)
        {
            if (upisnica.User == null)
            {
                return View();
            }

            var user = await _usernManager.GetUserAsync(User);

            user.Ime = upisnica.User.Ime;
            user.Prezime = upisnica.User.Prezime;
            user.OIB = upisnica.User.OIB;
            user.PhoneNumber = upisnica.User.PhoneNumber;
            user.Adresa = upisnica.User.Adresa;
            user.Email = upisnica.User.Email;
            user.KlubId = upisnica.User.Klub.Id;
            user.Profilna = UploadedFile(upisnica.User);

            var resul = await _usernManager.UpdateAsync(user);

            upisnica.User = user;
            await _context.Upisnice.AddAsync(upisnica);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
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
            }
            return uniqueFileName.ToString();
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Create");
            }

            var upisnica = await _context.Upisnice.Include(upisnica => upisnica.User).FirstOrDefaultAsync(upisnica => upisnica.Id == id);

            return View(upisnica);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var upisnicaStara = await _context.Upisnice.Include(item => item.User).FirstOrDefaultAsync(upisnica => upisnica.Id == id);

            return View(upisnicaStara);
        }
        
        [HttpPost]
        public async Task<IActionResult> EditAsync([Bind]Upisnica upisnicaStara)
        {
            if (upisnicaStara == null)
            {
                return NotFound();
            }
            
            _context.Attach(upisnicaStara);
            await _context.SaveChangesAsync();

            return View("Index");  
        }
        
        [Authorize(Roles = "Trener")]
        public async Task<IActionResult> Odbij(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var upisnica = await _context.Upisnice.FirstOrDefaultAsync(upisnica => upisnica.Id == id);
            upisnica.Potvrdena = false;

            _context.Upisnice.Update(upisnica);
            await _context.SaveChangesAsync();

            return View("Index");
        }

        [Authorize(Roles = "Trener")]
        public async Task<IActionResult> Prihvati(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var upisnica = await _context.Upisnice.FirstOrDefaultAsync(upisnica => upisnica.Id == id);
            upisnica.Potvrdena = true;

            User user = await _usernManager.FindByIdAsync(upisnica.UserId);
            await _usernManager.AddToRoleAsync(user, "Igrac");
            
            _context.Upisnice.Update(upisnica);
            await _context.SaveChangesAsync();

            return View("Index");
        }

        
        [HttpGet]
        public async Task<IActionResult> DeleteAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var upisnicaStara = await _context.Upisnice.FirstOrDefaultAsync(upisnica => upisnica.Id == id);

            _context.Remove(upisnicaStara);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}

public static class ArrayExtensions
{
    public static IEnumerable<IEnumerable<T>> Split<T>(this T[] array, int size)
    {
        for (var i = 0; i < Math.Ceiling((float)array.Length / size); i++)
        {
            yield return array.Skip(i * size).Take(size);
        }
    }
}