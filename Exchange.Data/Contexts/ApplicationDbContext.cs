using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Exchange.Domain._Core;
using Exchange.Domain.Entity;
using Exchange.Domain.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Exchange.Data.Contexts
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IUnitOfWork
    {
        
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            RegisterAllEntities(builder);

            base.OnModelCreating(builder);
        }

        private static void RegisterAllEntities(ModelBuilder builder)
        {
            var types = typeof(BusinessEntity).Assembly.GetTypes().Where(c =>
                c.IsClass && !c.IsAbstract && c.IsPublic && c.IsSubclassOf(typeof(BusinessEntity)));
            
            foreach (var type in types)
                builder.Entity(type).ToTable(type.Name);
        }

        public async Task<bool> Commit(CancellationToken cancellationToken = default)
        {
            await SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
