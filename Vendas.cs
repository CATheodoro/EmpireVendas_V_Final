using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmpireVendas
{
    public partial class Vendas : Form
    {
        public Vendas()
        {
            InitializeComponent();
        }

        private void Vendas_Load(object sender, EventArgs e)
        {
            //PEGAR DES_PRODUTO E ID
            CAMADAS.BLL.Produtos bllProdutos = new CAMADAS.BLL.Produtos();
            dgvProdutos.DataSource = "";
            dgvProdutos.DataSource = bllProdutos.SelectWithCategoria();
            txtIdProduto.Text = dgvProdutos.SelectedRows[0].Cells["id_produto"].Value.ToString();
            txtValorUni.Text = dgvProdutos.SelectedRows[0].Cells["valor"].Value.ToString();
            cmbProduto.DisplayMember = "desc_produto";
            cmbProduto.ValueMember = "id_produto";

            cmbProduto.DataSource = bllProdutos.Select();


            CAMADAS.BLL.Funcionarios dalVend = new CAMADAS.BLL.Funcionarios();
            CAMADAS.BLL.Clientes dalCli = new CAMADAS.BLL.Clientes();


            cmbVendedor.DisplayMember = "nome_vendedor";
            cmbVendedor.ValueMember = "id_vendedor";
            cmbCliente.DisplayMember = "nome";
            cmbCliente.ValueMember = "id_cliente";

            
            cmbCliente.DataSource = dalCli.Select();
            cmbVendedor.DataSource = dalVend.Select();
            txtDesconto.Text = "0";
            txtQtd.Text = "1";
        }


        private void btnNovo_Click(object sender, EventArgs e)
        {
            float valorTotal = 0;


            if (cmbProduto.Text != "" && /*Convert.ToSingle(txtValorTotal.Text) != null && Convert.ToSingle(txtValorUni.Text) != null &&*/ txtQtd.Text != "") {
                valorTotal = Convert.ToSingle(txtQtd.Text) * Convert.ToSingle(txtValorUni.Text);
                txtValorTotal.Text = valorTotal.ToString();
                    dgvItensVenda.Rows.Add(txtIdProduto.Text, cmbProduto.Text, txtQtd.Text, txtValorUni.Text, valorTotal);
            }
            else
            {
                MessageBox.Show("os campos são obrigatórios preencher!");
            }
            txtSubTotal.Text = somaTotais().ToString();
        }

        private void cmbProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            //pegar valor unidade
            CAMADAS.BLL.Produtos bllProdutos = new CAMADAS.BLL.Produtos();
            txtIdProduto.Text = cmbProduto.SelectedValue.ToString();
            int id = 0;
            id = Convert.ToInt32(txtIdProduto.Text);
            txtValorUni.Text = Convert.ToString(bllProdutos.SelectPrecoByID(id));
        }

        private void txtQtd_TextChanged(object sender, EventArgs e)
        {
            float somaTotais = 0;
            if(txtQtd.Text != "") {
            somaTotais = Convert.ToInt32(txtQtd.Text) * Convert.ToSingle(txtValorUni.Text);
            txtValorTotal.Text = somaTotais.ToString();
            }
            else
            {
                txtValorTotal.Text = txtValorUni.Text;
            }

        }

        private float somaTotais()
        {
            float valorTotal = 0;
            float valorDesconto = 0;
            float valorFinal = 0;
            for (Int32 i = 0; i < dgvItensVenda.Rows.Count; i++)
            {
                dgvItensVenda.Rows[i].Cells[0].Value.ToString();// coluna 1
                dgvItensVenda.Rows[i].Cells[1].Value.ToString();// coluna 2
                dgvItensVenda.Rows[i].Cells[2].Value.ToString();// coluna 3
                valorTotal += Convert.ToSingle(dgvItensVenda.Rows[i].Cells[4].Value.ToString());// coluna 5

            }

            if (txtDesconto.Text == "")
            {
                txtDesconto.Text = "0";
            }

            if (txtDesconto.Text != "")
            {
                valorDesconto = Convert.ToSingle(txtDesconto.Text);
                valorFinal = valorTotal - valorDesconto;
                return valorFinal;
            }
            return 0;
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            CAMADAS.MODEL.Vendas venda = new CAMADAS.MODEL.Vendas();
            CAMADAS.MODEL.Produtos produtos = new CAMADAS.MODEL.Produtos();
            CAMADAS.BLL.Vendas bllVendas = new CAMADAS.BLL.Vendas();
            int estoque = 0;
            int id_produto;
            CAMADAS.BLL.Produtos bllProdutos = new CAMADAS.BLL.Produtos();
            //gravar tabela de vendas.
            if(dgvItensVenda.Rows.Count > 0) { 
                venda.desconto = Convert.ToSingle(txtDesconto.Text);
                venda.valor_final = Convert.ToSingle(txtSubTotal.Text);
                venda.id_vendedor = Convert.ToInt32(txtVendedor.Text);
                venda.id_cliente = Convert.ToInt32(txtCliente.Text);
                venda.data = dtpData.Value;
                bllVendas.EfetivarVenda(venda);
                
                dgvProdutos.DataSource = bllProdutos.SelectWithCategoria();
                MessageBox.Show("Venda efetuada com sucesso!");
            }
            else
            {
                MessageBox.Show("Nenhum produto lançado!");
            }
            //fim gravar tabela de vendas.


            //dar baixa no estoque.
            for (Int32 i = 0; i < dgvItensVenda.Rows.Count; i++)
            {
                
                id_produto = Convert.ToInt32(dgvItensVenda.Rows[i].Cells[0].Value.ToString());// coluna 1
                estoque = Convert.ToInt32(dgvItensVenda.Rows[i].Cells[2].Value.ToString());// coluna 2
                
                produtos.estoque = Convert.ToInt32(estoque);
                produtos.id_produto = id_produto;
                bllVendas.BaixaEstoque(produtos);

            }
            //fim dar baixa no estoque.

            //Incio Inserir dados na tabela Itens_vendas
            CAMADAS.MODEL.ItensVenda itens = new CAMADAS.MODEL.ItensVenda();
            CAMADAS.BLL.ItensVenda bllItensVenda = new CAMADAS.BLL.ItensVenda();

            int recebeID = bllVendas.SelectID();

            for (Int32 i = 0; i < dgvItensVenda.Rows.Count; i++)
            {

                itens.quantidade = Convert.ToInt32(dgvItensVenda.Rows[i].Cells[2].Value.ToString());// Quantidade
                itens.id_produto = Convert.ToInt32(dgvItensVenda.Rows[i].Cells[0].Value.ToString());// ID produto
                itens.id_venda = recebeID;
                itens.valor = Convert.ToSingle(dgvItensVenda.Rows[i].Cells[4].Value.ToString());// Valor Total
                bllItensVenda.Insert(itens);
            }
            //Fim Inserir dados na tabela Itens_vendas
            string msg = "Deseja imprimir o cupom ?";
            CAMADAS.BLL.Vendas idVenda = new CAMADAS.BLL.Vendas();
            int id = 0;
            id = idVenda.SelectID();
            DialogResult resp;
            if (dgvItensVenda.Rows.Count > 0) {
             resp = MessageBox.Show(msg, "Imprimir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (resp == DialogResult.Yes)
                    RELATORIOS.RelGerais.relCupom(id);
            }
            dgvItensVenda.Rows.Clear();

            dgvProdutos.DataSource = bllProdutos.Select();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if(dgvItensVenda.Rows.Count != 0)
            {
                dgvItensVenda.Rows.RemoveAt(dgvItensVenda.CurrentRow.Index);
                txtSubTotal.Text = somaTotais().ToString();
            }
            else
            {
                MessageBox.Show("Nenhum produto para remover!");
            }
        }

        private void txtDesconto_TextChanged(object sender, EventArgs e)
        {
            float valorTotal = 0;
            for (Int32 i = 0; i < dgvItensVenda.Rows.Count; i++)
            {
                valorTotal += Convert.ToSingle(dgvItensVenda.Rows[i].Cells[4].Value.ToString());// coluna 5

            }
            float desconto = 0;
            float total = 0;


            if (txtDesconto.Text == "")
            {
                txtDesconto.Text = "0";
            }

            desconto = Convert.ToSingle(txtDesconto.Text);

            total = valorTotal - desconto;

            txtSubTotal.Text = total.ToString();
        }


        private void txtValorUni_TextChanged(object sender, EventArgs e)
        {
            if(txtQtd.Text == "1")
            {
                txtValorTotal.Text = txtValorUni.Text;
            }
            else
            {
                txtQtd.Text = "1";
            }

        }

        private void cmbVendedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtVendedor.Text = cmbVendedor.SelectedValue.ToString();
        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCliente.Text = cmbCliente.SelectedValue.ToString();
        }

        private void dgvProdutos_DoubleClick(object sender, EventArgs e)
        {
            cmbProduto.Text = dgvProdutos.SelectedRows[0].Cells["desc_produto"].Value.ToString();
        }

        private void txtQtd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
        private void filtrar()
        {
            if (txtBusca.Text != "")
            {
                CAMADAS.BLL.Produtos bllProdutos = new CAMADAS.BLL.Produtos();
                List<CAMADAS.MODEL.Produtos> lstProdutos = new List<CAMADAS.MODEL.Produtos>();

                if (rdbNomeProduto.Checked)
                    lstProdutos = bllProdutos.SelectByNome(txtBusca.Text);


                else
                {
                    int id = Convert.ToInt32(txtBusca.Text);
                    lstProdutos = bllProdutos.SelectByID(id);
                }

                dgvProdutos.DataSource = "";
                dgvProdutos.DataSource = lstProdutos;
                if (dgvProdutos.Rows.Count <= 0 || txtBusca.Text == "")
                {
                    MessageBox.Show("Infelizmente esse produto não foi registradas!!!");
                    dgvProdutos.DataSource = bllProdutos.SelectWithCategoria();
                }
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            filtrar();
        }

        private void rdbIdProduto_CheckedChanged(object sender, EventArgs e)
        {
            txtBusca.Text = "";
        }

        private void rdbNomeProduto_CheckedChanged(object sender, EventArgs e)
        {
            txtBusca.Text = "";
        }

        private void txtBusca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true; e.SuppressKeyPress = true; txtBusca.Focus();
                filtrar();
            }
        }

        private void txtBusca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && rdbIdProduto.Checked)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txtDesconto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            CAMADAS.BLL.Produtos bllProdutos = new CAMADAS.BLL.Produtos();
            dgvProdutos.DataSource = bllProdutos.Select();
        }
    }
}

