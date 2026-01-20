using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMarket.Data;
using AutoMarket.Models;
using AutoMarket.Models.ViewModels;
using AutoMarket.Services;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace AutoMarket.Controllers
{
    public class AnnoncesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly MongoAvisService _avisService;

        public AnnoncesController(
            AppDbContext context,
            IWebHostEnvironment env,
            MongoAvisService avisService)
        {
            _context = context;
            _env = env;
            _avisService = avisService;
        }

        public async Task<IActionResult> Index()
        {
            var annonces = await _context.Annonces
                .Include(a => a.Vehicule)
                .Where(a => a.Vehicule.Verifie)
                .ToListAsync();

            return View(annonces);
        }

        [Authorize(Roles = "Seller")]
        public async Task<IActionResult> Dashboard()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var annonces = await _context.Annonces
                .Include(a => a.Vehicule)
                .Where(a => a.SellerId == userId)
                .ToListAsync();

            return View(annonces);
        }

        public async Task<IActionResult> Details(int id)
        {
            var annonce = await _context.Annonces
                .Include(a => a.Vehicule)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (annonce == null)
                return NotFound();

            var avis = await _avisService.GetAvisByAnnonceAsync(id);
            ViewBag.Avis = avis;

            return View(annonce);
        }

        [Authorize(Roles = "Seller")]
        [HttpGet]
        public IActionResult Create()
        {
            return View(new AnnonceEditVM());
        }

        [Authorize(Roles = "Seller")]
        [HttpPost]
        public async Task<IActionResult> Create(AnnonceEditVM vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            string photoPath = null;

            if (vm.Photo != null)
            {
                var uploadDir = Path.Combine(_env.WebRootPath, "images");
                Directory.CreateDirectory(uploadDir);

                var fileName = Guid.NewGuid() + Path.GetExtension(vm.Photo.FileName);
                var filePath = Path.Combine(uploadDir, fileName);

                using var stream = new FileStream(filePath, FileMode.Create);
                await vm.Photo.CopyToAsync(stream);

                photoPath = "/images/" + fileName;
            }

            var vehicule = new Vehicule
            {
                Marque = vm.Marque,
                Modele = vm.Modele,
                Annee = vm.Annee,
                Kilometrage = vm.Kilometrage,
                Prix = vm.Prix,
                PhotoPath = photoPath,
                Verifie = false
            };

            _context.Vehicules.Add(vehicule);
            await _context.SaveChangesAsync();

            var sellerId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var annonce = new Annonce
            {
                Titre = vm.Titre,
                Type = vm.Type,
                Statut = "En attente",
                DatePublication = DateTime.Now,
                VehiculeId = vehicule.Id,
                SellerId = sellerId
            };

            _context.Annonces.Add(annonce);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Dashboard));
        }

        [Authorize(Roles = "Seller")]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var annonce = await _context.Annonces
                .Include(a => a.Vehicule)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (annonce == null)
                return NotFound();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (annonce.SellerId != userId)
                return Forbid();

            var vm = new AnnonceEditVM
            {
                Id = annonce.Id,
                Titre = annonce.Titre,
                Type = annonce.Type,
                Marque = annonce.Vehicule.Marque,
                Modele = annonce.Vehicule.Modele,
                Annee = annonce.Vehicule.Annee,
                Kilometrage = annonce.Vehicule.Kilometrage,
                Prix = annonce.Vehicule.Prix,
                ExistingPhotoPath = annonce.Vehicule.PhotoPath
            };

            return View(vm);
        }

        [Authorize(Roles = "Seller")]
        [HttpPost]
        public async Task<IActionResult> Edit(AnnonceEditVM vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var annonce = await _context.Annonces
                .Include(a => a.Vehicule)
                .FirstOrDefaultAsync(a => a.Id == vm.Id);

            if (annonce == null)
                return NotFound();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (annonce.SellerId != userId)
                return Forbid();

            annonce.Titre = vm.Titre;
            annonce.Type = vm.Type;

            annonce.Vehicule.Marque = vm.Marque;
            annonce.Vehicule.Modele = vm.Modele;
            annonce.Vehicule.Annee = vm.Annee;
            annonce.Vehicule.Kilometrage = vm.Kilometrage;
            annonce.Vehicule.Prix = vm.Prix;

            if (vm.Photo != null)
            {
                var uploadDir = Path.Combine(_env.WebRootPath, "images");
                Directory.CreateDirectory(uploadDir);

                var fileName = Guid.NewGuid() + Path.GetExtension(vm.Photo.FileName);
                var filePath = Path.Combine(uploadDir, fileName);

                using var stream = new FileStream(filePath, FileMode.Create);
                await vm.Photo.CopyToAsync(stream);

                annonce.Vehicule.PhotoPath = "/images/" + fileName;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Dashboard));
        }

        [Authorize(Roles = "Seller")]
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var annonce = await _context.Annonces
                .Include(a => a.Vehicule)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (annonce == null)
                return NotFound();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (annonce.SellerId != userId)
                return Forbid();

            _context.Annonces.Remove(annonce);
            _context.Vehicules.Remove(annonce.Vehicule);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Dashboard));
        }

        
        public async Task<IActionResult> Search(string keyword)
        {
            var annonces = await _context.Annonces
                .Include(a => a.Vehicule)
                .Where(a =>
                    a.Titre.Contains(keyword) ||
                    a.Vehicule.Marque.Contains(keyword))
                .ToListAsync();

            return View(annonces);
        }
    }
}
