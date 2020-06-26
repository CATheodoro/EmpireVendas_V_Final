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
    public class Categorias
    {
        private string strCon = Conexao.getConexao();

        public List<MODEL.Categorias> Select()
        {
            List<MODEL.Categorias> lstCategorias = new List<MODEL.Categorias>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "SELECT * FROM tb_categorias;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            try
            {
                conexao.Open();
                SqlDataReader dados = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dados.Read())
                {
                    MODEL.Categorias categoria = new MODEL.Categorias();
                    categoria.id_categoria = Convert.ToInt32(dados["id_categoria"].ToString());
                    categoria.desc_categoria = dados["desc_categoria"].ToString();
                    lstCategorias.Add(categoria);
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

            return lstCategorias;
        }

        public void Insert(MODEL.Categorias categoria)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "INSERT INTO tb_categorias VALUES (@desc_categoria);";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@desc_categoria", categoria.desc_categoria);
            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na inclusão da Categoria...");
            }
            finally
            {
                conexao.Close();
            }

        }

        public void Update(MODEL.Categorias categoria)
        {


            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "UPDATE tb_categorias SET desc_categoria=@desc_categoria WHERE id_categoria=@id_categoria;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id_categoria", categoria.id_categoria);
            cmd.Parameters.AddWithValue("@desc_categoria", categoria.desc_categoria);

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

        public void Delete(int idCat)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "DELETE FROM tb_categorias WHERE id_categoria=@id_categoria;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id_categoria", idCat);

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
