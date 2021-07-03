using DbConection.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbConection.Context
{
    public class AirportContext : DbContext
    {
        public DbSet<DBUser> Users { get; set; }
        public DbSet<DBPlane> Planes { get; set; }
        public DbSet<DBPassanger> Passangers { get; set; }

        public AirportContext() 
            : base("AirportDB")
        {

        }
    }
}
