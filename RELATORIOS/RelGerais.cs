using EmpireVendas.CAMADAS.BLL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmpireVendas.RELATORIOS
{
	public class RelGerais
	{
		public static void relProdutos()
		{

			CAMADAS.BLL.Produtos bllProduto = new CAMADAS.BLL.Produtos();
			List<CAMADAS.MODEL.Produtos> lstProdutos = new List<CAMADAS.MODEL.Produtos>();
			lstProdutos = bllProduto.Select();

			string pasta = Funcoes.deretorioPasta();
			string arquivo = pasta + @"\RelProdutos_" + DateTime.Now.ToShortDateString().Replace("/", "_") + "--" + DateTime.Now.ToLongTimeString().Replace(":", "_") + "--.html";
			StreamWriter sw = new StreamWriter(arquivo);
			using (sw)
			{
				sw.WriteLine("<html>");
				sw.WriteLine("<head>");
				sw.WriteLine("<meta http-equiv='Content-Type' " +
							"content='text/html; charset=utf-8'/>");
				sw.WriteLine("<link rel='stylesheet' href='https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css' integrity='sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T' crossorigin='anonymous'>");

				sw.WriteLine("</head>");

				sw.WriteLine("<body>");

				sw.WriteLine("<table class='table table-hover'>");
				//Cabeçalho da tabela
				sw.WriteLine("<thead class='thead-dark'>");
				sw.WriteLine("<tr>");
				sw.WriteLine("<th scope='col'>");
				sw.WriteLine("CÓDIGO");
				sw.WriteLine("</th>");
				sw.WriteLine("<th scope='col'>");
				sw.WriteLine("PRODUTO");
				sw.WriteLine("</th>");
				sw.WriteLine("<th scope='col'>");
				sw.WriteLine("VALOR");
				sw.WriteLine("</th>");
				sw.WriteLine("<th scope='col'>");
				sw.WriteLine("ESTOQUE");
				sw.WriteLine("</th>");
				sw.WriteLine("<th scope='col'>");
				sw.WriteLine("CATEGORIA");
				sw.WriteLine("</th>");

				sw.WriteLine("</tr>");
				sw.WriteLine("</thead>");


				int cont = 0;
				float soma = 0;
				foreach (CAMADAS.MODEL.Produtos produto in lstProdutos)
				{

					sw.WriteLine("<tbody>");
					sw.WriteLine("<tr>");
					sw.WriteLine("<th scope='col'>");
					sw.WriteLine(produto.id_produto);
					sw.WriteLine("</td>");
					sw.WriteLine("<th scope='col'>");
					sw.WriteLine(produto.desc_produto);
					sw.WriteLine("</td>");
					sw.WriteLine("<th scope='col'>");
					sw.WriteLine(string.Format("{0:C2}", produto.valor));
					sw.WriteLine("</td>");
					sw.WriteLine("<th scope='col'>");
					sw.WriteLine(produto.estoque);
					sw.WriteLine("</td>");
					sw.WriteLine("<th scope='col'>");
					sw.WriteLine(produto.desc_categoria);
					sw.WriteLine("</td>");
					sw.WriteLine("</tr>");
					soma = soma + produto.valor;
					cont++;

				}
				sw.WriteLine("</tbody>");
				sw.WriteLine("</table>");
				sw.WriteLine("</body>");
				sw.WriteLine("</html>");
			}
			System.Diagnostics.Process.Start(arquivo);
		}


		//Relatório Cupom
		public static void relCupom(int id)
		{
			float subTotal = 0;
			CAMADAS.BLL.ItensVenda bllItensVendas = new CAMADAS.BLL.ItensVenda();
			CAMADAS.BLL.Vendas bllVendas = new CAMADAS.BLL.Vendas();
			List<CAMADAS.MODEL.ItensVenda> lstItensVenda = new List<CAMADAS.MODEL.ItensVenda>();
			List<CAMADAS.MODEL.Vendas> lstVendas = new List<CAMADAS.MODEL.Vendas>();
			lstVendas = bllVendas.SelectWithInnerJoinById(id);
			lstItensVenda = bllItensVendas.SelectEspelhoVenda(id);
			string pasta = Funcoes.deretorioPasta();
			string arquivo = pasta + @"\Cupom_" + DateTime.Now.ToShortDateString().Replace("/", "_") + "--" + DateTime.Now.ToLongTimeString().Replace(":", "_") + "--.html";
			StreamWriter sw = new StreamWriter(arquivo);

			//inicio mover cupom.css
			string cupom = @"cupom.css";
			string diretorio = @"C:\RELADS\cupom.css";
            if (!File.Exists(diretorio))
            {
				File.Copy(cupom, @"C:\RELADS\cupom.css");
			}
            else
            {
				byte[] cupomInicial = File.ReadAllBytes(cupom);
				byte[] diretorioFinal = File.ReadAllBytes(diretorio);
				if (BitConverter.ToString(cupomInicial) != BitConverter.ToString(diretorioFinal))
				{
					File.Delete(@"C:\RELADS\cupom.css");
					File.Copy(cupom, @"C:\RELADS\cupom.css");
				}
			}
			//fim mover cupom.css





			using (sw)
			{
				
				sw.WriteLine("<html>");
				sw.WriteLine("<head>");
				sw.WriteLine("<link rel = 'stylesheet' type = 'text/css' href = 'cupom.css' media = 'screen' />");
				sw.WriteLine("</head>");
				sw.WriteLine("<body>");
				sw.WriteLine("<table class='printer-ticket'>");
				sw.WriteLine("<thead>");
				sw.WriteLine("<tr>");
				sw.WriteLine("<th class='title' colspan='3'>Empire Vendas</th>");
				sw.WriteLine("</tr>");
				sw.WriteLine("<tr>");
				foreach (CAMADAS.MODEL.Vendas venda in lstVendas)
					sw.WriteLine("<th colspan='3'>"+venda.data+"</th>");
				sw.WriteLine("</tr>");
				sw.WriteLine("<tr>");
				sw.WriteLine("<th colspan='3'>");
				foreach (CAMADAS.MODEL.Vendas venda in lstVendas)
					sw.WriteLine("CLIENTE: "+venda.desc_cliente+"<br />");
				sw.WriteLine("</th>");
				sw.WriteLine("</tr>");
				sw.WriteLine("<tr>");
				sw.WriteLine("<th class='ttu' colspan='3'>");
				sw.WriteLine("<b>Cupom não fiscal</b>");
				sw.WriteLine("</th>");
				sw.WriteLine("</tr>");
				sw.WriteLine("</thead>");
				foreach (CAMADAS.MODEL.ItensVenda itensVenda in lstItensVenda)
				{
					sw.WriteLine("<tbody>");

					sw.WriteLine("<tr class='top'>");
					sw.WriteLine("<td colspan='3'>"+itensVenda.desc_produto+" </ td >");
					sw.WriteLine("</tr>");
					sw.WriteLine("<tr >");
					sw.WriteLine("<td>R$"+(itensVenda.valor/itensVenda.quantidade)+"</td>");
					sw.WriteLine("<td>"+itensVenda.quantidade+"</td>");
					float valorTotal = itensVenda.valor;
					sw.WriteLine("<td>R$"+valorTotal+"</td>");
					sw.WriteLine("</tr>");
					subTotal += valorTotal;
				}
				sw.WriteLine("</tbody>");
					
				sw.WriteLine("<tfoot>");
				sw.WriteLine("<tr class='sup ttu p--0'>");
				sw.WriteLine("<td colspan='3'>");
				sw.WriteLine("<b>Totais</b>");
				sw.WriteLine("</td>");
				sw.WriteLine("</tr>");
				sw.WriteLine("<tr class='ttu'>");
				sw.WriteLine("<td colspan='2'>Sub-total</td>");
				sw.WriteLine("<td align='right'>R$"+subTotal+"</td>");
				sw.WriteLine("</tr>");
				sw.WriteLine("<tr class='ttu'>");
				sw.WriteLine("<td colspan='2' > Desconto</td>");
				foreach (CAMADAS.MODEL.Vendas venda in lstVendas)
					sw.WriteLine("<td align='right' >R$"+venda.desconto+"</td>");
				sw.WriteLine("</tr>");
				sw.WriteLine("<tr class='ttu'>");
				
				sw.WriteLine("<td colspan='2' > Total</td>");
				foreach (CAMADAS.MODEL.Vendas venda in lstVendas)
					sw.WriteLine("<td align='right' >R$"+ venda.valor_final+"</td>");
				sw.WriteLine("</tr>");
				sw.WriteLine("<tr class='sup ttu p--0' > ");
				sw.WriteLine("<td colspan='3' > ");
				sw.WriteLine("<b>Pagamentos</b>");
				sw.WriteLine("</td>");
				sw.WriteLine("</tr>");
				sw.WriteLine("<tr class='ttu'>");
				sw.WriteLine("<td colspan='2'>Total pago</td>");
				foreach (CAMADAS.MODEL.Vendas venda in lstVendas)
					sw.WriteLine("<td align='right'>R$"+ venda.valor_final + "</td>");
				sw.WriteLine("</tr>");
				sw.WriteLine("<tr class='sup'>");
				sw.WriteLine("<td colspan='3' align='center'>");
				sw.WriteLine("www.empiresystem.com");
				sw.WriteLine("</td>");
				sw.WriteLine("</tr>");
				sw.WriteLine("</tfoot>");
				sw.WriteLine("</table>");
				sw.WriteLine("</body>");
				sw.WriteLine("</html>");
				System.Diagnostics.Process.Start(arquivo);
			}


		}
		//FIM CUPONS

		//RELATORIOS VENDAS
		public static void relVendas()
		{

			CAMADAS.BLL.Vendas bllVendas = new CAMADAS.BLL.Vendas();
			List<CAMADAS.MODEL.Vendas> lstVendas = new List<CAMADAS.MODEL.Vendas>();
			lstVendas = bllVendas.SelectWithInnerJoin();

			string pasta = Funcoes.deretorioPasta();
			string arquivo = pasta + @"\RelVendas_" + DateTime.Now.ToShortDateString().Replace("/", "_") + "--" + DateTime.Now.ToLongTimeString().Replace(":", "_") + "--.html";
			StreamWriter sw = new StreamWriter(arquivo);
			using (sw)
			{
				sw.WriteLine("<html>");
				sw.WriteLine("<head>");
				sw.WriteLine("<meta http-equiv='Content-Type' " +
							"content='text/html; charset=utf-8'/>");
				sw.WriteLine("<link rel='stylesheet' href='https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css' integrity='sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T' crossorigin='anonymous'>");

				sw.WriteLine("</head>");

				sw.WriteLine("<body>");

				sw.WriteLine("<table class='table table-hover'>");
				//Cabeçalho da tabela
				sw.WriteLine("<thead class='thead-dark'>");
				sw.WriteLine("<tr>");
				sw.WriteLine("<th scope='col'>");
				sw.WriteLine("ID VENDA");
				sw.WriteLine("</th>");
				sw.WriteLine("<th scope='col'>");
				sw.WriteLine("DESCONTO");
				sw.WriteLine("</th>");
				sw.WriteLine("<th scope='col'>");
				sw.WriteLine("VALOR FINAL");
				sw.WriteLine("</th>");
				sw.WriteLine("<th scope='col'>");
				sw.WriteLine("DATA");
				sw.WriteLine("</th>");
				sw.WriteLine("<th scope='col'>");
				sw.WriteLine("CLIENTE");
				sw.WriteLine("</th>");
				sw.WriteLine("</th>");
				sw.WriteLine("<th scope='col'>");
				sw.WriteLine("VENDEDOR");
				sw.WriteLine("</th>");
				sw.WriteLine("<th scope='col'>");
				sw.WriteLine("TOTAL ARRECADADO");
				sw.WriteLine("</th>");

				sw.WriteLine("</tr>");
				sw.WriteLine("</thead>");


				int cont = 0;
				float soma = 0;
				foreach (CAMADAS.MODEL.Vendas vendas in lstVendas)
				{

					sw.WriteLine("<tbody>");
					sw.WriteLine("<tr>");
					sw.WriteLine("<th scope='col'>");
					sw.WriteLine(vendas.id_venda);
					sw.WriteLine("</td>");
					sw.WriteLine("<th scope='col'>");
					sw.WriteLine(vendas.desconto);
					sw.WriteLine("</td>");
					sw.WriteLine("<th scope='col'>");
					sw.WriteLine(string.Format("{0:C2}", vendas.valor_final));
					sw.WriteLine("</td>");
					sw.WriteLine("<th scope='col'>");
					sw.WriteLine(vendas.data);
					sw.WriteLine("</td>");
					sw.WriteLine("<th scope='col'>");
					sw.WriteLine(vendas.desc_cliente);
					sw.WriteLine("</td>");
					sw.WriteLine("<th scope='col'>");
					sw.WriteLine(vendas.desc_vendedor);
					sw.WriteLine("</td>");
					soma = soma + vendas.valor_final;
					cont++;
					sw.WriteLine("<th scope='col'>");
					sw.WriteLine("VENDA "+cont+": "+soma);
					sw.WriteLine("</td>");

					sw.WriteLine("</tr>");
				}
				sw.WriteLine("</tbody>");
				sw.WriteLine("</table>");
				sw.WriteLine("</body>");
				sw.WriteLine("</html>");
			}
			System.Diagnostics.Process.Start(arquivo);
		}

		
		//FIM RELATORIOS VENDAS
	}
}

