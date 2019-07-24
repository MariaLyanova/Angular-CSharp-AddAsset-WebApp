using Autofac;

namespace DataLayer
{
    public class DataAutofacModule: Module
    {
        private string _connStr;

        public DataAutofacModule(string connString)
        {
            _connStr = connString;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AssetContext>().InstancePerRequest().WithParameter("connectionString", _connStr);
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();

            base.Load(builder);
        }
    }
}
