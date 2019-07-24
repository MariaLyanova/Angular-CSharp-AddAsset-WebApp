using Autofac;
using Autofac.Integration.WebApi;
using DataLayer;
using System.Configuration;
using System.Reflection;

namespace AngularCSharp_AddAssetApp.App_Start
{
    public class AutofacConfig
    {
        public static IContainer ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            // Register Web API controllers
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // Register Data dependencies
            var connectionStringConfig = ConfigurationManager.ConnectionStrings["AssetContextConnection"].ConnectionString;
            builder.RegisterModule(new DataAutofacModule(connectionStringConfig));

            return builder.Build();
        }
    }
}