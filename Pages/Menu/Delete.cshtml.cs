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
    public class DeleteModel : PageModel
    {
        private readonly Restaurant.Data.RestaurantContext _context;

        public DeleteModel(Restaurant.Data.RestaurantContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Menu_items Menu_items { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Menu_items = await _context.Menu_items.FirstOrDefaultAsync(m => m.Id == id);

            if (Menu_items == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Menu_items = await _context.Menu_items.FindAsync(id);

            if (Menu_items != null)
            {
                _context.Menu_items.Remove(Menu_items);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
