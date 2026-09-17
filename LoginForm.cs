using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ZaraArgentina
{
    public partial class LoginForm : Form
    {
        private TextBox txtUsuario;
        private TextBox txtPassword;
        private Button btnIngresar;

        // Cadena de conexión a tu SQL Server local
        private string connectionString = @"Server=localhost;Database=ZaraArgentina;Trusted_Connection=True;";

        public LoginForm()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.Text = "Zara Argentina - Login";
            this.Size = new Size(360, 240);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            System.Windows.Forms.Label lblUser = new System.Windows.Forms.Label
            {
                Text = "Usuario:",
                Left = 30,
                Top = 30,
                AutoSize = true
            };

            txtUsuario = new TextBox
            {
                Left = 130,
                Top = 25,
                Width = 170
            };

            System.Windows.Forms.Label lblPass = new System.Windows.Forms.Label
            {
                Text = "Contraseña:",
                Left = 30,
                Top = 75,
                AutoSize = true
            };

            txtPassword = new TextBox
            {
                Left = 130,
                Top = 70,
                Width = 170,
                PasswordChar = '*'
            };

            btnIngresar = new Button
            {
                Text = "Ingresar",
                Left = 130,
                Top = 115,
                Width = 100,
                Height = 30
            };
            btnIngresar.Click += BtnIngresar_Click;

            this.Controls.Add(lblUser);
            this.Controls.Add(txtUsuario);
            this.Controls.Add(lblPass);
            this.Controls.Add(txtPassword);
            this.Controls.Add(btnIngresar);
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            string usuarioIngresado = txtUsuario.Text.Trim();
            string passwordIngresada = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(usuarioIngresado) || string.IsNullOrEmpty(passwordIngresada))
            {
                MessageBox.Show("Por favor, ingrese usuario y contraseña.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Consulta con los nombres exactos de tu tabla: 'usuario' y 'password_hash'
                    string query = "SELECT COUNT(1) FROM Usuarios WHERE usuario = @User AND password_hash = @Pass";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@User", usuarioIngresado);
                        cmd.Parameters.AddWithValue("@Pass", passwordIngresada);

                        int existe = Convert.ToInt32(cmd.ExecuteScalar());

                        if (existe > 0)
                        {
                            MessageBox.Show("¡Bienvenida, Chiara!", "Acceso Concedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            DashboardForm dashboard = new DashboardForm();
                            dashboard.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Usuario o contraseña incorrectos.", "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con SQL Server:\n" + ex.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}