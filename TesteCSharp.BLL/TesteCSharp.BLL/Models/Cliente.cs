using System;
using System.Collections.Generic;
using System.Text;

namespace TesteCSharp.BLL.Models
{
    public class Cliente
    {
        public long ClienteId { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; } 
        public string Email { get; set; }
        public DateTime DataCricao { get; set; }
        public ICollection<ClienteEmpresa> ClienteEmpresas { get; set; }
    }
}
