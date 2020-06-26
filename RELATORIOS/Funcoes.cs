using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpireVendas.RELATORIOS
{
    public class Funcoes
    {
        public static string deretorioPasta()
        {
            string pasta = @"c:\RELADS";
            if (!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }
            return pasta;
        }
    }
}
