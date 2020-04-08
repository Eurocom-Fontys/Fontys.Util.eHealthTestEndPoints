using EurocomFontysHealth.Library.Entities;
using EurocomFontysHealth.Library.Helpers;
using System;

namespace EurocomFontysHealth.DataSource
{
    public abstract class DeviceDataSourceBase<T> : DataSourceBase<T>
        where T : Entity
    {
        protected Client GetClient(int id)
        {
            return new ClientDataSource().GetByID(GuidHelper.GenerateGuid(id, DataConstants.GuidSpace_Client)) ?? throw new Exception($"Cannot find client {id}");
        }
    }
}
