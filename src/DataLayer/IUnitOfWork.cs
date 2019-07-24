using DataLayer.Repositories;
using DomainClasses;
using System;


namespace DataLayer
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Asset> Assets { get; }
        ICountryRepository Countries { get; }
        IMimeTypeRepository MimeTypes { get; }
        int Save();
    }
}