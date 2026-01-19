using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactManager.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(9, MinimumLength = 9)]
        [Column(TypeName = "char(9)")]
        public string Phone { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public bool IsDeleted { get; set; } = false;
    }
}
