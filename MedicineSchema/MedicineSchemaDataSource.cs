using EurocomFontysHealth.Library;
using EurocomFontysHealth.Library.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using Entities = EurocomFontysHealth.Library.Entities;

namespace EurocomFontysHealth.MedicineSchema
{
    public class MedicineSchemaDataSource : DataSourceBase<Entities.MedicineCalendar>
    {
        
        public override IEnumerable<Entities.MedicineCalendar> GetAll()
        {
            // Generate the dates based on the current date (looking curr and next month)
            DateTime periodStart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime periodEnd = periodStart.AddMonths(2).AddDays(-1); //Take the end date of the next month

            yield return GenerateCalendar(DataConstants.MedicineSchema_Female_1_1, DataConstants.Client_Female_1, "Pil 1", periodStart, periodEnd, false);
            yield return GenerateCalendar(DataConstants.MedicineSchema_Female_1_2, DataConstants.Client_Female_1, "Pil 1", periodStart, periodEnd, false);
            yield return GenerateCalendar(DataConstants.MedicineSchema_Male_3_1, DataConstants.Client_Male_3, "Fluoxetine 20mg", periodStart, periodEnd, true);
            yield return GenerateCalendar(DataConstants.MedicineSchema_Male_5_1, DataConstants.Client_Male_5, "Pil 1", periodStart, periodEnd, false);
            yield return GenerateCalendar(DataConstants.MedicineSchema_Male_5_2, DataConstants.Client_Male_5, "Pil 2", periodStart, periodEnd, false);
            yield return GenerateCalendar(DataConstants.MedicineSchema_Male_5_3, DataConstants.Client_Male_5, "Pil 3", periodStart, periodEnd, true);
        }

        private Entities.MedicineCalendar GenerateCalendar(int id, int clientId, string medicine, DateTime calStart, DateTime calEnd, bool fixedDose)
        {
            var item = new Entities.MedicineCalendar()
            {
                CalendarFrom = calStart,
                CalendarUntil = calEnd,
                CalendarItems = GenerateItems(calStart, calEnd, fixedDose).ToList(),
                Medicine = new Entities.Medicine() { Name = medicine, AdministrationInstructions = $"Please take your: {medicine}", Appearance = "N/A", Prescriber = "Unknown" },
                ClientId = GuidHelper.GenerateGuid(clientId, DataConstants.GuidSpace_Client),
                ID = GuidHelper.GenerateGuid(id, DataConstants.GuidSpace_MedicineSchema)
            };
            System.Console.WriteLine($"Generated medicine calendar {item.ID} for client {item.ClientId}");
            return item;
        }

        private IEnumerable<Entities.MedicineCalendarItem> GenerateItems(DateTime calStart, DateTime calEnd, bool fixedDose)
        {
            if (fixedDose) 
            {
                yield return new Entities.MedicineCalendarItem() { 
                    StartOfPeriod = calStart, 
                    EndOfPeriod = calEnd, 
                    AdministrationMoment = Entities.MedicineCalendarItemAdministrationMoment.Morning, 
                    Dose = "1 maal",
                    Remark = "Medicatie programma regulier te volgen"
                };
            }

            //Generate a decreasing dose list
            int daysInPeriod = (int)calEnd.Subtract(calStart).TotalDays;
            for(int i = 0; i < daysInPeriod; i++)
            {
                yield return new Entities.MedicineCalendarItem() { 
                    StartOfPeriod = calStart, 
                    EndOfPeriod = calEnd, 
                    AdministrationMoment = Entities.MedicineCalendarItemAdministrationMoment.NotRelevant, 
                    Dose = $"{daysInPeriod-i}/{daysInPeriod} deel",
                    Remark = "Medicatie is in afbouw"
                };
            }
        }
    }
}
