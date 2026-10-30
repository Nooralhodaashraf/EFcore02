using System;
using System.Collections.Generic;
using System.Text;

namespace EFcore02.Models
{
    public class Event
    {

        public int EventId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int MaxAttendees { get; set; }

        // Foreign Key
        public int OrganizerId { get; set; }

        // Navigation Property
        public Organizer Organizer { get; set; } = null!;
    }
}
