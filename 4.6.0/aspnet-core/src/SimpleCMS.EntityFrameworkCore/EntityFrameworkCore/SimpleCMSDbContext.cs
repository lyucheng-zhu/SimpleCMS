using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using SimpleCMS.Authorization.Roles;
using SimpleCMS.Authorization.Users;
using SimpleCMS.MultiTenancy;
using SimpleCMS.CMS;

namespace SimpleCMS.EntityFrameworkCore
{
    public class SimpleCMSDbContext : AbpZeroDbContext<Tenant, Role, User, SimpleCMSDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<CMSContent> CMSContents { get; set; }

        public SimpleCMSDbContext(DbContextOptions<SimpleCMSDbContext> options)
            : base(options)
        {
        }
    }
}
