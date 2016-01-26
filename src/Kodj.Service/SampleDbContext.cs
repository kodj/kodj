using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Kodj.Service.Entities;
using Microsoft.Data.Sqlite;

namespace Kodj.Service
{
    public class SampleDbContext : DbContext
    {
        public DbSet<SampleEntity> SampleEntities { get; set; }
    }
}
