using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
using Restaurant.RestaurantModel;

namespace Restaurant.Pages.Menu
{
    public class IndexModel : PageModel
    {
        private readonly Restaurant.Data.RestaurantContext _context;

        public IndexModel(Restaurant.Data.RestaurantContext context)
        {
            _context = context;
        }

        public IList<Menu_items> Menu_items { get;set; }

        public async Task OnGetAsync()
        {
            Menu_items = await _context.Menu_items.ToListAsync();
        }
    }
}
