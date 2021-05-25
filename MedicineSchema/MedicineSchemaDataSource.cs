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
            yield return GenerateCalendar(DataConstants.MedicineSchema_Female_1_1, DataConstants.Client_Female_1, "Pil 1", new DateTime(2021, 1, 1), new DateTime(2021, 1, 31));
            yield return GenerateCalendar(DataConstants.MedicineSchema_Female_1_2, DataConstants.Client_Female_1, "Pil 1", new DateTime(2021, 1, 1), new DateTime(2021, 1, 31));
            yield return GenerateCalendar(DataConstants.MedicineSchema_Male_3_1, DataConstants.Client_Male_3, "Pil 1", new DateTime(2021, 1, 1), new DateTime(2021, 1, 31));
            yield return GenerateCalendar(DataConstants.MedicineSchema_Male_5_1, DataConstants.Client_Male_5, "Pil 1", new DateTime(2021, 1, 1), new DateTime(2021, 1, 31));
            yield return GenerateCalendar(DataConstants.MedicineSchema_Male_5_2, DataConstants.Client_Male_5, "Pil 2", new DateTime(2021, 1, 1), new DateTime(2021, 1, 31));
            yield return GenerateCalendar(DataConstants.MedicineSchema_Male_5_3, DataConstants.Client_Male_5, "Pil 3", new DateTime(2021, 1, 1), new DateTime(2021, 1, 31));

        }

        private Entities.MedicineCalendar GenerateCalendar(int id, int clientId, string medicine, DateTime calStart, DateTime calEnd)
        {
            var item = new Entities.MedicineCalendar()
            {
                CalendarFrom = calStart,
                CalendarUntil = calEnd,
                CalendarItems = GenerateItems(calStart, calEnd).ToList(),
                Medicine = new Entities.Medicine() { Name = medicine, AdministrationInstructions = $"Please take your: {medicine}", Appearance = "N/A", Prescriber = "Unknown" },
                ClientId = GuidHelper.GenerateGuid(clientId),
                ID = GuidHelper.GenerateGuid(id)
            };
            return item;
        }

        private IEnumerable<Entities.MedicineCalendarItem> GenerateItems(DateTime calStart, DateTime calEnd)
        {
            return new List<Entities.MedicineCalendarItem>();
        }

        /*public const int MedicineSchema_Female_1_1 = 6010;
        public const int MedicineSchema_Female_1_2 = 6011;
        public const int MedicineSchema_Male_3_1 = 6021;
        public const int MedicineSchema_Male_5_1 = 6031;
        public const int MedicineSchema_Male_5_2 = 6032;
        public const int MedicineSchema_Male_5_3 = 6033;*/
    }
}
