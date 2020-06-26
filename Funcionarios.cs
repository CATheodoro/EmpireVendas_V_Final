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
    public partial class Funcionarios : Form
    {
        public Funcionarios()
        {
            InitializeComponent();
        }

        private void limparControles()
        {
            txtID.Text = "-1";
            txtUsuario.Text = "";
            txtSenha.Text = "";
            txtNome.Text = "";
            txtEndereco.Text = "";
            txtNumero.Text = "";
            txtCidade.Text = "";
            txtEmail.Text = "";
            
        }

        private void Funcionarios_Load(object sender, EventArgs e)
        {
            limparControles();
            CAMADAS.BLL.Funcionarios bllFuncionario = new CAMADAS.BLL.Funcionarios();
            dgvFuncionarios.DataSource = "";
            dgvFuncionarios.DataSource = bllFuncionario.Select();
            txtNome.Focus();
        }


        private void dgvCategorias_DoubleClick(object sender, EventArgs e)
        {
            txtID.Text = dgvFuncionarios.SelectedRows[0].Cells["id_vendedor"].Value.ToString();
            //txtUsuario.Text = dgvFuncionarios.SelectedRows[0].Cells["usuario"].Value.ToString();
            //txtSenha.Text = dgvFuncionarios.SelectedRows[0].Cells["senha"].Value.ToString();
            txtNome.Text = dgvFuncionarios.SelectedRows[0].Cells["nome"].Value.ToString();
            txtEndereco.Text = dgvFuncionarios.SelectedRows[0].Cells["endereco"].Value.ToString();
            txtNumero.Text = dgvFuncionarios.SelectedRows[0].Cells["numero"].Value.ToString();
            txtCidade.Text = dgvFuncionarios.SelectedRows[0].Cells["cidade"].Value.ToString();
            txtEmail.Text = dgvFuncionarios.SelectedRows[0].Cells["email"].Value.ToString();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            limparControles();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {

                CAMADAS.MODEL.Funcionarios funcionario = new CAMADAS.MODEL.Funcionarios();
            CAMADAS.BLL.Funcionarios bllFuncionarios = new CAMADAS.BLL.Funcionarios();
            if (txtID.Text == "-1" && txtNome.Text != "" && txtEndereco.Text !=
            "" && txtNumero.Text != "" && txtCidade.Text != "" && txtEmail.Text != "")
            {
                //funcionario.usuario = txtUsuario.Text;
                //funcionario.senha = txtSenha.Text;
                funcionario.nome_vendedor = txtNome.Text;
                funcionario.endereco = txtEndereco.Text;
                funcionario.numero = Convert.ToInt32(txtNumero.Text);
                funcionario.cidade = txtCidade.Text;
                funcionario.email = txtEmail.Text;


                bllFuncionarios.Insert(funcionario);
                dgvFuncionarios.DataSource = "";
                dgvFuncionarios.DataSource = bllFuncionarios.Select();
                limparControles();

            }
            else
            {
                MessageBox.Show("É necessário preencher todos os campos.");
            }
        }


        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "-1" && txtNome.Text != "" && txtEndereco.Text !="" && txtNumero.Text != "" && txtCidade.Text != "" && txtEmail.Text != "")
            {
                CAMADAS.MODEL.Funcionarios funcionario = new CAMADAS.MODEL.Funcionarios();
                CAMADAS.BLL.Funcionarios bllFuncionario = new CAMADAS.BLL.Funcionarios();

                funcionario.id_vendedor = Convert.ToInt32(txtID.Text);
                funcionario.nome_vendedor = txtNome.Text;
                funcionario.endereco = txtEndereco.Text;
                funcionario.numero = Convert.ToInt32(txtNumero.Text);
                funcionario.cidade = txtCidade.Text;
                funcionario.email = txtEmail.Text;
                //funcionario.usuario = txtUsuario.Text;
                //funcionario.senha = txtSenha.Text;


                bllFuncionario.Update(funcionario);
                dgvFuncionarios.DataSource = "";
                dgvFuncionarios.DataSource = bllFuncionario.Select();
                limparControles();
            }
            else
            {
                MessageBox.Show("É necessário preencher todos os campos.");
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            int idFun = Convert.ToInt32(txtID.Text);
            CAMADAS.BLL.Funcionarios bllFun = new CAMADAS.BLL.Funcionarios();
            string msg = "Deseja remover o funcionário selecionado ?";
            DialogResult resp = MessageBox.Show(msg, "Remover", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2);
            if (resp == DialogResult.Yes)
                bllFun.Delete(idFun);

            dgvFuncionarios.DataSource = "";
            dgvFuncionarios.DataSource = bllFun.Select();
            limparControles();
        }


        private void txtID_TextChanged(object sender, EventArgs e)
        {
            if (txtID.Text != "-1")
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
            CAMADAS.BLL.Funcionarios bllFun = new CAMADAS.BLL.Funcionarios();
            dgvFuncionarios.DataSource = "";
            dgvFuncionarios.DataSource = bllFun.Select();
        }
    }
}
