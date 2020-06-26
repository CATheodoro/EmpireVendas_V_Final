using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpireVendas.CAMADAS.MODEL
{
    public class Produtos
    {
        public int id_produto { get; set; }
        public string desc_produto { get; set; }
        public float valor { get; set; }
        public int idCategoria { get; set; }
        public int estoque { get; set; }
        public string desc_categoria { get; set; }



    }
}
