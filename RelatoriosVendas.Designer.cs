namespace EmpireVendas
{
    partial class RelatoriosVendas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RelatoriosVendas));
            this.dgvVendas = new System.Windows.Forms.DataGridView();
            this.id_venda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtBusca = new System.Windows.Forms.TextBox();
            this.txtIdVenda = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.rdbCodigoVenda = new System.Windows.Forms.RadioButton();
            this.rdbNomeCliente = new System.Windows.Forms.RadioButton();
            this.btnGerarRelatorios = new System.Windows.Forms.Button();
            this.btnIrEspelhoVendas = new System.Windows.Forms.Button();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.idvendaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descontoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorfinalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descclienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descvendedorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idclienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idvendedorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvVendas
            // 
            this.dgvVendas.AllowUserToAddRows = false;
            this.dgvVendas.AllowUserToDeleteRows = false;
            this.dgvVendas.AutoGenerateColumns = false;
            this.dgvVendas.BackgroundColor = System.Drawing.Color.White;
            this.dgvVendas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvVendas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVendas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvVendas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVendas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idvendaDataGridViewTextBoxColumn,
            this.descontoDataGridViewTextBoxColumn,
            this.valorfinalDataGridViewTextBoxColumn,
            this.dataDataGridViewTextBoxColumn,
            this.descclienteDataGridViewTextBoxColumn,
            this.descvendedorDataGridViewTextBoxColumn,
            this.id_venda,
            this.idclienteDataGridViewTextBoxColumn,
            this.idvendedorDataGridViewTextBoxColumn});
            this.dgvVendas.DataSource = this.vendasBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVendas.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvVendas.EnableHeadersVisualStyles = false;
            this.dgvVendas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.dgvVendas.Location = new System.Drawing.Point(12, 209);
            this.dgvVendas.Name = "dgvVendas";
            this.dgvVendas.ReadOnly = true;
            this.dgvVendas.RowHeadersVisible = false;
            this.dgvVendas.RowHeadersWidth = 51;
            this.dgvVendas.RowTemplate.Height = 24;
            this.dgvVendas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVendas.Size = new System.Drawing.Size(1015, 333);
            this.dgvVendas.TabIndex = 0;
            this.dgvVendas.DoubleClick += new System.EventHandler(this.dgvVendas_DoubleClick);
            this.dgvVendas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvVendas_MouseClick);
            // 
            // id_venda
            // 
            this.id_venda.DataPropertyName = "id_venda";
            this.id_venda.HeaderText = "id_venda";
            this.id_venda.MinimumWidth = 6;
            this.id_venda.Name = "id_venda";
            this.id_venda.ReadOnly = true;
            this.id_venda.Visible = false;
            this.id_venda.Width = 125;
            // 
            // txtBusca
            // 
            this.txtBusca.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBusca.Location = new System.Drawing.Point(390, 130);
            this.txtBusca.Name = "txtBusca";
            this.txtBusca.Size = new System.Drawing.Size(280, 34);
            this.txtBusca.TabIndex = 2;
            this.txtBusca.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBusca_KeyDown);
            this.txtBusca.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBusca_KeyPress);
            // 
            // txtIdVenda
            // 
            this.txtIdVenda.Enabled = false;
            this.txtIdVenda.Location = new System.Drawing.Point(0, 12);
            this.txtIdVenda.Name = "txtIdVenda";
            this.txtIdVenda.Size = new System.Drawing.Size(46, 22);
            this.txtIdVenda.TabIndex = 3;
            this.txtIdVenda.Visible = false;
            this.txtIdVenda.TextChanged += new System.EventHandler(this.txtIdVenda_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(462, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 54);
            this.label2.TabIndex = 27;
            this.label2.Text = "Vendas";
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.BackColor = System.Drawing.Color.White;
            this.btnFiltrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFiltrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnFiltrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnFiltrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrar.ForeColor = System.Drawing.Color.Black;
            this.btnFiltrar.Image = ((System.Drawing.Image)(resources.GetObject("btnFiltrar.Image")));
            this.btnFiltrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFiltrar.Location = new System.Drawing.Point(669, 130);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnFiltrar.Size = new System.Drawing.Size(30, 29);
            this.btnFiltrar.TabIndex = 28;
            this.btnFiltrar.UseVisualStyleBackColor = false;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // rdbCodigoVenda
            // 
            this.rdbCodigoVenda.AutoSize = true;
            this.rdbCodigoVenda.Location = new System.Drawing.Point(561, 170);
            this.rdbCodigoVenda.Name = "rdbCodigoVenda";
            this.rdbCodigoVenda.Size = new System.Drawing.Size(138, 21);
            this.rdbCodigoVenda.TabIndex = 30;
            this.rdbCodigoVenda.Text = "Código da Venda";
            this.rdbCodigoVenda.UseVisualStyleBackColor = true;
            this.rdbCodigoVenda.CheckedChanged += new System.EventHandler(this.rdbCodigoVenda_CheckedChanged);
            // 
            // rdbNomeCliente
            // 
            this.rdbNomeCliente.AutoSize = true;
            this.rdbNomeCliente.Checked = true;
            this.rdbNomeCliente.Location = new System.Drawing.Point(390, 170);
            this.rdbNomeCliente.Name = "rdbNomeCliente";
            this.rdbNomeCliente.Size = new System.Drawing.Size(133, 21);
            this.rdbNomeCliente.TabIndex = 31;
            this.rdbNomeCliente.TabStop = true;
            this.rdbNomeCliente.Text = "Nome do Cliente";
            this.rdbNomeCliente.UseVisualStyleBackColor = true;
            this.rdbNomeCliente.CheckedChanged += new System.EventHandler(this.rdbNomeCliente_CheckedChanged);
            // 
            // btnGerarRelatorios
            // 
            this.btnGerarRelatorios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(204)))));
            this.btnGerarRelatorios.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnGerarRelatorios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGerarRelatorios.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(204)))));
            this.btnGerarRelatorios.FlatAppearance.BorderSize = 0;
            this.btnGerarRelatorios.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(204)))));
            this.btnGerarRelatorios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(204)))));
            this.btnGerarRelatorios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGerarRelatorios.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGerarRelatorios.ForeColor = System.Drawing.Color.White;
            this.btnGerarRelatorios.Image = ((System.Drawing.Image)(resources.GetObject("btnGerarRelatorios.Image")));
            this.btnGerarRelatorios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGerarRelatorios.Location = new System.Drawing.Point(732, 548);
            this.btnGerarRelatorios.Name = "btnGerarRelatorios";
            this.btnGerarRelatorios.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnGerarRelatorios.Size = new System.Drawing.Size(295, 42);
            this.btnGerarRelatorios.TabIndex = 43;
            this.btnGerarRelatorios.Text = "GERAR RELATÓRIOS";
            this.btnGerarRelatorios.UseVisualStyleBackColor = false;
            this.btnGerarRelatorios.Click += new System.EventHandler(this.btnGerarRelatorios_Click);
            // 
            // btnIrEspelhoVendas
            // 
            this.btnIrEspelhoVendas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(204)))));
            this.btnIrEspelhoVendas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnIrEspelhoVendas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIrEspelhoVendas.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(204)))));
            this.btnIrEspelhoVendas.FlatAppearance.BorderSize = 0;
            this.btnIrEspelhoVendas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(204)))));
            this.btnIrEspelhoVendas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(204)))));
            this.btnIrEspelhoVendas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIrEspelhoVendas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIrEspelhoVendas.ForeColor = System.Drawing.Color.White;
            this.btnIrEspelhoVendas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIrEspelhoVendas.Location = new System.Drawing.Point(12, 548);
            this.btnIrEspelhoVendas.Name = "btnIrEspelhoVendas";
            this.btnIrEspelhoVendas.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnIrEspelhoVendas.Size = new System.Drawing.Size(295, 42);
            this.btnIrEspelhoVendas.TabIndex = 44;
            this.btnIrEspelhoVendas.Text = "VER DADOS DA COMPRA";
            this.btnIrEspelhoVendas.UseVisualStyleBackColor = false;
            this.btnIrEspelhoVendas.Click += new System.EventHandler(this.btnIrEspelhoVendas_Click);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(204)))));
            this.btnAtualizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAtualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAtualizar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(204)))));
            this.btnAtualizar.FlatAppearance.BorderSize = 0;
            this.btnAtualizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(204)))));
            this.btnAtualizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(204)))));
            this.btnAtualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtualizar.ForeColor = System.Drawing.Color.White;
            this.btnAtualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnAtualizar.Image")));
            this.btnAtualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAtualizar.Location = new System.Drawing.Point(882, 158);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnAtualizar.Size = new System.Drawing.Size(145, 42);
            this.btnAtualizar.TabIndex = 45;
            this.btnAtualizar.Text = "ATUALIZAR";
            this.btnAtualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAtualizar.UseVisualStyleBackColor = false;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // idvendaDataGridViewTextBoxColumn
            // 
            this.idvendaDataGridViewTextBoxColumn.DataPropertyName = "id_venda";
            this.idvendaDataGridViewTextBoxColumn.HeaderText = "ID VENDA";
            this.idvendaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idvendaDataGridViewTextBoxColumn.Name = "idvendaDataGridViewTextBoxColumn";
            this.idvendaDataGridViewTextBoxColumn.ReadOnly = true;
            this.idvendaDataGridViewTextBoxColumn.Width = 125;
            // 
            // descontoDataGridViewTextBoxColumn
            // 
            this.descontoDataGridViewTextBoxColumn.DataPropertyName = "desconto";
            this.descontoDataGridViewTextBoxColumn.HeaderText = "DESCONTO";
            this.descontoDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.descontoDataGridViewTextBoxColumn.Name = "descontoDataGridViewTextBoxColumn";
            this.descontoDataGridViewTextBoxColumn.ReadOnly = true;
            this.descontoDataGridViewTextBoxColumn.Width = 125;
            // 
            // valorfinalDataGridViewTextBoxColumn
            // 
            this.valorfinalDataGridViewTextBoxColumn.DataPropertyName = "valor_final";
            this.valorfinalDataGridViewTextBoxColumn.HeaderText = "VALOR FINAL";
            this.valorfinalDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.valorfinalDataGridViewTextBoxColumn.Name = "valorfinalDataGridViewTextBoxColumn";
            this.valorfinalDataGridViewTextBoxColumn.ReadOnly = true;
            this.valorfinalDataGridViewTextBoxColumn.Width = 150;
            // 
            // dataDataGridViewTextBoxColumn
            // 
            this.dataDataGridViewTextBoxColumn.DataPropertyName = "data";
            this.dataDataGridViewTextBoxColumn.HeaderText = "DATA";
            this.dataDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.dataDataGridViewTextBoxColumn.Name = "dataDataGridViewTextBoxColumn";
            this.dataDataGridViewTextBoxColumn.ReadOnly = true;
            this.dataDataGridViewTextBoxColumn.Width = 125;
            // 
            // descclienteDataGridViewTextBoxColumn
            // 
            this.descclienteDataGridViewTextBoxColumn.DataPropertyName = "desc_cliente";
            this.descclienteDataGridViewTextBoxColumn.HeaderText = "CLIENTE";
            this.descclienteDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.descclienteDataGridViewTextBoxColumn.Name = "descclienteDataGridViewTextBoxColumn";
            this.descclienteDataGridViewTextBoxColumn.ReadOnly = true;
            this.descclienteDataGridViewTextBoxColumn.Width = 250;
            // 
            // descvendedorDataGridViewTextBoxColumn
            // 
            this.descvendedorDataGridViewTextBoxColumn.DataPropertyName = "desc_vendedor";
            this.descvendedorDataGridViewTextBoxColumn.HeaderText = "VENDEDOR";
            this.descvendedorDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.descvendedorDataGridViewTextBoxColumn.Name = "descvendedorDataGridViewTextBoxColumn";
            this.descvendedorDataGridViewTextBoxColumn.ReadOnly = true;
            this.descvendedorDataGridViewTextBoxColumn.Width = 250;
            // 
            // idclienteDataGridViewTextBoxColumn
            // 
            this.idclienteDataGridViewTextBoxColumn.DataPropertyName = "id_cliente";
            this.idclienteDataGridViewTextBoxColumn.HeaderText = "id_cliente";
            this.idclienteDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idclienteDataGridViewTextBoxColumn.Name = "idclienteDataGridViewTextBoxColumn";
            this.idclienteDataGridViewTextBoxColumn.ReadOnly = true;
            this.idclienteDataGridViewTextBoxColumn.Visible = false;
            this.idclienteDataGridViewTextBoxColumn.Width = 125;
            // 
            // idvendedorDataGridViewTextBoxColumn
            // 
            this.idvendedorDataGridViewTextBoxColumn.DataPropertyName = "id_vendedor";
            this.idvendedorDataGridViewTextBoxColumn.HeaderText = "id_vendedor";
            this.idvendedorDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idvendedorDataGridViewTextBoxColumn.Name = "idvendedorDataGridViewTextBoxColumn";
            this.idvendedorDataGridViewTextBoxColumn.ReadOnly = true;
            this.idvendedorDataGridViewTextBoxColumn.Visible = false;
            this.idvendedorDataGridViewTextBoxColumn.Width = 125;
            // 
            // vendasBindingSource
            // 
            this.vendasBindingSource.DataSource = typeof(EmpireVendas.CAMADAS.MODEL.Vendas);
            // 
            // RelatoriosVendas
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1039, 600);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.btnIrEspelhoVendas);
            this.Controls.Add(this.btnGerarRelatorios);
            this.Controls.Add(this.rdbNomeCliente);
            this.Controls.Add(this.rdbCodigoVenda);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIdVenda);
            this.Controls.Add(this.txtBusca);
            this.Controls.Add(this.dgvVendas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RelatoriosVendas";
            this.Text = "Relatorios";
            this.Load += new System.EventHandler(this.Relatorios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendasBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvVendas;
        private System.Windows.Forms.TextBox txtBusca;
        private System.Windows.Forms.TextBox txtIdVenda;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.RadioButton rdbCodigoVenda;
        private System.Windows.Forms.RadioButton rdbNomeCliente;
        private System.Windows.Forms.Button btnGerarRelatorios;
        private System.Windows.Forms.Button btnIrEspelhoVendas;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.BindingSource vendasBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idvendaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descontoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorfinalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descclienteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descvendedorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_venda;
        private System.Windows.Forms.DataGridViewTextBoxColumn idclienteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idvendedorDataGridViewTextBoxColumn;
    }
}