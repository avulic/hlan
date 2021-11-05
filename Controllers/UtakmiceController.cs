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

        [HttpGet]
        public async Task<IActionResult> Edit(Utakmica utakmica)
        {
            var utakmicaOld = await _context.Utakmice.Include(elem => elem.Domaci)
                .Include(ele => ele.Gosti)
                .Include(ele => ele.Sezona)
                .Include(ele => ele.Kolo)
                .FirstOrDefaultAsync(item => item.Id == utakmica.Id);


            return View(utakmicaOld);
        }
        
        [HttpPost]
        public async Task<IActionResult> EditAsync(Utakmica utakmica)
        {
            var utakmicaOld = await _context.Utakmice.Include(utak => utak.Domaci).Include(utak => utak.Gosti).FirstOrDefaultAsync(item => item.Id == utakmica.Id);
            var klubovi = await _context.Klubovi.ToListAsync();
            var sezone = await _context.Sezone.ToListAsync();
            var kola = await _context.Kola.ToListAsync();
            _context.Utakmice.Update(utakmicaOld);

            utakmicaOld.Datum = utakmica.Datum;
            utakmicaOld.KoloId = kola.FirstOrDefault(kol => kol.Br == utakmica.Kolo.Br).Id;
            utakmicaOld.SezonaId = sezone.FirstOrDefault(sez => sez.Godina == utakmica.Sezona.Godina).Id;
            utakmicaOld.DomaciId = klubovi.FirstOrDefault(klub => klub.Naziv == utakmica.Domaci.Naziv).Id;
            utakmicaOld.GostiId = klubovi.FirstOrDefault(klub => klub.Naziv == utakmica.Gosti.Naziv).Id;
            utakmicaOld.RezDomaci = utakmica.RezDomaci;
            utakmicaOld.RezGosti = utakmica.RezGosti;
            
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateAsync(Utakmica utakmica)
        {
            if (!ModelState.IsValid)
            { 
                return View(utakmica);
            }


            if (utakmica.DomaciId == utakmica.GostiId)
            {
                ViewData["Error"] = "Gost i domačin morau biti različiti";
                return View();
            }      

            await _context.Utakmice.AddAsync(utakmica);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public async Task<IActionResult> DetailsAsync(int id)
        {
            var utakmica =  await _context.Utakmice.FirstOrDefaultAsync(item => item.Id == id);

            return View(utakmica);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utakmica = await _context.Utakmice.FirstOrDefaultAsync(utak => utak.Id == id);
            _context.Utakmice.Remove(utakmica);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}