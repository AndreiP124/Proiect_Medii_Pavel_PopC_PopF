using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Restaurant.Data;
using Restaurant.RestaurantModel;

namespace Restaurant.Pages.Menu
{
    public class CreateModel : PageModel
    {
        private readonly Restaurant.Data.RestaurantContext _context;

        public CreateModel(Restaurant.Data.RestaurantContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Menu_items Menu_items { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Menu_items.Add(Menu_items);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
