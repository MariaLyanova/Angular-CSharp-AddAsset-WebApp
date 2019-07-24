using DomainClasses;
using System.Collections.Generic;
using System.Data.Entity;

namespace DataLayer
{
    public class AssetInitializer : DropCreateDatabaseAlways<AssetContext>
    {
        protected override void Seed(AssetContext context)
        {
            new List<Asset>{
                new Asset {
                    AssetId = new System.Guid("91df6a98-614e-40ef-8885-95ae50940058"),
                    FileName = "ElitProin.aam",
                    CreatedBy ="sblack0",
                    Country = new Country { CountryName = "United States" },
                    Email = "jmitchell0@huffingtonpost.com",
                    MimeType = new MimeType { MimeTypeName ="application/x-authorware-map"},
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."
                },
                new Asset {
                    AssetId = new System.Guid("189899c1-bc63-495c-94c5-57f25c881ed2"),
                    FileName = "MusVivamusVestibulum.xla",
                    CreatedBy = "iadams1",
                    Email = "rhenry1@xrea.com",
                    Country = new Country { CountryName = "Canada" },
                    MimeType = new MimeType { MimeTypeName ="application/x-excel"},
                    Description = "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat."
                }
            }.ForEach(entry => context.Assets.Add(entry));
            context.SaveChanges();
        }
    }
}