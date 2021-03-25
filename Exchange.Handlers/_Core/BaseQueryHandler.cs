using System;
using System.Threading;
using System.Threading.Tasks;
using Exchange.Command.Core;
using MediatR;

namespace Exchange.Handlers._Core
{
    public abstract class BaseQueryHandler<T,TOut>:IRequestHandler<T, TOut> where T : BaseQuery<TOut> where TOut:IQueryResponse,new()
    {
        public async Task<TOut> Handle(T request, CancellationToken cancellationToken)
        {
            try
            {

                var result = await Run(request, cancellationToken);
                
                Console.WriteLine($"Query({result.GetType().Name}) run successfully");
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                
                var result = new TOut();
                result.SetError(e.Message);
                return result;
            }
        }

        protected abstract Task<TOut> Run(T request,  CancellationToken cancellationToken);

    }
}