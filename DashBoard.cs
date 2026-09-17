using System;
using System.Drawing;
using System.Windows.Forms;

namespace ZaraArgentina
{
    public class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeDashboard();
        }

        private void InitializeDashboard()
        {
            this.Text = "Zara Argentina - Tablero y Diagrama";
            this.Size = new Size(850, 550);
            this.StartPosition = FormStartPosition.CenterScreen;

            GroupBox grpMetrics = new GroupBox
            {
                Text = "Tablero Principal (KPIs)",
                Left = 20,
                Top = 15,
                Width = 790,
                Height = 90
            };

            Label lblVentas = new Label { Text = "Ventas: $1.520.000,50", Left = 20, Top = 35, AutoSize = true, Font = new Font("Arial", 10, FontStyle.Bold) };
            Label lblStock = new Label { Text = "Stock: 3450 prendas", Left = 300, Top = 35, AutoSize = true, Font = new Font("Arial", 10, FontStyle.Bold) };
            Label lblEmpleados = new Label { Text = "Empleados: 28", Left = 580, Top = 35, AutoSize = true, Font = new Font("Arial", 10, FontStyle.Bold) };

            grpMetrics.Controls.Add(lblVentas);
            grpMetrics.Controls.Add(lblStock);
            grpMetrics.Controls.Add(lblEmpleados);

            Panel pnlDiagrama = new Panel
            {
                Left = 20,
                Top = 120,
                Width = 790,
                Height = 360,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White
            };
            pnlDiagrama.Paint += PnlDiagrama_Paint;

            this.Controls.Add(grpMetrics);
            this.Controls.Add(pnlDiagrama);
        }

        private void PnlDiagrama_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Black, 2);
            Font font = new Font("Arial", 9, FontStyle.Bold);

            Rectangle rect1 = new Rectangle(40, 140, 170, 70);
            Rectangle rect2 = new Rectangle(300, 140, 170, 70);
            Rectangle rect3 = new Rectangle(560, 140, 170, 70);

            g.FillRectangle(Brushes.LightSkyBlue, rect1);
            g.FillRectangle(Brushes.LightGray, rect2);
            g.FillRectangle(Brushes.LightGreen, rect3);

            g.DrawRectangle(pen, rect1);
            g.DrawRectangle(pen, rect2);
            g.DrawRectangle(pen, rect3);

            g.DrawString("1. Login\n(LoginForm)", font, Brushes.Black, 50, 155);
            g.DrawString("2. Validar Datos\n(SQL server / DB)", font, Brushes.Black, 310, 155);
            g.DrawString("3. Tablero\n(DashboardForm)", font, Brushes.Black, 570, 155);

            g.DrawLine(pen, 210, 175, 300, 175);
            g.DrawLine(pen, 470, 175, 560, 175);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // DashboardForm
            // 
            this.ClientSize = new System.Drawing.Size(816, 538);
            this.Name = "DashboardForm";
            this.ResumeLayout(false);

        }
    }
}