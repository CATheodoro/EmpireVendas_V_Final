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
    public class ItensVenda
    {
        private string strCon = Conexao.getConexao();
        public List<MODEL.ItensVenda> Select()
        {
            List<MODEL.ItensVenda> lstItensVenda = new List<MODEL.ItensVenda>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "SELECT * FROM tb_produtos;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            try
            {
                conexao.Open();
                SqlDataReader dados = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dados.Read())
                {
                    MODEL.ItensVenda item = new MODEL.ItensVenda();
                    item.id_produto = Convert.ToInt32(dados["id_produto"].ToString());
                    item.desc_produto = dados["desc_produto"].ToString();
                    item.valor = Convert.ToSingle(dados["valor"].ToString());
                    lstItensVenda.Add(item);
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

            return lstItensVenda;
        }

        public void Insert(MODEL.ItensVenda itens)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "INSERT INTO tb_itens_venda (quantidade, id_produto, id_venda, valor) VALUES (@quantidade, @id_produto, @id_venda, @valor);";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@quantidade", itens.quantidade);
            cmd.Parameters.AddWithValue("@id_produto", itens.id_produto);
            cmd.Parameters.AddWithValue("@id_venda", itens.id_venda);
            cmd.Parameters.AddWithValue("@valor", itens.valor);
            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na inclusão de ItensVendas...");
            }
            finally
            {
                conexao.Close();
            }

        }

        public List<MODEL.ItensVenda> SelectEspelhoVenda(int id)
        {
            List<MODEL.ItensVenda> lstItensVendas = new List<MODEL.ItensVenda>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "SELECT tb_produtos.id_produto, tb_produtos.desc_produto, tb_itens_venda.valor, tb_itens_venda.quantidade, tb_itens_venda.id_venda " +
                "FROM tb_itens_venda, tb_produtos " +
                "WHERE tb_itens_venda.id_produto = tb_produtos.id_produto AND tb_itens_venda.id_venda =" + id+";";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            try
            {
                conexao.Open();
                SqlDataReader dados = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dados.Read())
                {
                    MODEL.ItensVenda itensVenda = new MODEL.ItensVenda();
                    itensVenda.id_produto = Convert.ToInt32(dados["id_produto"].ToString());
                    itensVenda.desc_produto = dados["desc_produto"].ToString();
                    itensVenda.valor = Convert.ToSingle(dados["valor"].ToString());
                    itensVenda.quantidade = Convert.ToInt32(dados["quantidade"].ToString());
                    itensVenda.id_venda = Convert.ToInt32(dados["id_venda"].ToString());
                    lstItensVendas.Add(itensVenda);


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

            return lstItensVendas;
        }

    }
}
