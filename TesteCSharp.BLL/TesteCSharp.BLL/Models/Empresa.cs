using System;
using System.Collections.Generic;
using System.Text;

namespace TesteCSharp.BLL.Models
{
    public class Empresa
    {
        public long EmpresaId { get; set; }
        public string CNPJ { get; set; }
        public string RazaoSocial { get; set; }
        public ICollection<ClienteEmpresa> ClienteEmpresas { get; set; }
    }
}
