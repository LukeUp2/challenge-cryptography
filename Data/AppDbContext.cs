using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_Criptografia.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Desafio_Criptografia.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<UserPayment> UserPayments { get; set; }
    }
}