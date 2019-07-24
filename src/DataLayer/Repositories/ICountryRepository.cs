using DomainClasses;

namespace DataLayer.Repositories
{
    public interface ICountryRepository : IRepository<Country>
    {
        Country GetByCountryName(string countryName);
    }
}