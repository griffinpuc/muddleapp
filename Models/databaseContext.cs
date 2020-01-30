using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace muddleapp.Models
{
    public class databaseContext : DbContext
    {
        public databaseContext(DbContextOptions options)
            : base(options)
        {
        }

        public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<databaseContext>
        {
            public databaseContext CreateDbContext(string[] args)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                var builder = new DbContextOptionsBuilder<databaseContext>();
                var connectionString = configuration.GetConnectionString("dbConnection");
                builder.UseSqlServer(connectionString);
                return new databaseContext(builder.Options);
            }
        }

        public DbSet<Hit> hitsTable { get; set; }

        public void AddEntry(object obj)
        {
            Add(obj);
            SaveChanges();
        }

        /* Remove entry */
        public void RemoveEntry(object obj)
        {
            Remove(obj);
            SaveChanges();
        }

        /* Modify entry */
        public void UpdateEntry(object obj)
        {
            Update(obj);
            SaveChanges();
        }

        public Boolean containsDrinkHit(string idDrink)
        {
            if ((from Hit in hitsTable where Hit.idDrink.Equals(idDrink) select Hit).ToList().ToArray().Length == 0) { return false; }
            else { return true; }
        }

        public Hit getHit(string idDrink)
        {
            return (from Hit in hitsTable where Hit.idDrink.Equals(idDrink) select Hit).ToList().ToArray()[0];
        }
    }
}
