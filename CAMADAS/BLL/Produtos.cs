using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpireVendas.CAMADAS.BLL
{
    public class Produtos
    {
        public List<MODEL.Produtos> Select()
        {
            DAL.Produtos dalProdutos = new DAL.Produtos();
            ///... verificações e regras de negócios
            return dalProdutos.Select();
        }

        public void Insert(MODEL.Produtos produto)
        {
            DAL.Produtos dalProduto = new DAL.Produtos();
            // escrever regras de negócios

            dalProduto.Insert(produto);
        }

        public void Update(MODEL.Produtos produto)
        {
            DAL.Produtos dalProduto = new DAL.Produtos();
            //.regras de negócios
            dalProduto.Update(produto);
        }

        public void Delete(int idProduto)
        {
            DAL.Produtos dalProduto = new DAL.Produtos();
            // regras de negócio 
            if (idProduto> 0)
                 dalProduto.Delete(idProduto);

        }

        public List<MODEL.Produtos> SelectByID(int id)
        {
            DAL.Produtos dalProduto = new DAL.Produtos();
            ///... verificações e regras de negócios
            return dalProduto.SelectByID(id);
        }

        public float SelectPrecoByID(int id)
        {
            DAL.Produtos dalProduto = new DAL.Produtos();
            ///... verificações e regras de negócios
            return dalProduto.SelectPrecoByID(id);
        }

        public List<MODEL.Produtos> SelectByNome(string nome)
        {
            DAL.Produtos dalProduto = new DAL.Produtos();
            ///... verificações e regras de negócios
            return dalProduto.SelectByNome(nome);
        }

        public List<MODEL.Produtos> SelectWithCategoria()
        {
            DAL.Produtos dalProdutos = new DAL.Produtos();
            ///... verificações e regras de negócios
            return dalProdutos.SelectWithCategoria();
        }
    }


}
