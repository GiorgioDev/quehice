using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using QueHice.Authorization.Roles;
using QueHice.Authorization.Users;
using QueHice.MultiTenancy;

namespace QueHice.EntityFrameworkCore
{
    public class QueHiceDbContext : AbpZeroDbContext<Tenant, Role, User, QueHiceDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public QueHiceDbContext(DbContextOptions<QueHiceDbContext> options)
            : base(options)
        {
        }
    }
}
