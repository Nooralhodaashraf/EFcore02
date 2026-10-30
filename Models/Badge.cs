using System;
using System.Collections.Generic;
using System.Text;


namespace EFcore02.Models
{
    public class Badge
    {
        public int BadgeId { get; set; }

        public string BadgeNumber { get; set; } = string.Empty;

        public DateTime IssuedDate { get; set; }

        public string Tier { get; set; } = string.Empty;

        // Foreign Key
        public int AttendeeId { get; set; }

        // Navigation Property
        public Attendee Attendee { get; set; } = null!;
    }
}
