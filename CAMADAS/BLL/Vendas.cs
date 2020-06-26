using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace EmpireVendas.CAMADAS.BLL
{
   public class Vendas
    {
        public void BaixaEstoque(MODEL.Produtos produto)
        {
            DAL.Vendas dalProduto = new DAL.Vendas();
            //.regras de negócios
            dalProduto.BaixaEstoque(produto);
        }

        public void EfetivarVenda(MODEL.Vendas venda)
        {
            DAL.Vendas dalVenda = new DAL.Vendas();
            // escrever regras de negócios

            dalVenda.EfetivarVenda(venda);
        }

        public int SelectID()
        {
            DAL.Vendas dalVendasID = new DAL.Vendas();

            return dalVendasID.SelectID();
        }

        public List<MODEL.Vendas> Select()
        {
            DAL.Vendas dalVendas = new DAL.Vendas();
            ///... verificações e regras de negócios
            return dalVendas.Select();
        }

        public List<MODEL.Vendas> SelectWithInnerJoin()
        {
            DAL.Vendas dalVendas = new DAL.Vendas();
            ///... verificações e regras de negócios
            return dalVendas.SelectWithInnerJoin();
        }

        public List<MODEL.Vendas> SelectWithInnerJoinById(int id)
        {
            DAL.Vendas dalVendas = new DAL.Vendas();
            ///... verificações e regras de negócios
            return dalVendas.SelectWithInnerJoinById(id);
        }



        public List<MODEL.Vendas> SelectWithInnerJoinByName(string nome)
        {
            DAL.Vendas dalVendas = new DAL.Vendas();
            ///... verificações e regras de negócios
            return dalVendas.SelectWithInnerJoinByName(nome);
        }
    }
}
