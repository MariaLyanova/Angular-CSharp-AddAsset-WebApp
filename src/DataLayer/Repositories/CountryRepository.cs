using DomainClasses;
using System.Linq;

namespace DataLayer.Repositories
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        public CountryRepository(AssetContext context)
            : base(context)
        {
        }

        public AssetContext AssetContext
        {
            get { return Context as AssetContext; }
        }

        public Country GetByCountryName(string countryName)
        {
            return AssetContext.Countries.FirstOrDefault(c => c.CountryName == countryName);
        }
    }
}