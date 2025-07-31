using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using SmartPoultry.Authorization.Roles;
using SmartPoultry.Authorization.Users;
using SmartPoultry.MultiTenancy;

namespace SmartPoultry.EntityFrameworkCore
{
    public class SmartPoultryDbContext : AbpZeroDbContext<Tenant, Role, User, SmartPoultryDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public SmartPoultryDbContext(DbContextOptions<SmartPoultryDbContext> options)
            : base(options)
        {
        }
    }
}
