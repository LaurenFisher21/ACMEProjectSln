using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ACMEWebApi.Data;
using Shared.Models;

namespace ACMEProject.Pages.Views
{
    public class DatalistModel : PageModel
    {
        private readonly ACMEWebApi.Data.DataContext _context;

        public DatalistModel(ACMEWebApi.Data.DataContext context)
        {
            _context = context;
        }

        public IList<Employee> Employee { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Employees != null)
            {
                Employee = await _context.Employees
                .Include(e => e.Person).ToListAsync();
            }
        }
    }
}
