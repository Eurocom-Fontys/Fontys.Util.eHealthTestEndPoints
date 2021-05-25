using EurocomFontysHealth.Library;
using Entities = EurocomFontysHealth.Library.Entities;
using EurocomFontysHealth.Library.Helpers;
using System;
using System.Collections.Generic;

namespace EurocomFontysHealth.MedicineDispenser
{
    public class MedicineDispenserDataSource : DeviceDataSourceBase<Entities.MedicineDispenser>
    {
        public override IEnumerable<Entities.MedicineDispenser> GetAll()
        {
            yield return new Entities.MedicineDispenser() { ID = GuidHelper.GenerateGuid(DataConstants.MedicineDispenser_Device_1, DataConstants.GuidSpace_MedicineDispenser), Client = GetClient(DataConstants.Client_Male_5) };
            yield return new Entities.MedicineDispenser() { ID = GuidHelper.GenerateGuid(DataConstants.MedicineDispenser_Device_2, DataConstants.GuidSpace_MedicineDispenser), Client = GetClient(DataConstants.Client_Male_2) };
            yield return new Entities.MedicineDispenser() { ID = GuidHelper.GenerateGuid(DataConstants.MedicineDispenser_Device_3, DataConstants.GuidSpace_MedicineDispenser), Client = GetClient(DataConstants.Client_Female_3) };
            yield return new Entities.MedicineDispenser() { ID = GuidHelper.GenerateGuid(DataConstants.MedicineDispenser_Device_4, DataConstants.GuidSpace_MedicineDispenser), Client = GetClient(DataConstants.Client_Female_1) };
        }
    }
}
