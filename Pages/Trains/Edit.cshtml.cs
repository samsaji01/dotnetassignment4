using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assignment4.Data;
using Assignment4.Models;

namespace Assignment4.Pages.Trains
{
    public class EditModel : PageModel
    {
        private readonly Assignment4.Data.TrainDbContext _context;

        public EditModel(Assignment4.Data.TrainDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Train Train { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Train = await _context.Train.FirstOrDefaultAsync(m => m.Id == id);

            if (Train == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Train).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainExists(Train.Id))
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

        private bool TrainExists(int id)
        {
            return _context.Train.Any(e => e.Id == id);
        }
    }
}
