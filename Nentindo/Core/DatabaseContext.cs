using Microsoft.EntityFrameworkCore;
using Nentindo.Core.Domain.Companies;
using Nentindo.Core.Domain.Contacts;
using Nentindo.Core.Domain.Newsletters;
using Nentindo.Core.Domain.Users;
using Nentindo.Core.Domain.Subscriptions;


/// add-migration firt
/// update-database
namespace Nentindo.Data
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
           : base(options)
        {

        }
        public DbSet<User> Users { get; set;}
        public DbSet<Role> Roles { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Subcontractor> Subcontractors { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Newsletter> Newsletters { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }

     
    }
}
