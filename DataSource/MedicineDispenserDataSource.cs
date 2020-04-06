using EurocomFontysHealth.Library.Entities;
using EurocomFontysHealth.Library.Helpers;
using System;
using System.Collections.Generic;

namespace EurocomFontysHealth.DataSource
{
    public class MedicineDispenserDataSource : DeviceDataSourceBase<MedicineDispenser>
    {
        public override IEnumerable<MedicineDispenser> GetAll()
        {
            yield return new MedicineDispenser() { ID = GuidHelper.GenerateGuid(DataConstants.MedicineDispenser_Device_1, DataConstants.GuidSpace_MedicineDispenser), Client = GetClient(DataConstants.Client_Male_5) };
            yield return new MedicineDispenser() { ID = GuidHelper.GenerateGuid(DataConstants.MedicineDispenser_Device_2, DataConstants.GuidSpace_MedicineDispenser), Client = GetClient(DataConstants.Client_Male_2) };
            yield return new MedicineDispenser() { ID = GuidHelper.GenerateGuid(DataConstants.MedicineDispenser_Device_3, DataConstants.GuidSpace_MedicineDispenser), Client = GetClient(DataConstants.Client_Female_3) };
            yield return new MedicineDispenser() { ID = GuidHelper.GenerateGuid(DataConstants.MedicineDispenser_Device_4, DataConstants.GuidSpace_MedicineDispenser), Client = GetClient(DataConstants.Client_Female_1) };
        }
    }
}
