using System.Data.SqlClient;

namespace ConsultasBD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (SqlConnection c = new SqlConnection("server = DESKTOP-9F8GPDG\\SQLEXPRESS; database = JARDINERIA; integrated security = true"))
                {
                    c.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM CLIENTES", c);
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            for(int i = 0; i < r.FieldCount; i++)
                            {
                                Console.Write(r[i] + "    ");
                            }
                            Console.WriteLine();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
    }
}