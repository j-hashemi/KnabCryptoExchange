using System;
using System.Threading;
using System.Threading.Tasks;

namespace Exchange.Domain._Core
{
    public interface IUnitOfWork:IDisposable
    { 
        Task<bool> Commit(CancellationToken cancellationToken = default);
    }
}