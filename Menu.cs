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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            pictureBox1_Click(null, e);
            txtPaginaInicial.ForeColor = Color.Orange;
            txtData.Text = DateTime.Now.ToString("dd/MM/yyyy");
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            abrirFormInPanel(new PaginaInicial());
            btnProdutos.ForeColor = Color.White;
            btnVendas.ForeColor = Color.White;
            btnCategorias.ForeColor = Color.White;
            btnClientes.ForeColor = Color.White;
            btnFuncionarios.ForeColor = Color.White;
            btnRelatorios.ForeColor = Color.White;
            txtPaginaInicial.ForeColor = Color.Orange;
            /*if(PanelVertical.Width  == 250)
            {
                PanelVertical.Width = 65;
            }
            else
            {
                PanelVertical.Width = 250;
            }*/
        }

        private void IconFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void IconMax_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            IconRestaurar.Visible = true;
            IconMax.Visible = false;
        }

        private void IconRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            IconRestaurar.Visible = false;
            IconMax.Visible = true;
        }

        private void IconMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            abrirFormInPanel(new Funcionarios());
            btnProdutos.ForeColor = Color.White;
            btnVendas.ForeColor = Color.White;
            btnCategorias.ForeColor = Color.White;
            btnClientes.ForeColor = Color.White;
            btnFuncionarios.ForeColor = Color.Orange;
            btnRelatorios.ForeColor = Color.White;
            txtPaginaInicial.ForeColor = Color.White;
        }

        //função que faz com os forms abram no painel menu
        private void abrirFormInPanel(object forms)
        {
            
            if(this.PanelContainer.Controls.Count > 0)
            {
                this.PanelContainer.Controls.RemoveAt(0);
            }
            Form fh = forms as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.PanelContainer.Controls.Add(fh);
            this.PanelContainer.Tag = fh;
            fh.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //chamando a função para abrir o form produto no menu
            abrirFormInPanel(new frmProdutos());
            btnProdutos.ForeColor = Color.Orange;
            btnVendas.ForeColor = Color.White;
            btnCategorias.ForeColor = Color.White;
            btnClientes.ForeColor = Color.White;
            btnFuncionarios.ForeColor = Color.White;
            btnRelatorios.ForeColor = Color.White;
            txtPaginaInicial.ForeColor = Color.White;

        }

        private void btnVendas_Click(object sender, EventArgs e)
        {
            abrirFormInPanel(new Vendas());
            btnProdutos.ForeColor = Color.White;
            btnVendas.ForeColor = Color.Orange;
            btnCategorias.ForeColor = Color.White;
            btnClientes.ForeColor = Color.White;
            btnFuncionarios.ForeColor = Color.White;
            btnRelatorios.ForeColor = Color.White;
            txtPaginaInicial.ForeColor = Color.White;

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if(PanelVertical.BackColor == Color.Black)
            {
                PanelVertical.BackColor = Color.FromArgb(22, 92, 124);
                PanelSuperior.BackColor = Color.FromArgb(22, 92, 124);
            }
            else 
            { 
            PanelVertical.BackColor = Color.Black;
            PanelSuperior.BackColor = Color.Black;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            abrirFormInPanel(new Categorias());
            btnProdutos.ForeColor = Color.White;
            btnVendas.ForeColor = Color.White;
            btnCategorias.ForeColor = Color.Orange;
            btnClientes.ForeColor = Color.White;
            btnFuncionarios.ForeColor = Color.White;
            btnRelatorios.ForeColor = Color.White;
            txtPaginaInicial.ForeColor = Color.White;

        }

        private void btnRelatorios_Click(object sender, EventArgs e)
        {
            abrirFormInPanel(new RelatoriosVendas());
            btnProdutos.ForeColor = Color.White;
            btnVendas.ForeColor = Color.White;
            btnCategorias.ForeColor = Color.White;
            btnClientes.ForeColor = Color.White;
            btnFuncionarios.ForeColor = Color.White;
            btnRelatorios.ForeColor = Color.Orange;
            txtPaginaInicial.ForeColor = Color.White;
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            abrirFormInPanel(new Clientes());
            btnProdutos.ForeColor = Color.White;
            btnVendas.ForeColor = Color.White;
            btnCategorias.ForeColor = Color.White;
            btnClientes.ForeColor = Color.Orange;
            btnFuncionarios.ForeColor = Color.White;
            btnRelatorios.ForeColor = Color.White;
            txtPaginaInicial.ForeColor = Color.White;
        }

        private void PanelContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            abrirFormInPanel(new PaginaInicial());
            btnProdutos.ForeColor = Color.White;
            btnVendas.ForeColor = Color.White;
            btnCategorias.ForeColor = Color.White;
            btnClientes.ForeColor = Color.White;
            btnFuncionarios.ForeColor = Color.White;
            btnRelatorios.ForeColor = Color.White;
            txtPaginaInicial.ForeColor = Color.Orange;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            txtHora.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
        }

        private void PanelSuperior_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
