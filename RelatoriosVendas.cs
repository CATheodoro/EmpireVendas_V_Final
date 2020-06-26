using EmpireVendas.CAMADAS.DAL;
using EmpireVendas.CAMADAS.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmpireVendas
{
    public partial class RelatoriosVendas : Form
    {
        public RelatoriosVendas()
        {
            InitializeComponent();
            txtIdVenda.Text = "-1";
        }

        private void Relatorios_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'eMPIREVENDASDataSet10.tb_vendas'. Você pode movê-la ou removê-la conforme necessário.
            //this.tb_vendasTableAdapter.Fill(this.eMPIREVENDASDataSet10.tb_vendas);
            CAMADAS.BLL.Vendas bllVendas = new CAMADAS.BLL.Vendas();
            //dgvVendas.DataSource = "";
            dgvVendas.DataSource = bllVendas.SelectWithInnerJoin();
            txtBusca.Focus();
        }

        private void dgvVendas_DoubleClick(object sender, EventArgs e)
        {
            try { 
            int id = 0;
            txtIdVenda.Text = dgvVendas.SelectedRows[0].Cells["id_venda"].Value.ToString();
            id = Convert.ToInt32(txtIdVenda.Text);
            EspelhoVendas abrir = new EspelhoVendas(id);
            abrir.Show();
            }
            catch
            {

            }


        }

        private void dgvVendas_MouseClick(object sender, MouseEventArgs e)
        {
            txtIdVenda.Text = dgvVendas.SelectedRows[0].Cells["id_venda"].Value.ToString();
        }

        private void btnIrEspelhoVendas_Click(object sender, EventArgs e)
        {
            if(txtIdVenda.ToString() != "")
            {
                int id = 0;
                id = Convert.ToInt32(txtIdVenda.Text);
                EspelhoVendas abrir = new EspelhoVendas(id);
                abrir.Show();
            }

        }

        private void txtIdVenda_TextChanged(object sender, EventArgs e)
        {
            if(txtIdVenda.Text == "-1")
            {
                btnIrEspelhoVendas.Enabled = false;
            }
            else
            {
                btnIrEspelhoVendas.Enabled = true;
            }
        }

        private void filtrar()
        {
            if(txtBusca.Text !="")
            {
                CAMADAS.BLL.Vendas bllVendas = new CAMADAS.BLL.Vendas();
                List<CAMADAS.MODEL.Vendas> lstVendas = new List<CAMADAS.MODEL.Vendas>();
                    
                if (rdbNomeCliente.Checked)
                    lstVendas = bllVendas.SelectWithInnerJoinByName(txtBusca.Text);
               

                else
                {
                    int id = Convert.ToInt32(txtBusca.Text);
                    lstVendas = bllVendas.SelectWithInnerJoinById(id);
                }
   
                dgvVendas.DataSource = "";
                dgvVendas.DataSource = lstVendas;
                if(dgvVendas.Rows.Count <= 0 || txtBusca.Text == "")
                {
                    MessageBox.Show("Não há vendas registradas!!!");
                    dgvVendas.DataSource = bllVendas.SelectWithInnerJoin();
                }
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            filtrar();
        }


        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            CAMADAS.BLL.Vendas bllVendas = new CAMADAS.BLL.Vendas();
            dgvVendas.DataSource = bllVendas.SelectWithInnerJoin();
        }

        private void txtBusca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true; e.SuppressKeyPress = true; txtBusca.Focus();
                filtrar();
            }
        }

        private void rdbNomeCliente_CheckedChanged(object sender, EventArgs e)
        {
            txtBusca.Text = "";
        }

        private void rdbCodigoVenda_CheckedChanged(object sender, EventArgs e)
        {
            txtBusca.Text = "";
        }

        private void txtBusca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && rdbCodigoVenda.Checked)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
            
        }

        private void btnGerarRelatorios_Click(object sender, EventArgs e)
        {
            if(dgvVendas.RowCount > 0)
            {
                RELATORIOS.RelGerais.relVendas();
            }
            else
            {
                MessageBox.Show("Não há Vendas Registradas!!!");
            }
        }
    }
}
