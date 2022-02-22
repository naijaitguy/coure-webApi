using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coureservices.Data.Models
{
  public class CoureServicesDbContext:DbContext
    {

        public CoureServicesDbContext(DbContextOptions<CoureServicesDbContext> context) : base(context)
        {

        }

        public DbSet<CountryDetails> countryDetails { get; set; }

        public DbSet<Country>  Countries { get; set; }

    }
}
