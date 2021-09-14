using System;
using System.Collections.Generic;
using System.Text;

namespace TesteCSharp.BLL.Models
{
    public class ClienteEmpresa
    {
        public long ClienteEmpresaId { get; set; }

        public long ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public long EmpresaId { get; set; }
        public Empresa Empresa { get; set; }

    }
}
