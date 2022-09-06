using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ACMEWebApi.Data;
using Shared.Models;

namespace ACMEProject.Pages.Views
{
    public class AddEmployeeModel : PageModel
    {
        private readonly ACMEWebApi.Data.DataContext _context;

        public AddEmployeeModel(ACMEWebApi.Data.DataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["PersonId"] = new SelectList(_context.People, "PersonId", "PersonId");
            return Page();
        }

        [BindProperty]
        public Employee Employee { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Employees == null || Employee == null)
            {
                return Page();
            }

            _context.Employees.Add(Employee);
            await _context.SaveChangesAsync();

            return RedirectToPage("./DataList");
        }
    }
}
