using EurocomFontysHealth.Library.Entities;
using EurocomFontysHealth.Library.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EurocomFontysHealth.DataSource
{
    public abstract class DataSource<T>
    {
        public abstract IEnumerable<T> GetAll();
    
        public IEnumerable<T> GetFiltered(Func<T, bool> predicate)
        {
            return GetAll().Where(a => predicate(a)).ToList();
        }
    }

    public class ClientDataSource : DataSource<Client>
    {
        public override IEnumerable<Client> GetAll()
        {
            yield return new Client() { ID = GuidHelper.GenerateGuid(1, DataConstants.GuidSpace_Client), Age = 81, Sex = Sex.Female , Name = "Sophie Bosman" };
            yield return new Client() { ID = GuidHelper.GenerateGuid(2, DataConstants.GuidSpace_Client), Age = 79, Sex = Sex.Female , Name = "Mayke Blokzijl" };
            yield return new Client() { ID = GuidHelper.GenerateGuid(3, DataConstants.GuidSpace_Client), Age = 61, Sex = Sex.Female , Name = "Marjolein Nevensel" };
            yield return new Client() { ID = GuidHelper.GenerateGuid(4, DataConstants.GuidSpace_Client), Age = 99, Sex = Sex.Female , Name = "Gerrieke Holleboom" };
            yield return new Client() { ID = GuidHelper.GenerateGuid(5, DataConstants.GuidSpace_Client), Age = 101, Sex = Sex.Female , Name = "Kaatje van Heeten" };

            yield return new Client() { ID = GuidHelper.GenerateGuid(101, DataConstants.GuidSpace_Client), Age = 56, Sex = Sex.Male , Name = "Jelle Holterman" };
            yield return new Client() { ID = GuidHelper.GenerateGuid(102, DataConstants.GuidSpace_Client), Age = 57, Sex = Sex.Male, Name = "Maurits Raadsveld" };
            yield return new Client() { ID = GuidHelper.GenerateGuid(103, DataConstants.GuidSpace_Client), Age = 81, Sex = Sex.Male, Name = "Jos Mannussen" };
            yield return new Client() { ID = GuidHelper.GenerateGuid(104, DataConstants.GuidSpace_Client), Age = 68, Sex = Sex.Male, Name = "Lowie de Wit" };
            yield return new Client() { ID = GuidHelper.GenerateGuid(105, DataConstants.GuidSpace_Client), Age = 63, Sex = Sex.Male, Name = "Lars Kessen" };
        }
    }


    public class INRDeviceDataSource : DataSource<INRDevice>
    {
        public override IEnumerable<INRDevice> GetAll()
        {
            throw new NotImplementedException();
        }
    }

    public class MedicineDispenserDataSource : DataSource<MedicineDispenser>
    {
        public override IEnumerable<MedicineDispenser> GetAll()
        {
            throw new NotImplementedException();
        }
    }

    public class DataConstants
    {
        public const short GuidSpace_Client = 100;
        public const short GuidSpace_INR = 200;
        public const short GuidSpace_MedicineDispenser = 200;
    }
}
