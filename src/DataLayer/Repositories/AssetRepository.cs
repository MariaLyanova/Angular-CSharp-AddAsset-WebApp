using DomainClasses;
using System;
using System.Linq;
using System.Data.Entity;

namespace DataLayer.Repositories
{
    public class AssetRepository : Repository<Asset>
    {
        public AssetRepository(AssetContext context)
            : base(context)
        {
        }

        public AssetContext AssetContext
        {
            get { return Context as AssetContext; }
        }

        public override Asset Get(Guid id)
        {
            return AssetContext.Assets
                .Include(a => a.Country).Include(a => a.MimeType)
                .FirstOrDefault(a => a.AssetId == id);
        }
    }
}