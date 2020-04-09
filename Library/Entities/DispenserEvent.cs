using System;
using System.Collections.Generic;
using System.Text;

namespace EurocomFontysHealth.Library.Entities
{
    public enum DispenserEventResult
    {
        Unknown,
        Taken,
        NotTaken,
        Error
    }

    public class DispenserEvent : Entity
    {
        public Guid DeviceID { get; set; }
        
        /// <summary>
        /// Result of the medication dispensing
        /// </summary>
        public DispenserEventResult Result { get; set; }
        
        /// <summary>
        /// First and initial offering of the dispenser
        /// </summary>
        public DateTime? Offering1 { get; set; }

        /// <summary>
        /// (OPTIONAL) Second offering of the dispenser
        /// </summary>
        public DateTime? Offering2 { get; set; }

        /// <summary>
        /// (OPTIONAL) Third offering of the dispenser
        /// </summary>
        public DateTime? Offering3 { get; set; }
        /// <summary>
        /// Moment of retrieval of the dose
        /// </summary>
        public DateTime? Retrieval { get; set; }
    }
}
