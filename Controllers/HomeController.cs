using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HLAN.Models;
using Microsoft.AspNetCore.Authorization;
using System.Text.Json;
using HLAN.Models.EF;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace HLAN.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<KluboviController> _logger;
        private readonly HLANContext _context;
        public HomeController(HLANContext context, ILogger<KluboviController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        [HttpGet]
        public IActionResult Rankings()
        {
            var utakmice = _context.Utakmice.Include(item => item.Sezona)
                                        .Where(item => item.Sezona.Godina == DateTime.Now.Year.ToString())
                                        .ToList();

            var klubovi = _context.Klubovi.ToList();

            List<RankingsModel> rankings = new List<RankingsModel>();

            foreach (var klub in klubovi)
            {
                int P = utakmice.Where(item =>
                                        (item.Domaci.Id == klub.Id || item.Gosti.Id == klub.Id)
                                       ).Count();

                int W = utakmice.Where(item =>
                                        (item.Domaci.Id == klub.Id && item.RezDomaci > item.RezGosti) ||
                                        (item.Gosti.Id == klub.Id && item.RezDomaci < item.RezGosti)
                                       ).Count();
                int L = P - W;
                int Pts = W * 3;
                var data = new RankingsModel
                {
                    Klub = klub.Naziv,
                    P = P,
                    W = W,
                    L = L,
                    Pts = Pts
                };
                rankings.Add(data);
            }

            rankings = rankings.OrderByDescending(item => item.Pts).ToList();
            int i = 0;
            foreach (var item in rankings)
            {
                i++;
                item.Br = i;
            }

            var modelJson = JsonSerializer.Serialize(rankings);

            return Json(new { rankings });
        }

        [HttpGet]
        public IActionResult NextMaches()
        {
            DateTimeFormatInfo fmt = (new CultureInfo("hr-HR")).DateTimeFormat;

            var utakmiceNeodigrane = _context.Utakmice.Include(item => item.Sezona)
                                                    .Where(item => item.Sezona.Godina == DateTime.Now.Year.ToString())
                                                    .Where(item => item.RezDomaci == null || item.RezGosti == null)
                                                    .Include(item => item.Domaci)
                                                    .Include(item => item.Gosti)
                                                    .Select(item => new NextGame { 
                                                        Domaci = item.Domaci.Naziv,
                                                        Gosti = item.Gosti.Naziv,
                                                        Datum = item.Datum.ToString("d", fmt)
                                                    })
                                                    .ToList();



            var matches = JsonSerializer.Serialize(utakmiceNeodigrane);

            return Json(new { matches });
        }


        public IActionResult LatestResults()
        {
            DateTimeFormatInfo fmt = (new CultureInfo("hr-HR")).DateTimeFormat;

            var utakmiceOdigrane = _context.Utakmice.Include(item => item.Sezona)
                                                    .Where(item => item.Sezona.Godina == DateTime.Now.Year.ToString())
                                                    .Where(item => item.RezDomaci != null || item.RezGosti != null)
                                                    .Include(item => item.Domaci)
                                                    .Include(item => item.Gosti)
                                                    .Select(item => new MatchResult
                                                    {
                                                        Domaci = item.Domaci.Naziv,
                                                        RezDomaci = item.RezDomaci.Value,
                                                        RezGosti = item.RezGosti.Value,
                                                        Gosti = item.Gosti.Naziv,
                                                        Datum = item.Datum.ToString("d", fmt)
                                                    })
                                                    .Take(3)
                                                    .ToList();



            var matches = JsonSerializer.Serialize(utakmiceOdigrane);

            return Json(new { matches });
        }

    }
}
