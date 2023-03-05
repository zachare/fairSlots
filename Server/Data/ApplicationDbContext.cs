using Duende.IdentityServer.EntityFramework.Options;
using fairSlots.Server.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

// Default DbContext used for Individual Account User Authentication
namespace fairSlots.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Applies custom Role class to the default tables
            builder.ApplyConfiguration(new RoleConfiguration());
        }

    }
}