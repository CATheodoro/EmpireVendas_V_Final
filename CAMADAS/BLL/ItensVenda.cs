using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpireVendas.CAMADAS.BLL
{
    public class ItensVenda
    {
        public List<MODEL.ItensVenda> Select()
        {
            DAL.ItensVenda dalItens = new DAL.ItensVenda();
            ///... verificações e regras de negócios
            return dalItens.Select();
        }

        public void Insert(MODEL.ItensVenda itens)
        {
            DAL.ItensVenda dalVendas = new DAL.ItensVenda();

            dalVendas.Insert(itens);
        }
        public List<MODEL.ItensVenda> SelectEspelhoVenda(int id)
        {
            DAL.ItensVenda dalItens = new DAL.ItensVenda();
            ///... verificações e regras de negócios
            return dalItens.SelectEspelhoVenda(id);
        }

    }
}
