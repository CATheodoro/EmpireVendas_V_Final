using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpireVendas.CAMADAS.BLL
{
    public class Clientes
    {
        public List<MODEL.Clientes> Select()
        {
            DAL.Clientes dalClientes = new DAL.Clientes();
            ///... verificações e regras de negócios
            return dalClientes.Select();
        }

        public void Insert(MODEL.Clientes cliente)
        {
            DAL.Clientes dalCliente = new DAL.Clientes();
            // escrever regras de negócios
            dalCliente.Insert(cliente);
        }

        public void Update(MODEL.Clientes cliente)
        {
            DAL.Clientes dalCliente = new DAL.Clientes();
            // escrever regras de negócios

            dalCliente.Update(cliente);
        }

        public void Delete(int idCli)
        {
            DAL.Clientes dalCliente = new DAL.Clientes();
            // escrever regras de negócios
            if (idCli > 0)
            {
                dalCliente.Delete(idCli);
            }
        }
    }
}
