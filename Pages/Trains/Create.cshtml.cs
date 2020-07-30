using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Assignment4.Data;
using Assignment4.Models;

namespace Assignment4.Pages.Trains
{
    public class CreateModel : PageModel
    {
        private readonly Assignment4.Data.TrainDbContext _context;

        public CreateModel(Assignment4.Data.TrainDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Train Train { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Train.Add(Train);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}