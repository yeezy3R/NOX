using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;

namespace StockFlow
{
    public partial class AdicionarProduto : Form
    {
        OleDbConnection conn;
        string caminhoFoto = "";

        // Abre a ligação apenas se estiver fechada
        private void AbrirLigacao()
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
        }

        // Fecha a ligação apenas se estiver aberta
        private void FecharLigacao()
        {
            if (conn.State != ConnectionState.Closed)
                conn.Close();
        }

        // Gera um código aleatório e garante que não existe na BD
        private string GerarCodigoUnico()
        {
            string codigo;
            Random rnd = new Random();

            // Reutiliza a connection string existente se disponível, senão constrói a partir do caminho da BD
            string connStr = conn?.ConnectionString;
            if (string.IsNullOrWhiteSpace(connStr))
            {
                string dbPath = Path.Combine(Application.StartupPath, "DB_StockFlow.accdb");
                connStr = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={dbPath};";
            }

            using (var localConn = new OleDbConnection(connStr))
            {
                localConn.Open();

                while (true)
                {
                    codigo = "P" + rnd.Next(100000, 999999).ToString();

                    using (var cmd = new OleDbCommand("SELECT COUNT(*) FROM INFOProduto WHERE CodigoProduto = ?", localConn))
                    {
                        cmd.Parameters.AddWithValue("?", codigo);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count == 0)
                            break;
                    }
                }
            }

            return codigo;
        }

        // Verifica se os campos estão preenchidos corretamente
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("O nome não pode estar vazio.");
                return false;
            }

            if (!double.TryParse(txtPreco.Text, out double preco) || preco < 0)
            {
                MessageBox.Show("Preço inválido.");
                return false;
            }

            if (!int.TryParse(txtQtd.Text, out int qtd) || qtd < 0)
            {
                MessageBox.Show("Quantidade inválida.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCategoria.Text))
            {
                MessageBox.Show("A categoria não pode estar vazia.");
                return false;
            }

            if (!int.TryParse(txtStockMinimo.Text, out int stockMin) || stockMin < 0)
            {
                MessageBox.Show("Stock mínimo inválido.");
                return false;
            }

            return true;
        }

        public AdicionarProduto()
        {
            InitializeComponent();

            // Caminho da base de dados
            string dbPath = Path.Combine(Application.StartupPath, "DB_StockFlow.accdb");

            conn = new OleDbConnection(
                $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={dbPath};"
            );

            // Ligações dos eventos
            this.Load += AdicionarProduto_Load;
            dataGridView1.CellClick += dataGridView1_CellClick;
            txtPesquisa.TextChanged += txtPesquisa_TextChanged;

           
            btnMostrarTodos.Click += btnMostrarTodos_Click;

        }

        // Carrega os produtos para o DataGridView
        private void AdicionarProduto_Load(object sender, EventArgs e)
        {
            CarregarProdutos();
        }

        private void CarregarProdutos(string filtro = "", bool apenasStockBaixo = false)
        {
            try
            {
                AbrirLigacao();

                string query = "SELECT * FROM INFOProduto WHERE 1=1";

                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    query += " AND (Nome LIKE ? OR CodigoProduto LIKE ? OR IDProduto LIKE ?)";
                }

                if (apenasStockBaixo)
                {
                    query += " AND Quantidade_Stock < StockMinimo";
                }

                OleDbCommand cmd = new OleDbCommand(query, conn);

                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    string like = "%" + filtro + "%";
                    cmd.Parameters.AddWithValue("?", like);
                    cmd.Parameters.AddWithValue("?", like);
                    cmd.Parameters.AddWithValue("?", like);
                }

                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                DataTable tabela = new DataTable();
                adapter.Fill(tabela);
                dataGridView1.DataSource = tabela;
            }
            finally
            {
                FecharLigacao();
            }
        }

        //Adiciona um novo produto à BD
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            try
            {
                AbrirLigacao();

                string query = "INSERT INTO INFOProduto " +
                               "(Nome, Preco, Quantidade_Stock, CodigoProduto, Categoria, StockMinimo, Foto, Ativo) " +
                               "VALUES (?, ?, ?, ?, ?, ?, ?, ?)";

                OleDbCommand cmd = new OleDbCommand(query, conn);

                cmd.Parameters.AddWithValue("?", txtNome.Text);
                cmd.Parameters.AddWithValue("?", Convert.ToDouble(txtPreco.Text));
                cmd.Parameters.AddWithValue("?", Convert.ToInt32(txtQtd.Text));
                cmd.Parameters.AddWithValue("?", GerarCodigoUnico());
                cmd.Parameters.AddWithValue("?", txtCategoria.Text);
                cmd.Parameters.AddWithValue("?", Convert.ToInt32(txtStockMinimo.Text));
                cmd.Parameters.AddWithValue("?", caminhoFoto);
                cmd.Parameters.AddWithValue("?", true);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                FecharLigacao();
            }

            CarregarProdutos(txtPesquisa.Text);

            txtNome.Clear();
            txtPreco.Clear();
            txtQtd.Clear();
            txtCategoria.Clear();
            txtStockMinimo.Clear();
            txtNome.Focus();
        }

        

        // Quando clicas numa linha, carrega os dados nos TextBox
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                txtNome.Text = row.Cells["Nome"].Value.ToString();
                txtPreco.Text = row.Cells["Preco"].Value.ToString();
                txtQtd.Text = row.Cells["Quantidade_Stock"].Value.ToString();
                txtCategoria.Text = row.Cells["Categoria"].Value.ToString();
                txtStockMinimo.Text = row.Cells["StockMinimo"].Value.ToString();
                caminhoFoto = row.Cells["Foto"].Value.ToString();
            }
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            CarregarProdutos(txtPesquisa.Text);
        }

       
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            txtPesquisa.Clear();
            CarregarProdutos();
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            try
            {
                AbrirLigacao();

                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IDProduto"].Value);

                string query = "DELETE FROM INFOProduto WHERE IDProduto = ?";
                OleDbCommand cmd = new OleDbCommand(query, conn);
                cmd.Parameters.AddWithValue("?", id);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                FecharLigacao();
            }

            CarregarProdutos(txtPesquisa.Text);
        }
         // Atualiza o produto selecionado com os dados dos TextBox
        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            {
                if (!ValidarCampos()) return;
                if (dataGridView1.CurrentRow == null) return;

                try
                {
                    AbrirLigacao();

                    int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IDProduto"].Value);

                    string query = "UPDATE INFOProduto SET " +
                                   "Nome = ?, Preco = ?, Quantidade_Stock = ?, CodigoProduto = ?, " +
                                   "Categoria = ?, StockMinimo = ?, Foto = ? " +
                                   "WHERE IDProduto = ?";

                    OleDbCommand cmd = new OleDbCommand(query, conn);

                    cmd.Parameters.AddWithValue("?", txtNome.Text);
                    cmd.Parameters.AddWithValue("?", Convert.ToDouble(txtPreco.Text));
                    cmd.Parameters.AddWithValue("?", Convert.ToInt32(txtQtd.Text));
                    cmd.Parameters.AddWithValue("?", GerarCodigoUnico());
                    cmd.Parameters.AddWithValue("?", txtCategoria.Text);
                    cmd.Parameters.AddWithValue("?", Convert.ToInt32(txtStockMinimo.Text));
                    cmd.Parameters.AddWithValue("?", caminhoFoto);
                    cmd.Parameters.AddWithValue("?", id);

                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    FecharLigacao();
                }

                CarregarProdutos(txtPesquisa.Text);
            }
        }

        private void btnStockBaixo_Click_1(object sender, EventArgs e)
        {
            CarregarProdutos(txtPesquisa.Text, true);
        }

        private void btnAlterarFoto_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Imagens|*.jpg;*.jpeg;*.png";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string pastaDestino = Path.Combine(Application.StartupPath, "ImagensProdutos");

                if (!Directory.Exists(pastaDestino))
                    Directory.CreateDirectory(pastaDestino);

                string nomeFicheiro = Path.GetFileName(ofd.FileName);
                string destinoFinal = Path.Combine(pastaDestino, nomeFicheiro);

                File.Copy(ofd.FileName, destinoFinal, true);

                caminhoFoto = nomeFicheiro;

                AbrirLigacao();

                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IDProduto"].Value);

                string query = "UPDATE INFOProduto SET Foto = ? WHERE IDProduto = ?";
                OleDbCommand cmd = new OleDbCommand(query, conn);

                cmd.Parameters.AddWithValue("?", caminhoFoto);
                cmd.Parameters.AddWithValue("?", id);

                cmd.ExecuteNonQuery();

                FecharLigacao();

                CarregarProdutos(txtPesquisa.Text);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            Login telaLogin = new Login();
            telaLogin.Show();
            this.Hide();
        }

        //apgar a foto colocada
        private void btnApagarFoto_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleciona um produto primeiro.");
                return;
            }

            var confirmacao = MessageBox.Show(
                "Tens a certeza que queres apagar a foto deste produto?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirmacao != DialogResult.Yes) return;

            try
            {
               
                if (!string.IsNullOrWhiteSpace(caminhoFoto))
                {
                    string caminhoCompleto = Path.Combine(
                        Application.StartupPath, "ImagensProdutos", caminhoFoto
                    );

                    if (File.Exists(caminhoCompleto))
                        File.Delete(caminhoCompleto);
                }

               
                caminhoFoto = "";

             
                AbrirLigacao();

                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IDProduto"].Value);

                string query = "UPDATE INFOProduto SET Foto = ? WHERE IDProduto = ?";
                OleDbCommand cmd = new OleDbCommand(query, conn);
                cmd.Parameters.AddWithValue("?", "");
                cmd.Parameters.AddWithValue("?", id);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Foto apagada com sucesso.");
                CarregarProdutos(txtPesquisa.Text);
            }
            finally
            {
                FecharLigacao();
            }
        }
        //ver a foto de perto
        private void btnVerFoto_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleciona um produto primeiro.");
                return;
            }

            if (string.IsNullOrWhiteSpace(caminhoFoto))
            {
                MessageBox.Show("Este produto não tem foto.");
                return;
            }

            string caminhoCompleto = Path.Combine(
                Application.StartupPath, "ImagensProdutos", caminhoFoto
            );

            if (!File.Exists(caminhoCompleto))
            {
                MessageBox.Show("Ficheiro não encontrado:\n" + caminhoCompleto);
                return;
            }

            try
            {
                System.Drawing.Image imagem;

                
                using (var stream = new FileStream(caminhoCompleto, FileMode.Open, FileAccess.Read))
                {
                    imagem = System.Drawing.Image.FromStream(stream);
                }

                Form janela = new Form();
                janela.Text = "Foto do Produto";
                janela.Size = new System.Drawing.Size(500, 500);
                janela.StartPosition = FormStartPosition.CenterScreen;
                janela.FormBorderStyle = FormBorderStyle.FixedDialog;
                janela.MaximizeBox = false;
                janela.MinimizeBox = false;

                PictureBox pb = new PictureBox();
                pb.Dock = DockStyle.Fill;
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                pb.Image = imagem;

                
                janela.FormClosed += (s, args) => imagem.Dispose();

                janela.Controls.Add(pb);
                janela.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao abrir a imagem:\n" + ex.Message);
            }
        }
    }
}