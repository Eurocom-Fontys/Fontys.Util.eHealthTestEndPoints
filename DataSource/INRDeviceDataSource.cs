using EurocomFontysHealth.Library.Entities;
using EurocomFontysHealth.Library.Helpers;
using System;
using System.Collections.Generic;

namespace EurocomFontysHealth.DataSource
{
    public abstract class DeviceDataSourceBase<T> : DataSourceBase<T>
        where T : Entity
    {
        protected Client GetClient(int id)
        {
            return new ClientDataSource().GetByID(GuidHelper.GenerateGuid(id)) ?? throw new Exception($"Cannot find client {id}");
        }
    }
    public class INRDeviceDataSource : DeviceDataSourceBase<INRDevice>
    {
        public override IEnumerable<INRDevice> GetAll()
        {
            yield return new INRDevice() { ID = GuidHelper.GenerateGuid(DataConstants.INR_Device_1, DataConstants.GuidSpace_INR), Client = GetClient(DataConstants.Client_Female_3), TargetValue = 1.0m, LowerBoundary = 0.8m, UpperBoundary = 1.2m };
            yield return new INRDevice() { ID = GuidHelper.GenerateGuid(DataConstants.INR_Device_2, DataConstants.GuidSpace_INR), Client = GetClient(DataConstants.Client_Female_1), TargetValue = 2.0m, LowerBoundary = 1.9m, UpperBoundary = 2.4m };
            yield return new INRDevice() { ID = GuidHelper.GenerateGuid(DataConstants.INR_Device_3, DataConstants.GuidSpace_INR), Client = GetClient(DataConstants.Client_Male_4), TargetValue = 1.3m, LowerBoundary = 1m, UpperBoundary = 1.35m };
            yield return new INRDevice() { ID = GuidHelper.GenerateGuid(DataConstants.INR_Device_4, DataConstants.GuidSpace_INR), Client = GetClient(DataConstants.Client_Male_5), TargetValue = 0.9m, LowerBoundary = 0.87m, UpperBoundary = 0.99m };
        }
    }
}
