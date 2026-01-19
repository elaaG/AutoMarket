using Microsoft.AspNetCore.Mvc;
using AutoMarket.Models;
using AutoMarket.Services;  

namespace AutoMarket.Controllers
{
    public class AvisController : Controller
    {
        private readonly MongoAvisService _avisService;  

        public AvisController(MongoAvisService avisService)  
        {
            _avisService = avisService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(int annonceId, string auteur, string commentaire, int note)  // Add 'auteur' parameter
        {
            var avis = new Avis
            {
                AnnonceId = annonceId,
                Auteur = auteur,  
                Commentaire = commentaire,
                Note = note
            };

            await _avisService.AddAvisAsync(avis);  

            return RedirectToAction("Details", "Annonces", new { id = annonceId });
        }
    }
}