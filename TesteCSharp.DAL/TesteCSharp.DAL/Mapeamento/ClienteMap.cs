using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteCSharp.BLL.Models;

namespace TesteCSharp.DAL.Mapeamento
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.ClienteId);
            builder.Property(c => c.ClienteId).ValueGeneratedOnAdd();

            builder.Property(c => c.CPF).IsRequired().HasMaxLength(11);
            builder.HasIndex(c => c.CPF).IsUnique();
            builder.Property(c => c.Nome).IsRequired().HasMaxLength(200);
            builder.Property(c => c.Email).IsRequired().HasMaxLength(150);
          
            builder.ToTable("Clientes");

        }
    }
}
