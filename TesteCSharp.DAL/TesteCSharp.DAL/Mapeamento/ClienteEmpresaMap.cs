using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TesteCSharp.BLL.Models;

namespace TesteCSharp.DAL.Mapeamento
{
    public class ClienteEmpresaMap : IEntityTypeConfiguration<ClienteEmpresa>
    {
        public void Configure(EntityTypeBuilder<ClienteEmpresa> builder)
        {
            builder.HasKey(c => c.ClienteEmpresaId);
            builder.Property(c => c.ClienteEmpresaId).ValueGeneratedOnAdd();

            builder.HasKey(sc => new { sc.EmpresaId, sc.ClienteId });

            builder.ToTable("ClienteEmpresa");

        }
    }
}
