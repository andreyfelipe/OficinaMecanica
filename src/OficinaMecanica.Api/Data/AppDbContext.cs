using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OficinaMecanica.Api.Models;

namespace OficinaMecanica.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Orcamento> Orcamentos { get; set; } = null!;
        public DbSet<OrcamentoItem> OrcamentoItems { get; set; } = null!;
    }   
  
}