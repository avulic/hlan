using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HLAN.Models;
using HLAN.Models.EF;
using HLAN.Models.Entitie;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HLAN.Controllers
{
    public class StatistikaController : Controller
    {
        private HLANContext _context;
        private UserManager<User> _usernManager;
        public StatistikaController(HLANContext context, UserManager<User> usernManager)
        {
            _context = context;
            _usernManager = usernManager;
        }

        public async Task<IActionResult> Igraci()
        {
            var statistikaIgraci = await _context.StatistikaIgraca.ToListAsync();
            return View("Statistika\\Igraci", statistikaIgraci);
        }

        //public async Task<IActionResult> Utakmice()
        //{
        //    var statistikaUtakmica = await _context.StatistikaUtakmica.ToListAsync();
        //    return View("Statistika\\Igraci", statistikaIgraci);
        //}

        public async Task<IActionResult> Klubovi()
        {
            var statistikaKlubovi = await _context.StatistikaKluba.ToListAsync();
            return View("Statistika\\Igraci", statistikaKlubovi);
        }

        public async Task<IActionResult> EditIgraciAsync(StatistikaIgraca statistikaIgraca)
        {
            var statistikaIgracaOld = await _context.StatistikaIgraca.FirstOrDefaultAsync(item => item.Id == statistikaIgraca.Id);
            statistikaIgracaOld.Disposals = statistikaIgraca.Disposals;
            statistikaIgracaOld.Behinds = statistikaIgraca.Behinds;
            statistikaIgracaOld.Goals = statistikaIgraca.Goals;
            statistikaIgracaOld.Hitouts = statistikaIgraca.Hitouts;
            statistikaIgracaOld.Marks = statistikaIgraca.Marks;
            statistikaIgracaOld.Spoils = statistikaIgraca.Spoils;
            statistikaIgracaOld.Tackles = statistikaIgraca.Tackles;

            _context.StatistikaIgraca.Update(statistikaIgracaOld);
            await _context.SaveChangesAsync();

            return View();
        }

        public async Task<IActionResult> EditKluboviAsync(StatistikaKluba statistikaKluba)
        {
            var statistikaKlubaOld = await _context.StatistikaKluba.FirstOrDefaultAsync(item => item.Id == statistikaKluba.Id);
            statistikaKlubaOld.Disposals = statistikaKluba.Disposals;
            statistikaKlubaOld.Behinds = statistikaKluba.Behinds;
            statistikaKlubaOld.Goals = statistikaKluba.Goals;
            statistikaKlubaOld.Hitouts = statistikaKluba.Hitouts;
            statistikaKlubaOld.Marks = statistikaKluba.Marks;
            statistikaKlubaOld.Spoils = statistikaKluba.Spoils;
            statistikaKlubaOld.Tackles = statistikaKluba.Tackles;
            
            _context.StatistikaKluba.Update(statistikaKlubaOld);
            await _context.SaveChangesAsync();

            return View();
        }

        public async Task<IActionResult> CreateKluboviAsync(StatistikaKluba statistikaKluba)
        {
            await _context.StatistikaKluba.AddAsync(statistikaKluba);
            await _context.SaveChangesAsync();

            return View();
        }

        public async Task<IActionResult> CreateIgraciAsync(StatistikaIgraca statistikaIgraca)
        { 
            await _context.StatistikaIgraca.AddAsync(statistikaIgraca);
            await _context.SaveChangesAsync();

            return View();
        }

        public async Task<IActionResult> HistoricalAsync(int id)
        {
            var utakmica = await _context.Utakmice.FirstOrDefaultAsync(item => item.Id == id);

            return View(utakmica);
        }
    }
}