using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EFcore02.Models
{
    [Table("EventOrganizers")]
    public class Organizer
    {

        public int OrganizerId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(150)]
        public string? CompanyName { get; set; }

        public bool IsVerified { get; set; }

        // Navigation Properties
        public OrganizerProfile Profile { get; set; } = null!;

        public ICollection<Event> Events { get; set; } = new List<Event>();

    }
}
