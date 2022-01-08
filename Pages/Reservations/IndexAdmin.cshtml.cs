using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
using Restaurant.RestaurantModel;

namespace Restaurant.Pages.Reservations
{
    public class IndexModel : PageModel
    {
        private readonly Restaurant.Data.RestaurantContext _context;

        public IndexModel(Restaurant.Data.RestaurantContext context)
        {
            _context = context;
        }

        public IList<Reservation> Reservation { get;set; }

        public async Task OnGetAsync()
        {
            Reservation = await _context.Reservation.ToListAsync();
        }
    }
}
