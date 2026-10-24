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

namespace StockFlow
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void lblUserName_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

                // Esconder a senha
                txtPassword.UseSystemPasswordChar = true;
            }

            private void btnLogin_Click(object sender, EventArgs e)
            {
                string username = txtUsername.Text;
                string password = txtPassword.Text;

                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=DB_StockFlow.accdb";

                try
                {
                    using (OleDbConnection conn = new OleDbConnection(connectionString))
                    {
                        conn.Open();

                        string query = "SELECT COUNT(*) FROM Utilizadores WHERE Username=@user AND Password=@pass";

                        OleDbCommand cmd = new OleDbCommand(query, conn);
                        cmd.Parameters.AddWithValue("@user", username);
                        cmd.Parameters.AddWithValue("@pass", password);

                        int count = (int)cmd.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("Login com sucesso!");

                            Registro menu = new Registro();
                            menu.Show();

                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Usuário ou senha incorretos!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }
            }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Validação básica para não perder tempo com campos vazios
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Preencha o usuário e a senha!");
                return;
            }

            // O caminho correto: Procura o arquivo na pasta onde o .exe está rodando
            string dbPath = System.IO.Path.Combine(Application.StartupPath, "DB_StockFlow.accdb");
            string connectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={dbPath}";

            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();

                    // 1. No Access, 'Password' é palavra reservada, usamos [Password]
                    // 2. OleDb muitas vezes ignora os nomes (@user) e foca na ordem dos '?'
                    string query = "SELECT COUNT(*) FROM INFOLogin WHERE Username = ? AND [Password] = ?";

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        // A ordem aqui deve ser EXATAMENTE a mesma da query
                        cmd.Parameters.AddWithValue("?", username);
                        cmd.Parameters.AddWithValue("?", password);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("Login com sucesso!");

                            // Abre a tela de Adicionar Produto
                            AdicionarProduto telaProduto = new AdicionarProduto();
                            telaProduto.Show();

                            this.Hide(); // Esconde a tela atual
                        }
                        else
                        {
                            MessageBox.Show("Usuário ou senha incorretos!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Se der erro aqui, a MessageBox vai te dizer EXATAMENTE o porquê
                MessageBox.Show("Erro de Conexão: " + ex.Message);
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Registro f4= new Registro();
            f4.Show();
            this.Hide();
        }
    }
    }
