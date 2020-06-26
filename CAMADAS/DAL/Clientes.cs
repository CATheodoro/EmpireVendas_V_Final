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
    public class Clientes
    {
        private string strCon = Conexao.getConexao();

        public List<MODEL.Clientes> Select()
        {
            List<MODEL.Clientes> lstClientes = new List<MODEL.Clientes>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "SELECT * FROM tb_clientes;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            try
            {
                conexao.Open();
                SqlDataReader dados = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dados.Read())
                {
                    MODEL.Clientes cliente = new MODEL.Clientes();
                    cliente.id_cliente = Convert.ToInt32(dados["id_cliente"].ToString());
                    cliente.nome = dados["nome"].ToString();
                    cliente.endereco = dados["endereco"].ToString();
                    cliente.numero = Convert.ToInt32(dados["numero"].ToString());
                    cliente.cidade = dados["cidade"].ToString();
                    cliente.email = dados["email"].ToString();
                    cliente.cpf = dados["cpf"].ToString();
                    lstClientes.Add(cliente);
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

            return lstClientes;
        }

        public void Insert(MODEL.Clientes clientes)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "INSERT INTO tb_clientes VALUES (@nome, @endereco, @numero, @cidade, @email, @cpf);";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@nome", clientes.nome);
            cmd.Parameters.AddWithValue("@endereco", clientes.endereco);
            cmd.Parameters.AddWithValue("@numero", clientes.numero);
            cmd.Parameters.AddWithValue("@cidade", clientes.cidade);
            cmd.Parameters.AddWithValue("@email", clientes.email);
            cmd.Parameters.AddWithValue("@cpf", clientes.cpf);
            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na inclusão de Produtos...");
            }
            finally
            {
                conexao.Close();
            }

        }

        public void Update(MODEL.Clientes cliente)
        {


            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "UPDATE tb_clientes SET nome=@nome, endereco=@endereco, numero=@numero, cidade=@cidade, email=@email, cpf=@cpf WHERE id_cliente=@id_cliente;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id_cliente", cliente.id_cliente);
            cmd.Parameters.AddWithValue("@nome", cliente.nome);
            cmd.Parameters.AddWithValue("@endereco", cliente.endereco);
            cmd.Parameters.AddWithValue("@numero", cliente.numero);
            cmd.Parameters.AddWithValue("@cidade", cliente.cidade);
            cmd.Parameters.AddWithValue("@email", cliente.email);
            cmd.Parameters.AddWithValue("@cpf", cliente.cpf);

            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na alteração de Clientes...");
            }
            finally
            {
                conexao.Close();
            }
        }

        public void Delete(int idCli)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "DELETE FROM tb_clientes WHERE id_cliente=@id_cliente;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id_cliente", idCli);

            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na remoção de Categorias...");
            }
            finally
            {
                conexao.Close();
            }

        }

    }
}
