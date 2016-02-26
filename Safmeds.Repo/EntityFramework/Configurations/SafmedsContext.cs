using Safmeds.Repo.EntityFramework.Configurations;
using Safmeds.Repository;
using Safmeds.Repository.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safmeds.Repo.EntityFramework
{
    public class SafmedsContext : DbContext
    {
        public DbSet<Safmed> Safmeds { get; set; }
        public DbSet<SafmedSession> SafmedSessions { get; set; }

        public SafmedsContext() : base("name=SafmedsConnectionString")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<SafmedsContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new SafmedConfiguration());
            modelBuilder.Configurations.Add(new SafmedSessionConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }    
}
