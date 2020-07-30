using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Assignment4.Data;
using Assignment4.Models;

namespace Assignment4.Pages.Trains
{
    public class IndexModel : PageModel
    {
        private readonly Assignment4.Data.TrainDbContext _context;

        public IndexModel(Assignment4.Data.TrainDbContext context)
        {
            _context = context;
        }

        public IList<Train> Train { get;set; }

        public async Task OnGetAsync()
        {
            Train = await _context.Train.ToListAsync();
        }
    }
}
