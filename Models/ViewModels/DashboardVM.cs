using AutoMarket.Models;
using System.Collections.Generic;

namespace AutoMarket.Models.ViewModels
{
    public class DashboardVM
    {
        public List<Annonce> Annonces { get; set; } = new();
        public List<AppUser> Users { get; set; } = new();
    }
}
