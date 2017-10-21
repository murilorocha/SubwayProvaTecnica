using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Subway.ProvaTecnica.Models;

namespace Subway.ProvaTecnica.Models
{
    public class SubwayProvaTecnicaContext : DbContext
    {
        public SubwayProvaTecnicaContext (DbContextOptions<SubwayProvaTecnicaContext> options)
            : base(options)
        {
        }

        public DbSet<Subway.ProvaTecnica.Models.Conta> Contas { get; set; }

        public DbSet<Subway.ProvaTecnica.Models.Compra> Compras { get; set; }
    }
}
