using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
using Restaurant.RestaurantModel;

namespace Restaurant.Pages.Menu
{
    public class EditModel : PageModel
    {
        private readonly Restaurant.Data.RestaurantContext _context;

        public EditModel(Restaurant.Data.RestaurantContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Menu_items).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Menu_itemsExists(Menu_items.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool Menu_itemsExists(int id)
        {
            return _context.Menu_items.Any(e => e.Id == id);
        }
    }
}
