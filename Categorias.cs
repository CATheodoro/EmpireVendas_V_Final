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
    public partial class Categorias : Form
    {
        public Categorias()
        {
            InitializeComponent();
            txtId.Text = "-1";
        }

        private void Categorias_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'eMPIREVENDASDataSet2.tb_categorias'. Você pode movê-la ou removê-la conforme necessário.
            CAMADAS.BLL.Categorias bllCategorias = new CAMADAS.BLL.Categorias();
            dgvCategorias.DataSource = "";
            dgvCategorias.DataSource = bllCategorias.Select();
            txtCategoria.Focus();
        }

        private void limparControles()
        {
            txtId.Text = "-1";
            txtCategoria.Text = "";

        }
        private void btnGravar_Click(object sender, EventArgs e)
        {
            CAMADAS.MODEL.Categorias categoria = new CAMADAS.MODEL.Categorias();
            CAMADAS.BLL.Categorias bllCategoria = new CAMADAS.BLL.Categorias();
            if (txtCategoria.Text != "")
            {

                categoria.desc_categoria = txtCategoria.Text;
                bllCategoria.Insert(categoria);

                dgvCategorias.DataSource = "";
                dgvCategorias.DataSource = bllCategoria.Select();
                limparControles();

            }
            else
            {
                MessageBox.Show("É necessário preencher algum nome para a Categoria.");
            }

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            limparControles();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "-1" && txtCategoria.Text != "") { 
            CAMADAS.MODEL.Categorias categoria = new CAMADAS.MODEL.Categorias();
            CAMADAS.BLL.Categorias bllCategoria = new CAMADAS.BLL.Categorias();

            categoria.id_categoria = Convert.ToInt32(txtId.Text);
            categoria.desc_categoria = txtCategoria.Text;
            bllCategoria.Update(categoria);
            dgvCategorias.DataSource = "";
            dgvCategorias.DataSource = bllCategoria.Select();
            limparControles();
            }
            else
            {
                MessageBox.Show("Preencha algum nome para a Categoria, para edita-la.");
            }
        }

        private void dgvCategorias_DoubleClick(object sender, EventArgs e)
        {
            try
            {
              txtId.Text = dgvCategorias.SelectedRows[0].Cells["id_categoria"].Value.ToString();
              txtCategoria.Text = dgvCategorias.SelectedRows[0].Cells["desc_categoria"].Value.ToString();
            }
            catch
            {

            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            int idCat = Convert.ToInt32(txtId.Text);
            CAMADAS.BLL.Categorias bllCat = new CAMADAS.BLL.Categorias();
            string msg = "Deseja remover a categoria selecionado ?";
            DialogResult resp = MessageBox.Show(msg, "Remover", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2);
            if (resp == DialogResult.Yes)
                bllCat.Delete(idCat);

            dgvCategorias.DataSource = "";
            dgvCategorias.DataSource = bllCat.Select();
            limparControles();
        }

        private void dgvCategorias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            if (txtId.Text != "-1")
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
            CAMADAS.BLL.Categorias bllCat = new CAMADAS.BLL.Categorias();
            dgvCategorias.DataSource = "";
            dgvCategorias.DataSource = bllCat.Select();
        }
    }
}
