using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpireVendas.CAMADAS.DAL
{
   public class Conexao
    {
        public static string getConexao()
        {
            //return @"Data Source=.\SQLEXPRESS;Initial Catalog=EMPIREVENDAS;Integrated Security=True"; //Conexão Ruan
            return @"Data Source=.\SQLEXPRESS03;Initial Catalog=EMPIREVENDAS;Integrated Security=True"; //Conexão Carlos
        }
    }
}
