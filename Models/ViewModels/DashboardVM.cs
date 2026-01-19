using AutoMarket.Models;
using System.Collections.Generic;

namespace AutoMarket.Models.ViewModels
{
    public class DashboardVM
    {
        public User Seller { get; set; } = null!;
        public List<Annonce> Annonces { get; set; } = new List<Annonce>();
    }
}
