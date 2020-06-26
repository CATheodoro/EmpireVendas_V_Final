using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpireVendas.CAMADAS.MODEL
{
    public class Vendas
    {
        public int id_venda { get; set; }
        // public float valor { get; set; }
        public float desconto { get; set; }
        public float valor_final { get; set; }
        public int id_vendedor { get; set; }
        public int id_cliente { get; set; }
        public DateTime data { get; set; }
        public string desc_vendedor { get; set; }
        public string desc_cliente { get; set; }
    }
}
