using System.Collections.Generic;
using MediatR;

namespace Exchange.Command.Core
{
    public abstract class BaseQuery<T> : IRequest<T> where T:IQueryResponse
    {
        public int Skip { get; set; }
        public int Take { get; set; }

        public BaseQuery()
        {
            Skip = 0;
            Take = 10;
        }

    }

    public interface IQueryResponse
    {
        
        public bool Succeed { get;  }
        public string Error { get;  }
        void SetError(string errorMessage);
    }

    public class BaseSingleQueryResponse<TResult>:IQueryResponse where TResult:class,new()
    {
        public BaseSingleQueryResponse()
        {
            Succeed = true;
        }
        public TResult Entity { get; set; }
        public bool Succeed { get; set; }
        public string Error { get; set; }
        public void SetError(string errorMessage)
        {
            Succeed = false;
            Error = errorMessage;
        }
    }

    public class BaseQueryResponse<TResult> : IQueryResponse where TResult :class,new()
    {
        public BaseQueryResponse()
        {
            Succeed = true;
        }
        public List<TResult> Entities { get; set; }
        public int TotalCount { get; set; }
        public bool Succeed { get; set; }
        public string Error { get; set; }
        public void SetError(string errorMessage)
        {
            Succeed = false;
            Error = errorMessage;
        }
    }

}