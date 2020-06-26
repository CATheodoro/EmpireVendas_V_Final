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
    
    public class Vendas
    {
        private string strCon = Conexao.getConexao();


        public void BaixaEstoque(MODEL.Produtos produto)
        {

            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "UPDATE tb_produtos SET estoque = estoque-@estoque WHERE id_produto=@id_produto;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@estoque", produto.estoque);
            cmd.Parameters.AddWithValue("@id_produto", produto.id_produto);

            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na alteração de Categorias...");
            }
            finally
            {
                conexao.Close();
            }
        }

        public void EfetivarVenda(MODEL.Vendas venda)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "INSERT INTO tb_vendas (desconto,valor_final,id_vendedor,id_cliente,data) VALUES (@desconto, @valor_final, @id_vendedor, @id_cliente,@data);";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@desconto", venda.desconto);
            cmd.Parameters.AddWithValue("@valor_final", venda.valor_final);
            cmd.Parameters.AddWithValue("@id_vendedor", venda.id_vendedor);
            cmd.Parameters.AddWithValue("@id_cliente", venda.id_cliente);
            cmd.Parameters.AddWithValue("@data", venda.data);
            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na efetivação da venda...");
            }
            finally
            {
                conexao.Close();
            }

        }

        public List<MODEL.Vendas> Select()
        {
            List<MODEL.Vendas> lstVendas = new List<MODEL.Vendas>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "select * from tb_vendas; ";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            try
            {
                conexao.Open();
                SqlDataReader dados = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dados.Read())
                {
                    MODEL.Vendas venda = new MODEL.Vendas();
                    venda.id_venda = Convert.ToInt32(dados["id_venda"].ToString());
                    venda.desconto = Convert.ToSingle(dados["desconto"].ToString());
                    venda.valor_final = Convert.ToSingle(dados["valor_final"].ToString());
                    venda.id_vendedor = Convert.ToInt32(dados["id_vendedor"].ToString());
                    venda.id_cliente = Convert.ToInt32(dados["id_cliente"].ToString());
                    venda.data = Convert.ToDateTime(dados["data"].ToString());
                    lstVendas.Add(venda);


                }
            }
            catch
            {
                Console.WriteLine("Deu erro na consulta de Vendas...");
            }
            finally
            {
                conexao.Close();
            }

            return lstVendas;
        }

        public List<MODEL.Vendas> SelectWithInnerJoin()
        {
            List<MODEL.Vendas> lstVendas = new List<MODEL.Vendas>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "SELECT v.id_venda, v.desconto, v.valor_final, v.data, f.nome_vendedor, c.nome FROM tb_vendas v " +
                         "INNER JOIN tb_clientes c ON v.id_cliente = c.id_cliente " +
                         "INNER JOIN tb_funcionarios f on v.id_vendedor = f.id_vendedor; ";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            try
            {
                conexao.Open();
                SqlDataReader dados = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dados.Read())
                {
                    MODEL.Vendas venda = new MODEL.Vendas();
                    venda.id_venda = Convert.ToInt32(dados["id_venda"].ToString());
                    venda.desconto = Convert.ToSingle(dados["desconto"].ToString());
                    venda.valor_final = Convert.ToSingle(dados["valor_final"].ToString());
                    //venda.id_vendedor = Convert.ToInt32(dados["id_vendedor"].ToString());
                    //venda.id_cliente = Convert.ToInt32(dados["id_cliente"].ToString());
                    venda.data = Convert.ToDateTime(dados["data"].ToString());

                    venda.desc_vendedor = Convert.ToString(dados["nome_vendedor"].ToString());
                    venda.desc_cliente = Convert.ToString(dados["nome"].ToString());
                    lstVendas.Add(venda);


                }
            }
            catch
            {
                Console.WriteLine("Deu erro na consulta de Vendas...");
            }
            finally
            {
                conexao.Close();
            }

            return lstVendas;
        }

        public int SelectID()
        {

            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "select TOP 1 id_venda from tb_vendas order by id_venda desc; ";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            int id = 0;
            try
            {
                conexao.Open();
                SqlDataReader dados = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dados.Read())
                {
                    MODEL.Vendas venda = new MODEL.Vendas();
                    venda.id_venda = Convert.ToInt32(dados["id_venda"].ToString());
                    id = venda.id_venda;
                }
            }
            catch
            {
                Console.WriteLine("Deu erro na consulta de VendasID...");
            }
            finally
            {
                conexao.Close();
            }

            return id;
        }

        public List<MODEL.Vendas> SelectWithInnerJoinById(int id)
        {
            List<MODEL.Vendas> lstVendas = new List<MODEL.Vendas>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "SELECT v.id_venda, v.desconto, v.valor_final, v.data, f.nome_vendedor, c.nome FROM tb_vendas v " +
                         "INNER JOIN tb_clientes c ON v.id_cliente = c.id_cliente " +
                         "INNER JOIN tb_funcionarios f on v.id_vendedor = f.id_vendedor WHERE v.id_venda =  @id";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id",id);
            try
            {
                conexao.Open();
                SqlDataReader dados = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dados.Read())
                {
                    MODEL.Vendas venda = new MODEL.Vendas();
                    venda.id_venda = Convert.ToInt32(dados["id_venda"].ToString());
                    venda.desconto = Convert.ToSingle(dados["desconto"].ToString());
                    venda.valor_final = Convert.ToSingle(dados["valor_final"].ToString());
                    //venda.id_vendedor = Convert.ToInt32(dados["id_vendedor"].ToString());
                    //venda.id_cliente = Convert.ToInt32(dados["id_cliente"].ToString());
                    venda.data = Convert.ToDateTime(dados["data"].ToString());

                    venda.desc_vendedor = Convert.ToString(dados["nome_vendedor"].ToString());
                    venda.desc_cliente = Convert.ToString(dados["nome"].ToString());
                    lstVendas.Add(venda);


                }
            }
            catch
            {
                Console.WriteLine("Deu erro na consulta de Vendas...");
            }
            finally
            {
                conexao.Close();
            }

            return lstVendas;
        }

        public List<MODEL.Vendas> SelectWithInnerJoinByName(string nome)
        {
            List<MODEL.Vendas> lstVendas = new List<MODEL.Vendas>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "SELECT v.id_venda, v.desconto, v.valor_final, v.data, f.nome_vendedor, c.nome FROM tb_vendas v " +
                         "INNER JOIN tb_clientes c ON v.id_cliente = c.id_cliente " +
                         "INNER JOIN tb_funcionarios f on v.id_vendedor = f.id_vendedor where (c.nome LIKE @nome); ";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@nome", "%" + nome.Trim() + "%");
            try
            {
                conexao.Open();
                SqlDataReader dados = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dados.Read())
                {
                    MODEL.Vendas venda = new MODEL.Vendas();
                    venda.id_venda = Convert.ToInt32(dados["id_venda"].ToString());
                    venda.desconto = Convert.ToSingle(dados["desconto"].ToString());
                    venda.valor_final = Convert.ToSingle(dados["valor_final"].ToString());
                    //venda.id_vendedor = Convert.ToInt32(dados["id_vendedor"].ToString());
                    //venda.id_cliente = Convert.ToInt32(dados["id_cliente"].ToString());
                    venda.data = Convert.ToDateTime(dados["data"].ToString());

                    venda.desc_vendedor = Convert.ToString(dados["nome_vendedor"].ToString());
                    venda.desc_cliente = Convert.ToString(dados["nome"].ToString());
                    lstVendas.Add(venda);


                }
            }
            catch
            {
                Console.WriteLine("Deu erro na consulta de Vendas...");
            }
            finally
            {
                conexao.Close();
            }

            return lstVendas;
        }
    }
}
