using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TesteCSharp.BLL.Models;

namespace TesteCSharp.DAL.Mapeamento
{
    public class EmpresaMap : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.HasKey(e => e.EmpresaId);
            builder.Property(e => e.EmpresaId).ValueGeneratedOnAdd();

            builder.Property(e => e.CNPJ).IsRequired().HasMaxLength(15);

            builder.Property(e => e.RazaoSocial).IsRequired().HasMaxLength(150);

            builder.HasData(
                new Empresa
                {
                    EmpresaId= 1,
                    CNPJ = "001851771000155",
                    RazaoSocial = "524 PARTICIPACOES S.A."
                },
                new Empresa
                {
                    EmpresaId = 2,
                    CNPJ = "012528708000107",
                    RazaoSocial = "AERIS IND. E COM. DE EQUIP. GERACAO DE ENERGIA S/A"
                },
                new Empresa
                {
                    EmpresaId = 3,
                    CNPJ = "037663076000107",
                    RazaoSocial = "AES BRASIL ENERGIA S.A"
                }
            );
            builder.ToTable("Empresas");                
        }
    }
}
