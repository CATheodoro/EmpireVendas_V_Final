using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpireVendas.CAMADAS.BLL
{
    public class Categorias
    {
        public List<MODEL.Categorias> Select()
        {
            DAL.Categorias dalCategorias = new DAL.Categorias();
            ///... verificações e regras de negócios
            return dalCategorias.Select();
        }

        public void Insert(MODEL.Categorias categoria)
        {
            DAL.Categorias dalCategoria = new DAL.Categorias();
            // escrever regras de negócios

            dalCategoria.Insert(categoria);
        }

        public void Update(MODEL.Categorias categoria)
        {
            DAL.Categorias dalCategoria = new DAL.Categorias();
            // escrever regras de negócios

            dalCategoria.Update(categoria);
        }

        public void Delete(int idCat)
        {
            DAL.Categorias dalCategoria = new DAL.Categorias();
            // escrever regras de negócios
            if(idCat > 0) { 
            dalCategoria.Delete(idCat);
            }
        }

    }
}
