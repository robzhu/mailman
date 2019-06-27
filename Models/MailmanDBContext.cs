using System.Data.Entity;

namespace Mailman.Models
{
    public class MailmanDBContext : DbContext
    {
        public MailmanDBContext() : base(DBConfig.GetConnectionString()) { }

        public DbSet<User> Users { get; set; }
        public DbSet<MailingList> MailingLists { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
            
        //}
    }
}