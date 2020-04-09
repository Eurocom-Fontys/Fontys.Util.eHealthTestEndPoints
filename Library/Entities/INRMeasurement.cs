using System;
using System.Collections.Generic;
using System.Text;

namespace EurocomFontysHealth.Library.Entities
{
    public class INRMeasurement : Entity
    {
        /// <summary>
        /// Device the measurement is related to
        /// </summary>
        public Guid DeviceID { get; set; }

        /// <summary>
        /// Date of the measurement (no time part)
        /// </summary>
        public DateTime MeasurementDate { get; set; } 
        
        /// <summary>
        /// Indication whether the measurement succeeeded
        /// </summary>
        public bool MeasurementSucceeded { get; set; }
        
        /// <summary>
        /// Value determined by the measurement. Is left null if failed
        /// </summary>
        public decimal? MeasurementValue { get; set; }

        /// <summary>
        /// Time (in seconds) the measurement took (also registered for failed)
        /// </summary>
        public int MeasurementTimeInSeconds { get; set; }
    }
}
