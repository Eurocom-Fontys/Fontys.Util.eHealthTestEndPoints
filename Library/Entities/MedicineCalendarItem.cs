using System;

namespace EurocomFontysHealth.Library.Entities
{
    /// <summary>
    /// Item within the calendar, this is techincally the "dose" to be administered.
    /// The item can be a period when the dose is not changing.
    /// Dates in the item are always day 0:00, end of period is including the day of the end and is also 0:00
    /// (so 1-1-2021 / 1-1-2021 means that this is specifically for 1-1)
    /// 
    /// If a day contains multiple doses the Administration moment will vary, so meaning a day can have multiple medicine administrations
    /// </summary>
    public class MedicineCalendarItem
    {
        /// <summary>
        /// Start date of the calender period (0:00)
        /// </summary>
        public DateTime StartOfPeriod { get; set; }
        
        /// <summary>
        /// End date of the calendar period (0:00), do note that the full day is considered, so the day of the end period SHOULD BE TAKEN INTO CONSIDERATION
        /// </summary>
        public DateTime EndOfPeriod { get; set; }
        
        /// <summary>
        /// When should the dose be administered
        /// </summary>
        public MedicineCalendarItemAdministrationMoment AdministrationMoment { get; set; }
        
        /// <summary>
        /// Textual description of the dose (like 1 full tablet and 1 half)
        /// </summary>
        public string Dose { get; set; }

        /// <summary>
        /// Possible remark of the dose written by the doctor
        /// </summary>
        public string Remark { get; set; }
    }

    public enum MedicineCalendarItemAdministrationMoment
    {
        Undefined = 0,
        NotRelevant,
        Morning,
        Noon,
        Afternoon,
        Evening,
        Night
    }
}
