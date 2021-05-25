using Entities = EurocomFontysHealth.Library.Entities;
using EurocomFontysHealth.Library.Helpers;
using System;
using EurocomFontysHealth.Library.Entities;
using EurocomFontysHealth.Client;

namespace EurocomFontysHealth.Library
{
    public abstract class DeviceDataSourceBase<T> : DataSourceBase<T>
        where T : Entity
    {
        protected Entities.Client GetClient(int id)
        {
            return new ClientDataSource().GetByID(GuidHelper.GenerateGuid(id, DataConstants.GuidSpace_Client)) ?? throw new Exception($"Cannot find client {id}");
        }
    }
}
