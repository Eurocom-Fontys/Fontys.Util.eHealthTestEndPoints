using EurocomFontysHealth.Library;
using Entities = EurocomFontysHealth.Library.Entities;
using EurocomFontysHealth.Library.Helpers;
using System.Collections.Generic;
using System.Text;

namespace EurocomFontysHealth.Client
{

    public class ClientDataSource : DataSourceBase<Entities.Client>
    {
        public override IEnumerable<Entities.Client> GetAll()
        {
            yield return new Entities.Client() { ID = GuidHelper.GenerateGuid(DataConstants.Client_Female_1, DataConstants.GuidSpace_Client), Age = 81, Sex = Entities.Sex.Female , Name = "Sophie Bosman" };
            yield return new Entities.Client() { ID = GuidHelper.GenerateGuid(DataConstants.Client_Female_2, DataConstants.GuidSpace_Client), Age = 79, Sex = Entities.Sex.Female , Name = "Mayke Blokzijl" };
            yield return new Entities.Client() { ID = GuidHelper.GenerateGuid(DataConstants.Client_Female_3, DataConstants.GuidSpace_Client), Age = 61, Sex = Entities.Sex.Female , Name = "Marjolein Nevensel" };
            yield return new Entities.Client() { ID = GuidHelper.GenerateGuid(DataConstants.Client_Female_4, DataConstants.GuidSpace_Client), Age = 99, Sex = Entities.Sex.Female , Name = "Gerrieke Holleboom" };
            yield return new Entities.Client() { ID = GuidHelper.GenerateGuid(DataConstants.Client_Female_5, DataConstants.GuidSpace_Client), Age = 101, Sex = Entities.Sex.Female , Name = "Kaatje van Heeten" };

            yield return new Entities.Client() { ID = GuidHelper.GenerateGuid(DataConstants.Client_Male_1, DataConstants.GuidSpace_Client), Age = 56, Sex = Entities.Sex.Male , Name = "Jelle Holterman" };
            yield return new Entities.Client() { ID = GuidHelper.GenerateGuid(DataConstants.Client_Male_2, DataConstants.GuidSpace_Client), Age = 57, Sex = Entities.Sex.Male, Name = "Maurits Raadsveld" };
            yield return new Entities.Client() { ID = GuidHelper.GenerateGuid(DataConstants.Client_Male_3, DataConstants.GuidSpace_Client), Age = 81, Sex = Entities.Sex.Male, Name = "Jos Mannussen" };
            yield return new Entities.Client() { ID = GuidHelper.GenerateGuid(DataConstants.Client_Male_4, DataConstants.GuidSpace_Client), Age = 68, Sex = Entities.Sex.Male, Name = "Lowie de Wit" };
            yield return new Entities.Client() { ID = GuidHelper.GenerateGuid(DataConstants.Client_Male_5, DataConstants.GuidSpace_Client), Age = 63, Sex = Entities.Sex.Male, Name = "Lars Kessen" };
        }
    }
}
