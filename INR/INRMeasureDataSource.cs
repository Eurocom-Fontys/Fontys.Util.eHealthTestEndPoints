using EurocomFontysHealth.Library;
using EurocomFontysHealth.Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EurocomFontysHealth.INR
{
    public class INRMeasurementDataSource : MeasurementDataSourceBase<INRMeasurement>
    {
        public override IEnumerable<INRMeasurement> GetAll()
        {
            return new INRDeviceDataSource().GetAll().SelectMany(GenerateMeasuresForDevice);
        }

        private DateTime GeneratorStartDate = new DateTime(2019, 1, 1);
        private DateTime GeneratorEndDate = new DateTime(2020, 4, 1);

        private IEnumerable<INRMeasurement> GenerateMeasuresForDevice(INRDevice device)
        {
            int measureInterval = TakeRandom(new[] { 10, 15, 20, 31 });
            DateTime measureDate = GeneratorStartDate.AddDays(measureInterval);
            while(measureDate < GeneratorEndDate)
            {
                bool success = TakeRandom(new[] { true, true, true, false, true, false });
                int measureTime = TakeRandom(new[] { 30, 31, 33, 35, 29, 41 });
                
                //Determine a measurement value and do some percentual deviation on the value
                decimal? measurementValue = device.TargetValue;
                measurementValue = measurementValue + (measurementValue * TakeRandom(new[] { 0.0m, 0.001m, 0m, 0m, -0.5m, 0.5m, 0.03m, -0.3m, 0.11m, -0.11m, 0, 0, 0, -0.3m })); //Do a variation based on  a percentage
                yield return new INRMeasurement()
                {
                    ID = Guid.NewGuid(),
                    DeviceID = device.ID,
                    MeasurementDate = measureDate,
                    MeasurementSucceeded = success,
                    MeasurementTimeInSeconds = measureTime,
                    MeasurementValue = success ? measurementValue : null
                };
                measureDate = measureDate.AddDays(measureInterval);
            }
        }
    }
}
