using RelationalDB_RESTAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace RelationalDB_RESTAPI.DataAccess
{
    public class SQLContext : DbContext
    {
        public SQLContext() : base("Server") { 
            
        }
        public DbSet<Evaluations> evaluations { get; set; }
        public DbSet<Submissions> submissions { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }
}