using MediatR;

namespace Exchange.Command.Core
{
    public class BaseRequest<T>:IRequest<T> where T:BaseResponse
    {

    }
}