using DataLayer.Repositories;
using DomainClasses;

namespace DataLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AssetContext _context;

        public UnitOfWork(AssetContext context)
        {
            _context = context;
            Assets = new AssetRepository(_context);
            Countries = new CountryRepository(_context);
            MimeTypes = new MimeTypeRepository(_context);
        }

        public IRepository<Asset> Assets { get; }
        public ICountryRepository Countries { get; }
        public IMimeTypeRepository MimeTypes { get; }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}