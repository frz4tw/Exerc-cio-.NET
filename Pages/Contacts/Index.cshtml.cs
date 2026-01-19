using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using ContactManager.Data;
using ContactManager.Models;

namespace ContactManager.Pages_Contacts
{
    [AllowAnonymous]
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
            Contacts = await _context.Contacts
                .Where(c => !c.IsDeleted)
                .ToListAsync();
        }
    }
}
