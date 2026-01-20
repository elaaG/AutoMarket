using Microsoft.AspNetCore.Mvc;
using AutoMarket.Data;
using AutoMarket.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace AutoMarket.Controllers
{
    [Authorize(Roles = "Expert")]
    public class VerificationController : Controller
    {
        private readonly AppDbContext _context;

        public VerificationController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var annonces = await _context.Annonces
                .Include(a => a.Vehicule)
                .Where(a => a.Statut == "En attente")
                .ToListAsync();

            return View(annonces);
        }

        public async Task<IActionResult> Approve(int id)
        {
            var annonce = await _context.Annonces
                .Include(a => a.Vehicule)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (annonce == null) return NotFound();

            annonce.Statut = "Validée";
            annonce.Vehicule.Verifie = true;

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Reject(int id)
        {
            var annonce = await _context.Annonces
                .Include(a => a.Vehicule)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (annonce == null) return NotFound();

            annonce.Statut = "Rejetée";
            annonce.Vehicule.Verifie = false;

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
