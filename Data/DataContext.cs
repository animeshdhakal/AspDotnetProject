using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using avengerapi.Models;
using Microsoft.EntityFrameworkCore;

namespace avengerapi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }



        public DbSet<Avenger> Avengers => Set<Avenger>();

    }
}