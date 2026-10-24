using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockFlow
{
    public partial class Registro
        : Form
    {
        string connectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={Path.Combine(Application.StartupPath, "DB_StockFlow.accdb")}";
        public Registro()
        {
            InitializeComponent();

            // Configura os campos de senha para mostrar asteriscos (*)
            txtPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.UseSystemPasswordChar = true;
        }


        private void LoginCompleto_Load(object sender, EventArgs e)
        {

        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text.Trim();
            string pass = txtPassword.Text.Trim();
            string confirm = txtConfirmPassword.Text.Trim();

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass) || string.IsNullOrEmpty(confirm))
            {
                MessageBox.Show("Preencha todos os campos!");
                return;
            }

            if (pass != confirm)
            {
                MessageBox.Show("As senhas não coincidem!");
                return;
            }

            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    using (OleDbTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            // 1. Verificar se já existe
                            string sqlCheck = "SELECT COUNT(*) FROM INFORegistro WHERE Username = ?";
                            using (OleDbCommand cmdCheck = new OleDbCommand(sqlCheck, conn, trans))
                            {
                                cmdCheck.Parameters.AddWithValue("?", user);
                                int existente = (int)cmdCheck.ExecuteScalar();
                                if (existente > 0)
                                {
                                    MessageBox.Show("Usuário já existe!");
                                    return;
                                }
                            }

                            // 2. Inserir na INFORegistro
                            string sqlInsert = "INSERT INTO INFORegistro (Username, [Password]) VALUES (?, ?)";
                            using (OleDbCommand cmdInsert = new OleDbCommand(sqlInsert, conn, trans))
                            {
                                cmdInsert.Parameters.AddWithValue("?", user);
                                cmdInsert.Parameters.AddWithValue("?", pass);
                                cmdInsert.ExecuteNonQuery();
                            }

                            // 3. Inserir na INFOLogin
                            string sqlLog = "INSERT INTO INFOLogin (Username, [Password], Ativo) VALUES (?, ?, ?)";
                            using (OleDbCommand cmdLog = new OleDbCommand(sqlLog, conn, trans))
                            {
                                cmdLog.Parameters.AddWithValue("?", user);
                                cmdLog.Parameters.AddWithValue("?", pass);
                                cmdLog.Parameters.AddWithValue("?", true);
                                cmdLog.ExecuteNonQuery();
                            }

                            // FINALIZA A TRANSAÇÃO (APENAS UMA VEZ)
                            trans.Commit();

                            MessageBox.Show("Usuário criado! Agora, complete o seu perfil.", "Sucesso");

                            // ABRE A PRÓXIMA TELA (FORA DOS BLOCOS DE COMANDO)
                            DadosPessoais telaDados = new DadosPessoais(user);
                            telaDados.Show();
                            this.Hide();
                        }
                        catch (Exception ex)
                        {
                            // Se der erro, tenta fazer o Rollback
                            try { trans.Rollback(); } catch { }
                            MessageBox.Show("Erro ao gravar: " + ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro de conexão: " + ex.Message);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // 1. Cria uma instância do formulário de Login
            // Certifique-se de que o nome da classe do seu form de login é 'Login'
            Login telaLogin = new Login();

            // 2. Mostra a tela de Login
            telaLogin.Show();

            // 3. Fecha ou Esconde a tela de registro
            // Usar Hide() é melhor se você quiser manter os dados do registro na memória, 
            // mas Close() economiza recursos se você não for voltar para cá agora.
            this.Hide();
        }
    }
    
}
