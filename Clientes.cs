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
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();
            limparControles();
        }

        private void limparControles()
        {
            txtID.Text = "-1";
            txtNome.Text = "";
            txtEndereco.Text = "";
            txtNumero.Text = "";
            txtCidade.Text = "";
            txtEmail.Text = "";
            txtCPF.Text = "";
        }

        private void Clientes_Load(object sender, EventArgs e)
        {

            CAMADAS.BLL.Clientes bllClientes = new CAMADAS.BLL.Clientes();
            dgvClientes.DataSource = "";
            dgvClientes.DataSource = bllClientes.Select();
            txtNome.Focus();
        }


        private void btnNovo_Click(object sender, EventArgs e)
        {
            limparControles();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {

            CAMADAS.MODEL.Clientes cliente = new CAMADAS.MODEL.Clientes();
            CAMADAS.BLL.Clientes bllCliente = new CAMADAS.BLL.Clientes();
            if (txtID.Text == "-1" && txtNome.Text != "" && txtEndereco.Text != 
                "" && txtNumero.Text != "" && txtCidade.Text != "" && txtEmail.Text != "" && txtCPF.Text != "")
            {

                cliente.nome = txtNome.Text;
                cliente.endereco = txtEndereco.Text;
                cliente.numero = Convert.ToInt32(txtNumero.Text);
                cliente.cidade = txtCidade.Text;
                cliente.email = txtEmail.Text;
                cliente.cpf = txtCPF.Text;
                bllCliente.Insert(cliente);

                dgvClientes.DataSource = "";
                dgvClientes.DataSource = bllCliente.Select();
                limparControles();
            }
            else
            {
                MessageBox.Show("Preencha todos os campos!");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "-1" && txtNome.Text != "" && txtEndereco.Text !=
    "" && txtNumero.Text != "" && txtCidade.Text != "" && txtEmail.Text != "" && txtCPF.Text != "")
            {
                CAMADAS.MODEL.Clientes cliente = new CAMADAS.MODEL.Clientes();
                CAMADAS.BLL.Clientes bllCliente = new CAMADAS.BLL.Clientes();

                cliente.id_cliente = Convert.ToInt32(txtID.Text);
                cliente.nome = txtNome.Text;
                cliente.endereco = txtEndereco.Text;
                cliente.numero = Convert.ToInt32(txtNumero.Text);
                cliente.cidade = txtCidade.Text;
                cliente.email = txtEmail.Text;
                cliente.cpf = txtCPF.Text;


                bllCliente.Update(cliente);
                dgvClientes.DataSource = "";
                dgvClientes.DataSource = bllCliente.Select();
                limparControles();
            }
            else
            {
                MessageBox.Show("Preencha todos os campos.");
            }
        }

        private void dgvClientes_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                txtID.Text = dgvClientes.SelectedRows[0].Cells["id_cliente"].Value.ToString();
                txtNome.Text = dgvClientes.SelectedRows[0].Cells["nome"].Value.ToString();
                txtEndereco.Text = dgvClientes.SelectedRows[0].Cells["endereco"].Value.ToString();
                txtNumero.Text = dgvClientes.SelectedRows[0].Cells["numero"].Value.ToString();
                txtCidade.Text = dgvClientes.SelectedRows[0].Cells["cidade"].Value.ToString();
                txtEmail.Text = dgvClientes.SelectedRows[0].Cells["email"].Value.ToString();
                txtCPF.Text = dgvClientes.SelectedRows[0].Cells["cpf"].Value.ToString();
            }
            catch
            {

            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            int idCli = Convert.ToInt32(txtID.Text);
            CAMADAS.BLL.Clientes bllCli = new CAMADAS.BLL.Clientes();
            string msg = "Deseja remover o cliente selecionado ?";
            DialogResult resp = MessageBox.Show(msg, "Remover", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2);
            if (resp == DialogResult.Yes)
                bllCli.Delete(idCli);

            dgvClientes.DataSource = "";
            dgvClientes.DataSource = bllCli.Select();
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
            CAMADAS.BLL.Clientes bllCli = new CAMADAS.BLL.Clientes();
            dgvClientes.DataSource = "";
            dgvClientes.DataSource = bllCli.Select();
        }
    }

}