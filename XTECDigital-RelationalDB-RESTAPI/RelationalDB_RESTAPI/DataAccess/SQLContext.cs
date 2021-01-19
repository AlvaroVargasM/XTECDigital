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
        /*
         *Description: Initialize a SQLContext with the connectionString named Server
         *Params: None
         *Output: None
        */
        public SQLContext() : base("Server") { 
            
        }
        public DbSet<Evaluations> evaluations { get; set; }
        public DbSet<Submissions> submissions { get; set; }
        /*
         *Description: Initializes the model builder that will indicate the configuration of the Model used by EntityFramework 6  
         *Params: DbModelBuilder
         *Output: None
        */
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
        /*
         *Description: Function to save any change in the SQL DB 
         *Params: None
         *Output: int
        */
        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }
}