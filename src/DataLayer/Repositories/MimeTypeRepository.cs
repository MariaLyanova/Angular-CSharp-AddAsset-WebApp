using DomainClasses;
using System.Linq;

namespace DataLayer.Repositories
{
    public class MimeTypeRepository : Repository<MimeType>, IMimeTypeRepository
    {
        public MimeTypeRepository(AssetContext context)
            : base(context)
        {
        }

        public AssetContext AssetContext
        {
            get { return Context as AssetContext; }
        }

        public MimeType GetByMimeTypeName(string MimeTypeName)
        {
            return AssetContext.MimeTypes.FirstOrDefault(m => m.MimeTypeName == MimeTypeName);
        }
    }
}