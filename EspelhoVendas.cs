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
    public partial class EspelhoVendas : Form
    {
        public EspelhoVendas()
        {
            InitializeComponent();
        }
        public EspelhoVendas(int id)
        {
            InitializeComponent();
            CAMADAS.BLL.ItensVenda itensVenda = new CAMADAS.BLL.ItensVenda();
            dgvEspelhoVenda.DataSource = itensVenda.SelectEspelhoVenda(id);
        }

        private void EspelhoVendas_Load(object sender, EventArgs e)
        {

        }

        private void IconFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnImprimir_Click_1(object sender, EventArgs e)
        {
            CAMADAS.BLL.Vendas idVenda = new CAMADAS.BLL.Vendas();
            int id = 0;
            if(dgvEspelhoVenda.Rows.Count > 0)
            {
                id = Convert.ToInt32(dgvEspelhoVenda.Rows[0].Cells[4].Value.ToString());
                RELATORIOS.RelGerais.relCupom(id);
            }
            else
            {
                MessageBox.Show("Não há Vendas Registradas!!!");
            }
        }
    }
}
