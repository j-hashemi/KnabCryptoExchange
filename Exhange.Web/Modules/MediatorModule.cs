using System.Linq;
using Autofac;
using Autofac.Core;
using Exchange.Command.Core;
using Exchange.Handlers._Core;
using MediatR;

namespace Exchange.Web.Modules
{
    public class MediatorModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IMediator).Assembly)
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(typeof(BaseRequest<>).Assembly)
                .As(o => o.GetInterfaces()
                    .Where(i => i.IsSubclassOf(typeof(BaseRequestHandler<,>)))
                    .Select(i => new KeyedService("IRequestHandler", i)));
            
            builder.RegisterAssemblyTypes(typeof(BaseQuery<>).Assembly)
                .As(o => o.GetInterfaces()
                    .Where(i => i.IsSubclassOf(typeof(BaseQueryHandler<,>)))
                    .Select(i => new KeyedService("IRequestHandler", i)));

        }
    }
}