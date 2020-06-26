using EmpireVendas.CAMADAS.DAL;
using EmpireVendas.CAMADAS.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmpireVendas
{
    public partial class frmProdutos : Form
    {
        public frmProdutos()
        {
            InitializeComponent();
            limparControles();
        }

        private void Produtos_Load(object sender, EventArgs e)
        {

            // TODO: esta linha de código carrega dados na tabela 'eMPIREVENDASDataSet.tb_produtos'. Você pode movê-la ou removê-la conforme necessário.
            
            CAMADAS.BLL.Produtos bllProdutos = new CAMADAS.BLL.Produtos();
            dgvProdutos.DataSource = "";
            dgvProdutos.DataSource = bllProdutos.Select();
            


            CAMADAS.BLL.Categorias dalCat = new CAMADAS.BLL.Categorias();
            cmbCategoria.DisplayMember = "desc_categoria";
            cmbCategoria.ValueMember = "id_categoria";
            cmbCategoria.DataSource = dalCat.Select();
            txtProduto.Focus();
        }

        private void limparControles()
        {
            txtId.Text = "-1";
            txtProduto.Text = "";
            txtEstoque.Text = string.Empty;
            txtValor.Text = string.Empty;
            txtCategoria.Text = null;
            txtProduto.Focus();
            cmbCategoria.Text = "";

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            limparControles();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            

            CAMADAS.MODEL.Produtos produto = new CAMADAS.MODEL.Produtos();
            CAMADAS.BLL.Produtos bllProduto = new CAMADAS.BLL.Produtos();

              if(txtValor.Text != "" && txtProduto.Text != "" &&  txtEstoque.Text != "" ) {
                produto.desc_produto = txtProduto.Text;
                produto.valor = Convert.ToSingle(txtValor.Text);
                produto.idCategoria = Convert.ToInt32(txtCategoria.Text);
                produto.estoque = Convert.ToInt32(txtEstoque.Text);
                bllProduto.Insert(produto);
                dgvProdutos.DataSource = "";
                dgvProdutos.DataSource = bllProduto.Select();
                limparControles();
            }
            else
            {
                MessageBox.Show("Por favor, preencha todos os campos!");
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            int idProd = Convert.ToInt32(txtId.Text);
            CAMADAS.BLL.Produtos bllProd = new CAMADAS.BLL.Produtos();
            string msg = "Deseja remover o produto selecionado ?";
            DialogResult resp = MessageBox.Show(msg, "Remover", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2);
            if (resp == DialogResult.Yes)
                bllProd.Delete(idProd);

            dgvProdutos.DataSource = "";
            dgvProdutos.DataSource = bllProd.Select();
            limparControles();
        }


        private void btnEditar_Click(object sender, EventArgs e)
        {
            if(txtId.Text != "-1" && txtValor.Text != "" && txtProduto.Text != "" && txtEstoque.Text != "") { 
                CAMADAS.BLL.Produtos bllProduto = new CAMADAS.BLL.Produtos();
                CAMADAS.MODEL.Produtos produto = new CAMADAS.MODEL.Produtos();
                produto.id_produto = Convert.ToInt32(txtId.Text);
                produto.desc_produto = txtProduto.Text;
                produto.valor = Convert.ToSingle(txtValor.Text);
                produto.idCategoria = Convert.ToInt32(txtCategoria.Text);
                produto.estoque = Convert.ToInt32(txtEstoque.Text);
                bllProduto.Update(produto);
                dgvProdutos.DataSource = "";
                dgvProdutos.DataSource = bllProduto.Select();
                limparControles();
            }
            else
            {
                MessageBox.Show("Não é possível deixar nenhum campo em branco!");
            }
        }
        private void filtrar()
        {
            if (txtFiltro.Text != "")
            {
                CAMADAS.BLL.Produtos bllProduto = new CAMADAS.BLL.Produtos();
                List<CAMADAS.MODEL.Produtos> lstProdutos = new List<CAMADAS.MODEL.Produtos>();
                if (checkTodos.Checked)
                    lstProdutos = bllProduto.Select();
                else if (checkNome.Checked)
                    lstProdutos = bllProduto.SelectByNome(txtFiltro.Text);
                else
                {
                    int id = Convert.ToInt32(txtFiltro.Text);
                    lstProdutos = bllProduto.SelectByID(id);

                }

                dgvProdutos.DataSource = "";
                dgvProdutos.DataSource = lstProdutos;
            }

        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            filtrar();
        }

        private void dgvProdutos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try { 
                txtId.Text = dgvProdutos.SelectedRows[0].Cells["id_produto"].Value.ToString();
                txtProduto.Text = dgvProdutos.SelectedRows[0].Cells["desc_produto"].Value.ToString();
                txtCategoria.Text = dgvProdutos.SelectedRows[0].Cells["idCategoria"].Value.ToString();
                txtEstoque.Text = dgvProdutos.SelectedRows[0].Cells["estoque"].Value.ToString();
                txtValor.Text = dgvProdutos.SelectedRows[0].Cells["valor"].Value.ToString();
                cmbCategoria.SelectedValue = Convert.ToInt32(txtCategoria.Text);

            }
            catch
            {
               
            }
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCategoria.Text = cmbCategoria.SelectedValue.ToString();
        }


        private void txtId_TextChanged(object sender, EventArgs e)
        {
            if(txtId.Text != "-1")
            {
                btnGravar.Enabled = false;
                btnNovo.Enabled = true;
                btnEditar.Enabled = true;
                btnRemover.Enabled = true;
            }
            else
            {
                btnGravar.Enabled = true;
                btnNovo.Enabled = false;
                btnEditar.Enabled = false;
                btnRemover.Enabled = false;
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            CAMADAS.BLL.Produtos bllProduto = new CAMADAS.BLL.Produtos();
            dgvProdutos.DataSource = "";
            dgvProdutos.DataSource = bllProduto.Select();
        }

        private void txtFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true; e.SuppressKeyPress = true; txtFiltro.Focus();
                filtrar();
            }
        }

        private void txtFiltro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && checkId.Checked)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void checkId_CheckedChanged(object sender, EventArgs e)
        {
            txtFiltro.Text = "";
        }

        private void txtValor_TextChanged(object sender, EventArgs e)
        {
            float valor = 0;
            if (txtValor.Text.Length >= 0 && txtValor.Text != "")
            {
                valor = Convert.ToSingle(txtValor.Text.Replace(",", "").Replace(".", "")) / 100;
            }
            txtValor.Text = valor.ToString();
            txtValor.SelectionStart = txtValor.Text.Length;
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
    }
}


