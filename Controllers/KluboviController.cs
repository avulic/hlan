using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HLAN.Models;
using HLAN.Models.EF;
using HLAN.Models.Entitie;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HLAN.Controllers
{
    public class KluboviController : Controller
    {
        private readonly ILogger<KluboviController> _logger;
        private readonly HLANContext _context;
        private IWebHostEnvironment _webHostEnvironment;
        private UserManager<User> _usernManager;
        public KluboviController(HLANContext context, ILogger<KluboviController> logger, IWebHostEnvironment hostEnvironment, UserManager<User> usernManager)
        {
            _context = context;
            _logger = logger;
            _webHostEnvironment = hostEnvironment;
            _usernManager = usernManager;
        }

        public async Task<IActionResult> Index()
        {
            var klubovi = await _context.Klubovi.ToListAsync();

            return View(klubovi);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {

            var users = await _usernManager.GetUsersInRoleAsync("Igrac");

            ViewBag.Igraci = new SelectList(users, "Id", "PunoIme");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(Klub klub)
        {
            if (klub.Naziv == null)
            {
                return View();
            }
            klub.Logo = UploadedFile(klub);

            await _context.Klubovi.AddAsync(klub);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klub = await _context.Klubovi.FirstOrDefaultAsync(klub => klub.Id == id);

            return View(klub);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klub = await _context.Klubovi.FirstOrDefaultAsync(klub => klub.Id == id);
            _context.Klubovi.Remove(klub);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klubStari = await _context.Klubovi.FirstOrDefaultAsync(klub => klub.Id == id);
            return View(klubStari);
        }
        [HttpPost]
        public async Task<IActionResult> EditAsync(Klub klubNovi)
        {
            if (klubNovi.Naziv == null)
            {
                return NotFound();
            }

            var klubStari = await _context.Klubovi.FirstOrDefaultAsync(klub => klub.Id == klubNovi.Id);
            var tesksk = _context.Klubovi.Update(klubStari);
            klubStari.Naziv = klubNovi.Naziv;
            klubStari.Skracenica = klubNovi.Skracenica;
            if (klubNovi.Slika != null)
            {
                klubStari.Logo = UploadedFile(klubNovi);
            }

            var test = await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        private string UploadedFile(Klub model)
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