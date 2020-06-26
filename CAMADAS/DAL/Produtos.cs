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
    public class Produtos
    {
        private string strCon = Conexao.getConexao();

        public List<MODEL.Produtos> Select()
        {
            List<MODEL.Produtos> lstProdutos = new List<MODEL.Produtos>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "SELECT * FROM tb_produtos INNER JOIN tb_categorias ON tb_produtos.id_categoria = tb_categorias.id_categoria;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            try
            {
                conexao.Open();
                SqlDataReader dados = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dados.Read())
                {
                    MODEL.Produtos produto = new MODEL.Produtos();
                    produto.id_produto = Convert.ToInt32(dados["id_produto"].ToString());
                    produto.desc_produto = dados["desc_produto"].ToString();
                    produto.valor = Convert.ToSingle(dados["valor"].ToString());
                    produto.idCategoria = Convert.ToInt32(dados["id_categoria"].ToString());
                    produto.desc_categoria = dados["desc_categoria"].ToString();
                    produto.estoque = Convert.ToInt32(dados["estoque"].ToString());
                    lstProdutos.Add(produto);
                }
            }
            catch
            {
                Console.WriteLine("Deu erro na consulta de Produtos...");
            }
            finally
            {
                conexao.Close();
            }

            return lstProdutos;
        }

        public void Insert(MODEL.Produtos produto)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "INSERT INTO tb_produtos VALUES (@desc_produto, @valor, @idCategoria, @estoque);";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@desc_produto", produto.desc_produto);
            cmd.Parameters.AddWithValue("@valor",produto.valor);
            cmd.Parameters.AddWithValue("@idCategoria", produto.idCategoria);
            cmd.Parameters.AddWithValue("@estoque",produto.estoque);
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

        public void Update(MODEL.Produtos produto)
        {


            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "UPDATE tb_produtos SET desc_produto=@desc_produto,valor=@valor,id_categoria=@id_categoria,estoque=@estoque WHERE id_produto=@id_produto;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id_produto", produto.id_produto);
            cmd.Parameters.AddWithValue("@desc_produto", produto.desc_produto);
            cmd.Parameters.AddWithValue("@valor", produto.valor);
            cmd.Parameters.AddWithValue("@id_categoria", produto.idCategoria);
            cmd.Parameters.AddWithValue("@estoque", produto.estoque);
            
            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na alteração de Produtos...");
            }
            finally
            {
                conexao.Close();
            }
        }

        public void Delete(int idProd)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "DELETE FROM tb_produtos WHERE id_produto=@id_produto;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id_produto", idProd);

            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na remoção de Produtos...");
            }
            finally
            {
                conexao.Close();
            }

        }

        public List<MODEL.Produtos> SelectByID(int id)
        {
            List<MODEL.Produtos> lstProdutos= new List<MODEL.Produtos>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "SELECT * FROM tb_produtos INNER JOIN tb_categorias ON id_produto=@id_produto AND tb_produtos.id_categoria = tb_categorias.id_categoria;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id_produto", id);
            try
            {
                conexao.Open();
                SqlDataReader dados = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dados.Read())
                {
                    MODEL.Produtos produto = new MODEL.Produtos();
                    produto.id_produto = Convert.ToInt32(dados["id_produto"].ToString());
                    produto.desc_produto = dados["desc_produto"].ToString();
                    produto.valor = Convert.ToSingle(dados["valor"].ToString());
                    produto.idCategoria = Convert.ToInt32(dados["id_categoria"].ToString());
                    produto.desc_categoria = dados["desc_categoria"].ToString();
                    produto.estoque = Convert.ToInt32(dados["estoque"].ToString());
                    lstProdutos.Add(produto);
                }
            }
            catch
            {
                Console.WriteLine("Erro na consulta de Produtos...");
            }
            finally
            {
                conexao.Close();
            }
            return lstProdutos;
        }

        public float SelectPrecoByID(int id)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "SELECT * FROM tb_produtos INNER JOIN tb_categorias ON id_produto=@id_produto AND tb_produtos.id_categoria = tb_categorias.id_categoria;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id_produto", id);
            float valor = 0;
            try
            {
                conexao.Open();
                SqlDataReader dados = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dados.Read())
                {
                    MODEL.Produtos produto = new MODEL.Produtos();
                    produto.valor = Convert.ToSingle(dados["valor"].ToString());
                    valor = produto.valor;
                }
            }
            catch
            {
                Console.WriteLine("Erro na consulta de Produtos...");
            }
            finally
            {
                conexao.Close();
            }
            return valor;
        }

        public List<MODEL.Produtos> SelectByNome(string nome)
        {
            List<MODEL.Produtos> lstProdutos = new List<MODEL.Produtos>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "SELECT * FROM tb_produtos  WHERE (desc_produto LIKE @desc_produto);";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@desc_produto", "%" + nome.Trim() + "%");
            try
            {
                conexao.Open();
                SqlDataReader dados = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dados.Read())
                {
                    MODEL.Produtos produto = new MODEL.Produtos();
                    produto.id_produto = Convert.ToInt32(dados["id_produto"].ToString());
                    produto.desc_produto = dados["desc_produto"].ToString();
                    produto.valor = Convert.ToSingle(dados["valor"].ToString());
                    produto.idCategoria = Convert.ToInt32(dados["id_categoria"].ToString());
                    produto.estoque = Convert.ToInt32(dados["estoque"].ToString());
                    lstProdutos.Add(produto);
                }
            }
            catch
            {
                Console.WriteLine("Erro na consulta de Produtos...");
            }
            finally
            {
                conexao.Close();
            }
            return lstProdutos;
        }

        public List<MODEL.Produtos> SelectWithCategoria()
        {
            List<MODEL.Produtos> lstProdutos = new List<MODEL.Produtos>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "SELECT * FROM tb_produtos INNER JOIN tb_categorias ON tb_produtos.id_categoria = tb_categorias.id_categoria;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            try
            {
                conexao.Open();
                SqlDataReader dados = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dados.Read())
                {
                    MODEL.Produtos produto = new MODEL.Produtos();
                    produto.id_produto = Convert.ToInt32(dados["id_produto"].ToString());
                    produto.desc_produto = dados["desc_produto"].ToString();
                    produto.valor = Convert.ToSingle(dados["valor"].ToString());
                    produto.idCategoria = Convert.ToInt32(dados["id_categoria"].ToString());
                    produto.desc_categoria = dados["desc_categoria"].ToString();
                    produto.estoque = Convert.ToInt32(dados["estoque"].ToString());
                    lstProdutos.Add(produto);
                }
            }
            catch
            {
                Console.WriteLine("Deu erro na consulta de Produtos...");
            }
            finally
            {
                conexao.Close();
            }

            return lstProdutos;
        }

    }

}
