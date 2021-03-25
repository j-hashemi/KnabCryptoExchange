using Autofac;
using Exchange.ExternalService;
using Exchange.Repository;

namespace Exchange.Web.Modules
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(BaseRepository<>).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
          
            builder.RegisterAssemblyTypes(typeof(IExternalService).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }

}