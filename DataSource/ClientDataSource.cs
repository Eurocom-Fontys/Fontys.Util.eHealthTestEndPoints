using EurocomFontysHealth.Library.Entities;
using EurocomFontysHealth.Library.Helpers;
using System.Collections.Generic;
using System.Text;

namespace EurocomFontysHealth.DataSource
{

    public class ClientDataSource : DataSourceBase<Client>
    {
        public override IEnumerable<Client> GetAll()
        {
            yield return new Client() { ID = GuidHelper.GenerateGuid(DataConstants.Client_Female_1, DataConstants.GuidSpace_Client), Age = 81, Sex = Sex.Female , Name = "Sophie Bosman" };
            yield return new Client() { ID = GuidHelper.GenerateGuid(DataConstants.Client_Female_2, DataConstants.GuidSpace_Client), Age = 79, Sex = Sex.Female , Name = "Mayke Blokzijl" };
            yield return new Client() { ID = GuidHelper.GenerateGuid(DataConstants.Client_Female_3, DataConstants.GuidSpace_Client), Age = 61, Sex = Sex.Female , Name = "Marjolein Nevensel" };
            yield return new Client() { ID = GuidHelper.GenerateGuid(DataConstants.Client_Female_4, DataConstants.GuidSpace_Client), Age = 99, Sex = Sex.Female , Name = "Gerrieke Holleboom" };
            yield return new Client() { ID = GuidHelper.GenerateGuid(DataConstants.Client_Female_5, DataConstants.GuidSpace_Client), Age = 101, Sex = Sex.Female , Name = "Kaatje van Heeten" };

            yield return new Client() { ID = GuidHelper.GenerateGuid(DataConstants.Client_Male_1, DataConstants.GuidSpace_Client), Age = 56, Sex = Sex.Male , Name = "Jelle Holterman" };
            yield return new Client() { ID = GuidHelper.GenerateGuid(DataConstants.Client_Male_2, DataConstants.GuidSpace_Client), Age = 57, Sex = Sex.Male, Name = "Maurits Raadsveld" };
            yield return new Client() { ID = GuidHelper.GenerateGuid(DataConstants.Client_Male_3, DataConstants.GuidSpace_Client), Age = 81, Sex = Sex.Male, Name = "Jos Mannussen" };
            yield return new Client() { ID = GuidHelper.GenerateGuid(DataConstants.Client_Male_4, DataConstants.GuidSpace_Client), Age = 68, Sex = Sex.Male, Name = "Lowie de Wit" };
            yield return new Client() { ID = GuidHelper.GenerateGuid(DataConstants.Client_Male_5, DataConstants.GuidSpace_Client), Age = 63, Sex = Sex.Male, Name = "Lars Kessen" };
        }
    }
}
