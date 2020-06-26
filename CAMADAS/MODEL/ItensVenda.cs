using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpireVendas.CAMADAS.MODEL
{
    public class ItensVenda
    {
        public int id_item { get; set; }

        public int id_venda { get; set; }

        public int id_produto { get; set; }

        public float valor { get; set; }

        public string desc_produto { get; set; }

        public int quantidade { get; set; }


    }
}
