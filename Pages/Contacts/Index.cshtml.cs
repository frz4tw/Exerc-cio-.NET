using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ContactManager.Data;
using ContactManager.Models;
using Microsoft.AspNetCore.Authorization;

namespace ContactManager.Pages_Contacts
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Contact> Contacts { get; set; } = new List<Contact>();

        public async Task OnGetAsync()
        {
            Contacts = await _context.Contacts.ToListAsync();
        }
    }
}
