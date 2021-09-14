using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TesteCSharp.BLL.Models;

namespace TesteCSharp.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions dbContext) : base(dbContext)
        {

        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<ClienteEmpresa> ClienteEmpresas { get; set; }

    }
}
