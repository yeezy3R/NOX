using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace StockFlow
{
    public partial class DadosPessoais : Form
    {
        private string usuarioLogado;
        string connectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={Path.Combine(Application.StartupPath, "DB_StockFlow.accdb")}";

        public DadosPessoais(string user)
        {
            InitializeComponent();
            usuarioLogado = user;
        }

        private void btnContinuar_Click_1(object sender, EventArgs e)
        {
            string nome = txtNome.Text.Trim();
            string telefone = txtTelefone.Text.Trim();
            string mail = txtEmail.Text.Trim();

            // --- VALIDAÇÃO INTELIGENTE ---
            // Verifica campo por campo para dar a mensagem exata
            if (string.IsNullOrEmpty(nome))
            {
                MessageBox.Show("O campo NOME é obrigatório!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Focus();
                return;
            }

            if (string.IsNullOrEmpty(mail))
            {
                MessageBox.Show("O campo EMAIL é obrigatório!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();

                    // email em minúsculo conforme sua tabela no Access
                    string query = "UPDATE INFORegistro SET Nome = ?, Telefone = ?, email = ? WHERE Username = ?";

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", nome);
                        cmd.Parameters.AddWithValue("?", telefone);
                        cmd.Parameters.AddWithValue("?", mail);
                        cmd.Parameters.AddWithValue("?", usuarioLogado);

                        int resultado = cmd.ExecuteNonQuery();

                        if (resultado > 0)
                        {
                            MessageBox.Show("Perfil atualizado com sucesso!");
                            AdicionarProduto telaProduto = new AdicionarProduto();
                            telaProduto.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Erro: Usuário não localizado para atualização.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro técnico: " + ex.Message);
            }
        }

        // --- BOTÃO VOLTAR ---
        // Adicione este método ao seu botão de voltar no Designer
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            // Se o usuário clicar em voltar, voltamos para o Login (ou Registro)
            Login telaLogin = new Login();
            telaLogin.Show();
            this.Close();
        }

        private void DadosPessoais_Load(object sender, EventArgs e)
        {
        }
    }
}