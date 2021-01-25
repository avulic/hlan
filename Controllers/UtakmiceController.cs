using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HLAN.Models.EF;
using HLAN.Models.Entitie;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.Language.Extensions;
using Microsoft.EntityFrameworkCore;

namespace HLAN.Controllers
{
    public class UtakmiceController : Controller
    {
        private HLANContext _context;
        private UserManager<User> _usernManager;
        public UtakmiceController(HLANContext context, UserManager<User> usernManager)
        {
            _context = context;
            _usernManager = usernManager;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var utakmice = await _context.Utakmice
                                    .Include(u => u.Domaci)
                                    .Include(u => u.Gosti)
                                    .Include(u => u.Sezona)
                                    .Include(u => u.Kolo)
                                    .ToListAsync();
            return View(utakmice);
        }
        public async Task<IActionResult> GetBySeasonAsync(String godina)
        {
            var utakmice = await _context.Utakmice.Include(item => item.Sezona)
                                                .Where(item => item.Sezona.Godina == godina)
                                                .ToListAsync();
            return View(utakmice);
        }
        public async Task<IActionResult> EditAsync(Utakmica utakmica)
        {
            var utakmicaOld = await _context.Utakmice.FirstOrDefaultAsync(item => item.Id == utakmica.Id);
            utakmicaOld.Datum = utakmica.Datum;
            utakmicaOld.Kolo = utakmica.Kolo;
            utakmicaOld.Sezona = utakmica.Sezona;
            utakmicaOld.Domaci = utakmica.Domaci;
            utakmicaOld.Gosti = utakmica.Gosti;
            utakmicaOld.RezDomaci = utakmica.RezDomaci;
            utakmicaOld.RezGosti = utakmica.RezGosti;

            await _context.Utakmice.AddAsync(utakmica);
            await _context.SaveChangesAsync();

            return View();
        }
        public async Task<IActionResult> CreateAsync(Utakmica utakmica)
        {
            var klubovi = await _context.Klubovi.ToListAsync();
            var sezone = await _context.Sezone.ToListAsync();
            var kola = await _context.Kola.ToListAsync();

            ViewBag.Klubovi = new SelectList(klubovi, "Id", "Naziv");
            ViewBag.Sezone = new SelectList(sezone, "Id", "Godina");
            ViewBag.Kola = new SelectList(kola, "Id", "Br");

            if (utakmica.Gosti == null || utakmica.Domaci == null)
            {
                return View();
            }

            if (utakmica.Domaci.Id == utakmica.Gosti.Id)
            {
                ViewData["Error"] = "Gost i domačin morau biti različiti";
                return View();
            }
            
            utakmica.Domaci = klubovi.FirstOrDefault(k => k.Id == utakmica.Domaci.Id);
            utakmica.Gosti = klubovi.FirstOrDefault(k => k.Id == utakmica.Gosti.Id);
            utakmica.Sezona = sezone.FirstOrDefault(s => s.Id == utakmica.Sezona.Id);
            utakmica.Kolo = kola.FirstOrDefault(k => k.Id == utakmica.Kolo.Id);

            await _context.Utakmice.AddAsync(utakmica);
            await _context.SaveChangesAsync();

            return View("Index");
        }
        public async Task<IActionResult> DetailsAsync(int id)
        {
            var utakmica =  await _context.Utakmice.FirstOrDefaultAsync(item => item.Id == id);

            return View(utakmica);
        }


    }
}