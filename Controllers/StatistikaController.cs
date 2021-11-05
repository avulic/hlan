using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using HLAN.Models;
using HLAN.Models.EF;
using HLAN.Models.Entitie;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;

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
            var statistikaIgraci = (from c in _context.StatistikaIgraca
                                    join a in _context.Users on c.UserId equals a.Id
                                    group c by new { c.UserId } into g
                                    select new StatistikaIgraca
                                    {
                                        UserId = g.Key.UserId,
                                        Marks = g.Sum(n => n.Marks),
                                        Goals = g.Sum(n => n.Goals),
                                        Hitouts = g.Sum(n => n.Hitouts),
                                        Tackles = g.Sum(n => n.Tackles),
                                        Disposals = g.Sum(n => n.Disposals),
                                        Spoils = g.Sum(n => n.Spoils),
                                        Behinds = g.Sum(n => n.Behinds)
                                    }).ToList();

            foreach (var item in statistikaIgraci)
            {
                item.User = await _usernManager.FindByIdAsync(item.UserId);
            }

            ViewBag.Utakmice = _context.Utakmice
                .Include(utakmice => utakmice.Sezona)
                .Include(utakmice => utakmice.Kolo)
                .Include(utakmice => utakmice.Domaci)
                .Include(utakmice => utakmice.Gosti)
                .ToList();

            var data = new StatistikaModel
            {
                StatistikaIgraca = statistikaIgraci
            };

            return View("Igraci/Igraci", data);
        }

        //public async Task<IActionResult> Utakmice()
        //{
        //    var statistikaUtakmica = await _context.StatistikaUtakmica.ToListAsync();
        //    return View("Statistika\\Igraci", statistikaIgraci);
        //}

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(StatistikaIgraca statistikaIgraca)
        {
            var statistikaIgracaOld = await _context.StatistikaIgraca.FirstOrDefaultAsync(item => item.Id == statistikaIgraca.Id);

            if (await TryUpdateModelAsync(statistikaIgracaOld))
            {
                try
                {
                    _context.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException )
                {
                    
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            
            return View();
        }


        [HttpPost, ActionName("Create")]
        public async Task<IActionResult> CreateAsync(StatistikaModel data)
        {
            await _context.StatistikaIgraca.AddAsync(data.Statistika);
            await _context.SaveChangesAsync();

            return RedirectToAction("Igraci");
        }


        [HttpPost]
        public async Task<IActionResult> Utakmice(string igracId)
        {
            var igrac = await _usernManager.Users
                                .Include(user => user.Klub)
                                .Where(user => user.Id == igracId)
                                .FirstOrDefaultAsync();

            var utakmice = await _context.Utakmice
                                .Include(utak => utak.Domaci)
                                .Include(utak => utak.Gosti)
                                .Include(utak => utak.Kolo)
                                .Include(utak => utak.Sezona)
                                .Where(utakmice => (utakmice.DomaciId == igrac.KlubId || utakmice.GostiId == igrac.KlubId) && utakmice.RezGosti != null && utakmice.RezDomaci != null)
                                .Select(utakmica => new { 
                                    utakmica.Id, 
                                    utakmica.Naziv 
                                })
                                .ToListAsync();

            var utakmiceJson = Newtonsoft.Json.JsonConvert.SerializeObject(utakmice, Formatting.Indented);

            return Json(new { utakmiceJson });
        }

        [HttpPost]
        public async Task<IActionResult> ChartAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var statitika = await _context.StatistikaIgraca
                                    .OrderBy(stat => stat.UserId)
                                    .ThenBy(stat => stat.UtakmicaId)
                                    .Where(stat => stat.UserId == id)
                                    .Include(stat => stat.Utakmica)
                                    .ToListAsync();

            var grop = statitika.GroupBy(stat => new { 
                stat.UserId, stat.Utakmica
            }).ToList();


            var nada = grop.Select(a => new {
                UserId = a.Key.UserId,
                Utakmica = a.Key.Utakmica,
                Disposals = a.Sum(b => b.Disposals),
                Marks = a.Sum(b => b.Marks),
                Behinds = a.Sum(b => b.Behinds),
                Goals = a.Sum(b => b.Goals),
                Tackles = a.Sum(b => b.Tackles)
            }).ToList();

            int totalD = 0, totalM = 0, totalB = 0, totalG = 0, totalT = 0;
            var das = nada.Select(a => new { 
                                        user = a.UserId, 
                                        utak = a.Utakmica.Datum, 
                                        cumDis = totalD += a.Disposals,
                                        cumMar = totalM += a.Marks,
                                        cumBeh = totalB += a.Behinds,
                                        cumGoa = totalG += a.Goals,
                                        cumTack = totalT += a.Tackles
                                    }).ToList();

            Dictionary<string,List<DataPoint>> data = new Dictionary<string, List<DataPoint>>()
                                                            { 
                                                                { "Disposals", new List<DataPoint>() },
                                                                { "Marks", new List<DataPoint>() },
                                                                { "Behinds", new List<DataPoint>() },
                                                                { "Goals", new List<DataPoint>() },
                                                                { "Tackles", new List<DataPoint>() }
                                                            };

            foreach (var item in das)
            {
                data["Disposals"].Add(new DataPoint(item.utak.ToOADate(), item.cumDis));
                data["Marks"].Add(new DataPoint(item.utak.ToOADate(), item.cumMar));
                data["Behinds"].Add(new DataPoint(item.utak.ToOADate(), item.cumBeh));
                data["Goals"].Add(new DataPoint(item.utak.ToOADate(), item.cumGoa));
                data["Tackles"].Add(new DataPoint(item.utak.ToOADate(), item.cumTack));
            }


            JsonSerializerSettings _jsonSetting = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            };
            var dataSerialized = JsonConvert.SerializeObject(data, _jsonSetting);

            var modelJson = System.Text.Json.JsonSerializer.Serialize(data.ToArray());

            return Json(modelJson);
        }
    }
}