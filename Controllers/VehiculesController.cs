using Microsoft.AspNetCore.Mvc;
using AutoMarket.Data;
using Microsoft.EntityFrameworkCore;

namespace AutoMarket.Controllers
{
    public class VehiculeController : Controller
    {
        private readonly AppDbContext _context;

        public VehiculeController(AppDbContext context)
        {
            _context = context;
        }

        
    }
}
