using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace StockFlow
{
    public partial class AdicionarProduto : Form
    {
        // 🔗 Conexão correta com Access
        OleDbConnection conn = new OleDbConnection(
            @"Provider=Microsoft.ACE.OLEDB.12.0;
              Data Source=|DataDirectory|\DB_StockFlow.accdb;"
        );

        public AdicionarProduto()
        {
            InitializeComponent();
        }

        // 📥 CARREGAR PRODUTOS
        private void CarregarProdutos()
        {
            try
            {
                conn.Open();

                string query = "SELECT * FROM INFOProduto";

                OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);

                DataTable tabela = new DataTable();
                adapter.Fill(tabela);

                dataGridView1.DataSource = tabela;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar produtos: " + ex.Message);
                conn.Close();
            }
        }

        // 🚀 AO ABRIR FORM
        private void Form1_Load(object sender, EventArgs e)
        {
            CarregarProdutos();
        }

        // ➕ ADICIONAR PRODUTO
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                string query = "INSERT INTO Produtos (Nome, Preco, Quantidade, CodigoProduto, Ativo) VALUES (?, ?, ?, ?, ?)";

                OleDbCommand cmd = new OleDbCommand(query, conn);

                cmd.Parameters.AddWithValue("?", txtNome.Text);
                cmd.Parameters.AddWithValue("?", Convert.ToDouble(txtPreco.Text));
                cmd.Parameters.AddWithValue("?", Convert.ToInt32(txtQtd.Text));
                cmd.Parameters.AddWithValue("?", txtCodigo.Text);
                cmd.Parameters.AddWithValue("?", true);

                cmd.ExecuteNonQuery();

                conn.Close();

                MessageBox.Show("Produto adicionado!");

                CarregarProdutos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao adicionar produto: " + ex.Message);
                conn.Close();
            }
        }

        // 🔄 RECARREGAR
        private void button2_Click(object sender, EventArgs e)
        {
            CarregarProdutos();
        }

        // ❌ ELIMINAR PRODUTO
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdProduto"].Value);

                string query = "DELETE FROM Produtos WHERE IdProduto = ?";

                OleDbCommand cmd = new OleDbCommand(query, conn);
                cmd.Parameters.AddWithValue("?", id);

                cmd.ExecuteNonQuery();

                conn.Close();

                MessageBox.Show("Produto apagado!");

                CarregarProdutos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao apagar produto: " + ex.Message);
                conn.Close();
            }
        }
    }
}