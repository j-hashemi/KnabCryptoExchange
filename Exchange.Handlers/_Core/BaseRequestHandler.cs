using System;
using System.Threading;
using System.Threading.Tasks;
using Exchange.Command.Core;
using MediatR;

namespace Exchange.Handlers._Core
{
    public abstract class BaseRequestHandler<T, TOut> : IRequestHandler<T, TOut>
        where T : BaseRequest<TOut> where TOut : BaseResponse, new()

    {
        public async Task<TOut> Handle(T request, CancellationToken cancellationToken)
        {

            try
            {
                //TODO: I Should Add Audit log here
                Console.WriteLine($"Before Command({typeof(T).Name}) Start");
                
                var result = await Execute(request, cancellationToken);
                
                Console.WriteLine($"Command({typeof(T).Name}) Executed Successfully");
                
                return result;
            }
            catch (Exception e)
            {
                
                Console.WriteLine(e);
                return new TOut
                {
                    ErrorMessage = e.Message,
                    Succeed = false
                };
            }
        }

        protected abstract Task<TOut> Execute(T request, CancellationToken cancellationToken);

    }
}