using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpireVendas.CAMADAS.BLL
{
    public class Funcionarios
    {
        public List<MODEL.Funcionarios> Select()
        {
            DAL.Funcionarios dalFuncionarios = new DAL.Funcionarios();
            ///... verificações e regras de negócios
            return dalFuncionarios.Select();
        }

        public void Insert(MODEL.Funcionarios funcionario)
        {
            DAL.Funcionarios dalFuncionario = new DAL.Funcionarios();
            // escrever regras de negócios
            dalFuncionario.Insert(funcionario);
        }

        public void Update(MODEL.Funcionarios funcionario)
        {
            DAL.Funcionarios dalFuncionaro = new DAL.Funcionarios();
            //.regras de negócios
            dalFuncionaro.Update(funcionario);
        }

        public void Delete(int idFuncionario)
        {
            DAL.Funcionarios dalFuncionario = new DAL.Funcionarios();
            // regras de negócio 
            if (idFuncionario > 0)
                dalFuncionario.Delete(idFuncionario);
        }
    }
}
