using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HLAN.Models.EF;
using HLAN.Models.Entitie;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HLAN.Controllers
{
   
    public class UpisniceController : Controller
    {
        private HLANContext _context;
        private UserManager<User> _usernManager;
        public UpisniceController(HLANContext context, UserManager<User> usernManager)
        {
            _context = context;
            _usernManager = usernManager;
        }

        public async Task<IActionResult> Index()
        {
            if (User.IsInRole("Admin"))
            {
                var upisnice = await _context.Upisnice.ToListAsync<Upisnica>();

                return View(upisnice);
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
            user.Slika = upisnica.User.Slika;
            user.Email = upisnica.User.Email;
            user.KlubId = upisnica.User.Klub.Id;
            var resul = await _usernManager.UpdateAsync(user);

            upisnica.User = user;
            await _context.Upisnice.AddAsync(upisnica);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", upisnica.Id);
        }

        public async Task<IActionResult> DetailsAsync(int? id)
        {
            if (id == null)
            {
                return View("Create");
            }
                     
            var upisnica = await _context.Upisnice.FirstOrDefaultAsync(upisnica => upisnica.Id == id);

            return View(upisnica);
        }

        public async Task<IActionResult> EditAsync(Upisnica upisnica)
        {
            if (upisnica == null)
            {
                return NotFound();
            }

            var upisnicaStara = await _context.Upisnice.FirstOrDefaultAsync(upisnica => upisnica.Id == upisnica.Id);
            
            _context.Upisnice.Remove(upisnicaStara);
            await _context.Upisnice.AddAsync(upisnica);
            await _context.SaveChangesAsync();

            return View();  
        }

        public async Task<IActionResult> Odbij(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var upisnica = await _context.Upisnice.FirstOrDefaultAsync(upisnica => upisnica.Id == id);
            var user = await _usernManager.FindByIdAsync(upisnica.UserId);

            _context.Upisnice.Remove(upisnicaStara);
            await _context.Upisnice.AddAsync(upisnica);
            await _context.SaveChangesAsync();

            return View();
        }

        public async Task<IActionResult> Prihvati(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var upisnica = await _context.Upisnice.FirstOrDefaultAsync(upisnica => upisnica.Id == id;

            _context.Upisnice.Remove(upisnicaStara);
            await _context.Upisnice.AddAsync(upisnica);
            await _context.SaveChangesAsync();

            return View();
        }
    }
}