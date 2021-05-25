using System;
using System.Collections.Generic;

namespace EurocomFontysHealth.Library.Entities
{
    /// <summary>
    /// Container for the Medicine administration, this is filled by the responsible doctor
    /// </summary>
    public class MedicineCalendar : Entity
    {
        public Guid ClientId { get; set; }

        public Medicine Medicine { get; set; }

        /// <summary>
        /// Start date of the calendar, this is INCLUSIVE
        /// </summary>
        public DateTime CalendarFrom { get; set; }

        /// <summary>
        /// End date of the calendar, this date is INCLUSIVE
        /// </summary>
        public DateTime CalendarUntil { get; set; }

        public List<MedicineCalendarItem> CalendarItems { get; set; } = new List<MedicineCalendarItem>();
    }
}
