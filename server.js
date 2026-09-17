using System;
using System.Data.SqlClient;

namespace ZaraArgentina.Backend
{
    public class Server
    {
        private static string connectionString = "Server=localhost;Database=ZaraArgentina;Trusted_Connection=True;";

        public static bool AutenticarUsuario(string username, string password)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(1) FROM Usuarios WHERE Username = @User AND Password = @Pass";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@User", username);
                    cmd.Parameters.AddWithValue("@Pass", password);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        public static (decimal Ventas, int Stock, int Empleados) ObtenerMetricas()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT TOP 1 VentasMes, PrendasStock, EmpleadosActivos FROM MetricasDashboard ORDER BY Id DESC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return (
                                reader.GetDecimal(0),
                                reader.GetInt32(1),
                                reader.GetInt32(2)
                            );
                        }
                    }
                }
            }
            return (0, 0, 0);
        }
    }
}