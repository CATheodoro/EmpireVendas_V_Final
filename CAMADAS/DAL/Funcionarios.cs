using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Runtime.InteropServices;

namespace EmpireVendas.CAMADAS.DAL
{
    public class Funcionarios
    {
        private string strCon = Conexao.getConexao();

        public List<MODEL.Funcionarios> Select()
        {
            List<MODEL.Funcionarios> lstFuncionarios = new List<MODEL.Funcionarios>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "SELECT * FROM tb_funcionarios;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            try
            {
                conexao.Open();
                SqlDataReader dados = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dados.Read())
                {
                    MODEL.Funcionarios funcionario = new MODEL.Funcionarios();
                    funcionario.id_vendedor = Convert.ToInt32(dados["id_vendedor"].ToString());
                    //funcionario.usuario = dados["usuario"].ToString();
                    //funcionario.senha = dados["senha"].ToString();
                    funcionario.nome_vendedor = dados["nome_vendedor"].ToString();
                    funcionario.endereco = dados["endereco"].ToString();
                    funcionario.numero = Convert.ToInt32(dados["numero"].ToString());
                    funcionario.cidade = dados["cidade"].ToString();
                    funcionario.email = dados["email"].ToString();

                    lstFuncionarios.Add(funcionario);
                }
            }
            catch
            {
                Console.WriteLine("Deu erro na consulta de Categorias...");
            }
            finally
            {
                conexao.Close();
            }

            return lstFuncionarios;
        }

        public void Insert(MODEL.Funcionarios funcionarios)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "INSERT INTO tb_funcionarios VALUES (@nome_vendedor, @endereco, @numero, @cidade, @email);";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            //cmd.Parameters.AddWithValue("@usuario", funcionarios.usuario);
            //cmd.Parameters.AddWithValue("@senha", funcionarios.senha);
            cmd.Parameters.AddWithValue("@nome_vendedor", funcionarios.nome_vendedor);
            cmd.Parameters.AddWithValue("@endereco", funcionarios.endereco);
            cmd.Parameters.AddWithValue("@numero", funcionarios.numero);
            cmd.Parameters.AddWithValue("@cidade", funcionarios.cidade);
            cmd.Parameters.AddWithValue("@email", funcionarios.email);
            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na inclusão de funcionarios...");
            }
            finally
            {
                conexao.Close();
            }

        }


        public void Update(MODEL.Funcionarios funcionario)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "UPDATE tb_funcionarios SET nome_vendedor=@nome_vendedor, endereco=@endereco, numero=@numero, cidade=@cidade, email=@email WHERE id_vendedor=@id_vendedor;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id_vendedor", funcionario.id_vendedor);
            cmd.Parameters.AddWithValue("@nome_vendedor", funcionario.nome_vendedor);
            cmd.Parameters.AddWithValue("@endereco", funcionario.endereco);
            cmd.Parameters.AddWithValue("@numero", funcionario.numero);
            cmd.Parameters.AddWithValue("@cidade", funcionario.cidade);
            cmd.Parameters.AddWithValue("@email", funcionario.email);

            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na alteração de Funcionarios...");
            }
            finally
            {
                conexao.Close();
            }
        }

        public void Delete(int idFun)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "DELETE FROM tb_funcionarios WHERE id_vendedor=@id_vendedor;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id_vendedor", idFun);

            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na remoção de Funcionario...");
            }
            finally
            {
                conexao.Close();
            }

        }

    }
}
