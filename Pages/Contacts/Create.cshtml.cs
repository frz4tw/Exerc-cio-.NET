using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using ContactManager.Data;
using ContactManager.Models;

namespace ContactManager.Pages_Contacts
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Contact Contact { get; set; } = new Contact();

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _context.Contacts.Add(Contact);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                // Erro de unicidade (Email ou Phone)
                ModelState.AddModelError(string.Empty, "Email or Phone already exists.");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
