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

namespace HLAN.Controllers
{
    public class KluboviController : Controller
    {
        private readonly ILogger<KluboviController> _logger;
        private readonly HLANContext _context;
        public KluboviController(HLANContext context, ILogger<KluboviController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var klubovi = await _context.Klubovi.ToListAsync();

            return View(klubovi);
        }
        
        public async Task<IActionResult> Create(Klub klub)
        {
            if (klub.Naziv == null)
            {
                return View();
            }
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
            klubStari.Logo = klubNovi.Logo;
            klubStari.Naziv = klubNovi.Naziv;
            klubStari.Skracenica = klubNovi.Skracenica;

            var tesksk = _context.Klubovi.Update(klubStari);
            var test = await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}