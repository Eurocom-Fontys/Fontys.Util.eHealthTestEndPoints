using EurocomFontysHealth.Library;
using Entities = EurocomFontysHealth.Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EurocomFontysHealth.MedicineDispenser
{
    public class MedicineDispenserEventDataSource : MeasurementDataSourceBase<Entities.DispenserEvent>
    {
        public override IEnumerable<Entities.DispenserEvent> GetAll()
        {
            return new MedicineDispenserDataSource().GetAll().SelectMany(GetEventsForDispenser);
        }

        private DateTime DispensingStartDate = new DateTime(2020, 3, 1);
        private DateTime DispensingEndDate = DateTime.Now;

        private IEnumerable<Entities.DispenserEvent> GetEventsForDispenser(Entities.MedicineDispenser dispenser)
        {
            int nrOfDispensesPerDay = TakeRandom(new[] { 1, 1, 1, 2, 3, 3, 2, 2, 2, 1, 1 });
            DateTime currDate = DispensingStartDate;
            while(currDate < DispensingEndDate)
            {
                int hour = TakeRandom(new[] { 7, 8, 9, 10 });
                for(int currDispense = 0; currDispense < nrOfDispensesPerDay; currDispense++)
                {
                    int nrOfTries = TakeRandom(new[] { 1, 1, 1, 1, 1, 1, 2, 3 ,2, 3, 1, 1, 2 });
                    bool succeeded = TakeRandom(new[] { true, true, true, true, true, true, true, false, false });
                    DateTime? try1 = new DateTime(currDate.Year, currDate.Month, currDate.Day, hour, TakeRandom(new[] { 10, 11, 12, 13, 15 }), TakeRandom(new[] { 10, 20, 30, 40, 50 }));
                    DateTime? try2 = nrOfTries >= 2 ? (DateTime?)new DateTime(currDate.Year, currDate.Month, currDate.Day, hour, TakeRandom(new[] { 30, 34, 33, 35, 40, 41 }), TakeRandom(new[] { 10, 20, 30, 40, 50 })) : null;
                    DateTime? try3 = nrOfTries >= 3 ? (DateTime?)new DateTime(currDate.Year, currDate.Month, currDate.Day, hour, TakeRandom(new[] { 44, 45, 50, 55, 58}), TakeRandom(new[] { 10, 20, 30, 40, 50 })) : null;

                    DateTime? retrieval = null;
                    if (succeeded) //Determine the retrieval-time of the medicines
                    {
                        DateTime lastHandOut = try3 ?? try2 ?? try1 ?? throw new Exception("This should not happen!");
                        retrieval = lastHandOut.AddMinutes(TakeRandom(new[] { 1, 2, 3, 4, 1, 2, 5, 15, 11 })); //Add an interval to the offer time to have a retrieval
                    }

                    yield return new Entities.DispenserEvent()
                    {
                        ID = Guid.NewGuid(),
                        DeviceID = dispenser.ID,
                        Offering1 = try1,
                        Offering2 = try2,
                        Offering3 = try3,
                        Retrieval = retrieval,
                        Result = succeeded ? Entities.DispenserEventResult.Taken : Entities.DispenserEventResult.NotTaken
                    };

                    //Set a new moment for the day by adding time to the hour offset
                    hour = hour + TakeRandom(new[] { 2, 3, 4, 2, 4}); 
                }

                //Next day!
                currDate = currDate.AddDays(1);
            }
        }
    }
}
