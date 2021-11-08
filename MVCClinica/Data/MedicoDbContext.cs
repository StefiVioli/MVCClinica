using MVCClinica.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCClinica.Data
{
    public class MedicoDbContext : DbContext
    {
        public MedicoDbContext() : base("KeyDB") { }
        public DbSet<Medico> Medicos { get; set; }
    }


}