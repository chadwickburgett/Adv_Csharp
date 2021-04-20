using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace cremeCoffeeBurgett.Models
{
    public class Validate
    {
        private const string CountryKey = "validCountry";
        private const string OriginKey = "validOrigin";
        private const string EmailKey = "validEmail";

        private ITempDataDictionary tempData { get; set; }
        public Validate(ITempDataDictionary temp) => tempData = temp;

        public bool IsValid { get; private set; }
        public string ErrorMessage { get; private set; }

        public void CheckCountry(string countryId, Repository<Country> data)
        {
            Country entity = data.Get(countryId);
            IsValid = (entity == null) ? true : false;
            ErrorMessage = (IsValid) ? "" : 
                $"Country id {countryId} is already in the database.";
        }
        public void MarkCountryChecked() => tempData[CountryKey] = true;
        public void ClearCountry() => tempData.Remove(CountryKey);
        public bool IsCountryChecked => tempData.Keys.Contains(CountryKey);

        public void CheckOrigin(string Name, string Process, string operation, Repository<Origin> data)
        {
            Origin entity = null; 
            if (Operation.IsAdd(operation)) {
                entity = data.Get(new QueryOptions<Origin> {
                    Where = a => a.Name == Name && a.Process == Process});
            }
            IsValid = (entity == null) ? true : false;
            ErrorMessage = (IsValid) ? "" : 
                $"Origin {entity.Name} is already in the database.";
        }
        public void MarkOriginChecked() => tempData[OriginKey] = true;
        public void ClearOrigin() => tempData.Remove(OriginKey);
        public bool IsOriginChecked => tempData.Keys.Contains(OriginKey);
    }
}
