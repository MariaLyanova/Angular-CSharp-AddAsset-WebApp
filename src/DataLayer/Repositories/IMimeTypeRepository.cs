using DomainClasses;

namespace DataLayer.Repositories
{
    public interface IMimeTypeRepository : IRepository<MimeType>
    {
        MimeType GetByMimeTypeName(string MimeTypeName);
    }
}