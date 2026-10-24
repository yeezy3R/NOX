namespace StockFlow
{
    partial class AdicionarProduto
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtStockMinimo = new System.Windows.Forms.TextBox();
            this.txtCategoria = new System.Windows.Forms.TextBox();
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            this.btnStockBaixo = new System.Windows.Forms.Button();
            this.btnMostrarTodos = new System.Windows.Forms.Button();
            this.btnAlterarFoto = new System.Windows.Forms.Button();
            this.lblPesquisar = new System.Windows.Forms.Label();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.lblStockMinimo = new System.Windows.Forms.Label();
            this.lblQtd = new System.Windows.Forms.Label();
            this.lblPreco = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.txtQtd = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtPreco = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnApagarFoto = new System.Windows.Forms.Button();
            this.btnVerFoto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.Font = new System.Drawing.Font("Perpetua Titling MT", 16F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(-10, 731);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(221, 44);
            this.button1.TabIndex = 42;
            this.button1.Text = "Voltar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtStockMinimo
            // 
            this.txtStockMinimo.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtStockMinimo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStockMinimo.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.txtStockMinimo.Location = new System.Drawing.Point(250, 678);
            this.txtStockMinimo.Margin = new System.Windows.Forms.Padding(4);
            this.txtStockMinimo.Name = "txtStockMinimo";
            this.txtStockMinimo.Size = new System.Drawing.Size(332, 26);
            this.txtStockMinimo.TabIndex = 41;
            // 
            // txtCategoria
            // 
            this.txtCategoria.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategoria.ForeColor = System.Drawing.SystemColors.Menu;
            this.txtCategoria.Location = new System.Drawing.Point(250, 643);
            this.txtCategoria.Margin = new System.Windows.Forms.Padding(4);
            this.txtCategoria.Name = "txtCategoria";
            this.txtCategoria.Size = new System.Drawing.Size(332, 26);
            this.txtCategoria.TabIndex = 40;
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.BackColor = System.Drawing.SystemColors.InfoText;
            this.txtPesquisa.ForeColor = System.Drawing.Color.White;
            this.txtPesquisa.Location = new System.Drawing.Point(1093, 470);
            this.txtPesquisa.Margin = new System.Windows.Forms.Padding(4);
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(332, 22);
            this.txtPesquisa.TabIndex = 39;
            // 
            // btnStockBaixo
            // 
            this.btnStockBaixo.BackColor = System.Drawing.Color.Black;
            this.btnStockBaixo.Font = new System.Drawing.Font("Microsoft Uighur", 19.8F);
            this.btnStockBaixo.ForeColor = System.Drawing.SystemColors.Control;
            this.btnStockBaixo.Location = new System.Drawing.Point(1210, 502);
            this.btnStockBaixo.Margin = new System.Windows.Forms.Padding(4);
            this.btnStockBaixo.Name = "btnStockBaixo";
            this.btnStockBaixo.Size = new System.Drawing.Size(109, 47);
            this.btnStockBaixo.TabIndex = 38;
            this.btnStockBaixo.Text = "Stock Baixo";
            this.btnStockBaixo.UseVisualStyleBackColor = false;
            this.btnStockBaixo.Click += new System.EventHandler(this.btnStockBaixo_Click_1);
            // 
            // btnMostrarTodos
            // 
            this.btnMostrarTodos.BackColor = System.Drawing.Color.Black;
            this.btnMostrarTodos.Font = new System.Drawing.Font("Microsoft Uighur", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMostrarTodos.ForeColor = System.Drawing.SystemColors.Control;
            this.btnMostrarTodos.Location = new System.Drawing.Point(1093, 502);
            this.btnMostrarTodos.Margin = new System.Windows.Forms.Padding(4);
            this.btnMostrarTodos.Name = "btnMostrarTodos";
            this.btnMostrarTodos.Size = new System.Drawing.Size(109, 47);
            this.btnMostrarTodos.TabIndex = 37;
            this.btnMostrarTodos.Text = "Mostrar Todos";
            this.btnMostrarTodos.UseVisualStyleBackColor = false;
            // 
            // btnAlterarFoto
            // 
            this.btnAlterarFoto.BackColor = System.Drawing.Color.Black;
            this.btnAlterarFoto.Font = new System.Drawing.Font("Perpetua Titling MT", 16F, System.Drawing.FontStyle.Bold);
            this.btnAlterarFoto.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAlterarFoto.Location = new System.Drawing.Point(760, 531);
            this.btnAlterarFoto.Margin = new System.Windows.Forms.Padding(4);
            this.btnAlterarFoto.Name = "btnAlterarFoto";
            this.btnAlterarFoto.Size = new System.Drawing.Size(299, 63);
            this.btnAlterarFoto.TabIndex = 35;
            this.btnAlterarFoto.Text = "Adicionar Foto";
            this.btnAlterarFoto.UseVisualStyleBackColor = false;
            this.btnAlterarFoto.Click += new System.EventHandler(this.btnAlterarFoto_Click_1);
            // 
            // lblPesquisar
            // 
            this.lblPesquisar.AutoSize = true;
            this.lblPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPesquisar.ForeColor = System.Drawing.SystemColors.Control;
            this.lblPesquisar.Location = new System.Drawing.Point(904, 464);
            this.lblPesquisar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPesquisar.Name = "lblPesquisar";
            this.lblPesquisar.Size = new System.Drawing.Size(155, 36);
            this.lblPesquisar.TabIndex = 34;
            this.lblPesquisar.Text = "Pesquisa:";
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoria.ForeColor = System.Drawing.SystemColors.Control;
            this.lblCategoria.Location = new System.Drawing.Point(40, 630);
            this.lblCategoria.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(161, 36);
            this.lblCategoria.TabIndex = 33;
            this.lblCategoria.Text = "Categoria:";
            // 
            // lblStockMinimo
            // 
            this.lblStockMinimo.AutoSize = true;
            this.lblStockMinimo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStockMinimo.ForeColor = System.Drawing.SystemColors.Control;
            this.lblStockMinimo.Location = new System.Drawing.Point(-13, 671);
            this.lblStockMinimo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStockMinimo.Name = "lblStockMinimo";
            this.lblStockMinimo.Size = new System.Drawing.Size(215, 36);
            this.lblStockMinimo.TabIndex = 32;
            this.lblStockMinimo.Text = "Stock Minimo:";
            // 
            // lblQtd
            // 
            this.lblQtd.AutoSize = true;
            this.lblQtd.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQtd.ForeColor = System.Drawing.SystemColors.Control;
            this.lblQtd.Location = new System.Drawing.Point(14, 600);
            this.lblQtd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQtd.Name = "lblQtd";
            this.lblQtd.Size = new System.Drawing.Size(187, 36);
            this.lblQtd.TabIndex = 31;
            this.lblQtd.Text = "Quantidade:";
            // 
            // lblPreco
            // 
            this.lblPreco.AutoSize = true;
            this.lblPreco.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPreco.ForeColor = System.Drawing.Color.White;
            this.lblPreco.Location = new System.Drawing.Point(94, 564);
            this.lblPreco.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPreco.Name = "lblPreco";
            this.lblPreco.Size = new System.Drawing.Size(107, 36);
            this.lblPreco.TabIndex = 30;
            this.lblPreco.Text = "Preço:";
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNome.ForeColor = System.Drawing.Color.White;
            this.lblNome.Location = new System.Drawing.Point(94, 528);
            this.lblNome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(106, 36);
            this.lblNome.TabIndex = 29;
            this.lblNome.Text = "Nome:";
            // 
            // txtQtd
            // 
            this.txtQtd.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtQtd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQtd.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.txtQtd.Location = new System.Drawing.Point(250, 607);
            this.txtQtd.Margin = new System.Windows.Forms.Padding(4);
            this.txtQtd.Name = "txtQtd";
            this.txtQtd.Size = new System.Drawing.Size(332, 26);
            this.txtQtd.TabIndex = 28;
            // 
            // txtNome
            // 
            this.txtNome.BackColor = System.Drawing.SystemColors.InfoText;
            this.txtNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.ForeColor = System.Drawing.Color.White;
            this.txtNome.Location = new System.Drawing.Point(250, 536);
            this.txtNome.Margin = new System.Windows.Forms.Padding(4);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(332, 26);
            this.txtNome.TabIndex = 27;
            // 
            // txtPreco
            // 
            this.txtPreco.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtPreco.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPreco.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.txtPreco.Location = new System.Drawing.Point(250, 568);
            this.txtPreco.Margin = new System.Windows.Forms.Padding(4);
            this.txtPreco.Name = "txtPreco";
            this.txtPreco.Size = new System.Drawing.Size(332, 26);
            this.txtPreco.TabIndex = 26;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Black;
            this.btnDelete.Font = new System.Drawing.Font("Perpetua Titling MT", 16F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(582, 448);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(204, 70);
            this.btnDelete.TabIndex = 25;
            this.btnDelete.Text = "Apagar";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click_1);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.Black;
            this.btnRefresh.Font = new System.Drawing.Font("Perpetua Titling MT", 16F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(286, 447);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(288, 71);
            this.btnRefresh.TabIndex = 24;
            this.btnRefresh.Text = "Atualizar Lista";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click_1);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Black;
            this.btnAdd.Font = new System.Drawing.Font("Perpetua Titling MT", 16F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(-10, 447);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(288, 70);
            this.btnAdd.TabIndex = 23;
            this.btnAdd.Text = "Adicionar";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(18, 14);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1919, 426);
            this.dataGridView1.TabIndex = 22;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // btnApagarFoto
            // 
            this.btnApagarFoto.BackColor = System.Drawing.Color.Black;
            this.btnApagarFoto.Font = new System.Drawing.Font("Perpetua Titling MT", 16F, System.Drawing.FontStyle.Bold);
            this.btnApagarFoto.ForeColor = System.Drawing.SystemColors.Control;
            this.btnApagarFoto.Location = new System.Drawing.Point(760, 602);
            this.btnApagarFoto.Margin = new System.Windows.Forms.Padding(4);
            this.btnApagarFoto.Name = "btnApagarFoto";
            this.btnApagarFoto.Size = new System.Drawing.Size(299, 63);
            this.btnApagarFoto.TabIndex = 43;
            this.btnApagarFoto.Text = "Apagar Foto";
            this.btnApagarFoto.UseVisualStyleBackColor = false;
            this.btnApagarFoto.Click += new System.EventHandler(this.btnApagarFoto_Click);
            // 
            // btnVerFoto
            // 
            this.btnVerFoto.BackColor = System.Drawing.Color.Black;
            this.btnVerFoto.Font = new System.Drawing.Font("Perpetua Titling MT", 16F, System.Drawing.FontStyle.Bold);
            this.btnVerFoto.ForeColor = System.Drawing.SystemColors.Control;
            this.btnVerFoto.Location = new System.Drawing.Point(760, 678);
            this.btnVerFoto.Margin = new System.Windows.Forms.Padding(4);
            this.btnVerFoto.Name = "btnVerFoto";
            this.btnVerFoto.Size = new System.Drawing.Size(299, 63);
            this.btnVerFoto.TabIndex = 44;
            this.btnVerFoto.Text = "Ver Foto";
            this.btnVerFoto.UseVisualStyleBackColor = false;
            this.btnVerFoto.Click += new System.EventHandler(this.btnVerFoto_Click);
            // 
            // AdicionarProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1924, 789);
            this.Controls.Add(this.btnVerFoto);
            this.Controls.Add(this.btnApagarFoto);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtStockMinimo);
            this.Controls.Add(this.txtCategoria);
            this.Controls.Add(this.txtPesquisa);
            this.Controls.Add(this.btnStockBaixo);
            this.Controls.Add(this.btnMostrarTodos);
            this.Controls.Add(this.btnAlterarFoto);
            this.Controls.Add(this.lblPesquisar);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.lblStockMinimo);
            this.Controls.Add(this.lblQtd);
            this.Controls.Add(this.lblPreco);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.txtQtd);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.txtPreco);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AdicionarProduto";
            this.Text = "AdicionarProduto";
            this.Load += new System.EventHandler(this.AdicionarProduto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtStockMinimo;
        private System.Windows.Forms.TextBox txtCategoria;
        private System.Windows.Forms.TextBox txtPesquisa;
        private System.Windows.Forms.Button btnStockBaixo;
        private System.Windows.Forms.Button btnMostrarTodos;
        private System.Windows.Forms.Button btnAlterarFoto;
        private System.Windows.Forms.Label lblPesquisar;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.Label lblStockMinimo;
        private System.Windows.Forms.Label lblQtd;
        private System.Windows.Forms.Label lblPreco;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtQtd;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtPreco;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnApagarFoto;
        private System.Windows.Forms.Button btnVerFoto;
    }
}