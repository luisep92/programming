using Microsoft.Data.SqlClient; 

namespace ConsultasBD
{
    internal class Program
    {

        static void Main(string[] args)
        {
            try
            {
                //anterior: "server = DESKTOP-9F8GPDG\\SQLEXPRESS; database = JARDINERIA; integrated security = true"
                var builder = new SqlConnectionStringBuilder();
                #region ASSIGN DATA
                builder.DataSource = "lep-server.database.windows.net";
                builder.UserID = "deir";
                #region PASSWORD
                #region QUE NO MIRES COÑO
                #region COJONES
                #region Y SERA VERDAD
                #region QUE NO
                builder.Password = "G0rr@Monster712";
                #endregion
                #endregion
                #endregion
                #endregion
                #endregion
                builder.InitialCatalog = "TinDB";
                #endregion

                using (SqlConnection c = new SqlConnection(builder.ConnectionString))
                {
                    c.Open();
                    /*SqlCommand cmd = new SqlCommand("SELECT dbo.getUserName(1)", c);*/
                     //SqlCommand cmd = new SqlCommand("dbo.removeUser", c);
                     //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                     //cmd.Parameters.AddWithValue("@idUser", 3);

                     //SqlCommand cmd = new SqlCommand("dbo.addUser", c);
                     //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                     //cmd.Parameters.AddWithValue("@name", "Alba");
                     //cmd.Parameters.AddWithValue("@age", "27");
                     //cmd.Parameters.AddWithValue("@image", "");
                     //cmd.Parameters.AddWithValue("@gender", "Mujer");
                     //cmd.Parameters.AddWithValue("@description", "La alba");

                    //cmd.ExecuteNonQuery();

                    var cmd = new SqlCommand("SELECT * FROM APPUSER", c);

                    
                    //cmd.ExecuteNonQuery();

                    //cmd = new SqlCommand("SELECT dbo.getUserName(2)", c);
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            for (int i = 0; i < r.FieldCount; i++)
                            {
                                Console.Write(r[i] + "    ");
                            }
                            Console.WriteLine();
                        }
                    }


                    /*      PROCEDURE
                    SqlCommand cmd = new SqlCommand("insertCliente", c);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@codCliente", 503);
                    cmd.Parameters.AddWithValue("@nombre", "Prueba");
                    cmd.Parameters.AddWithValue("@contacto", "Prueba");
                    cmd.Parameters.AddWithValue("@apellido", "Prueba");
                    cmd.Parameters.AddWithValue("@tlf", 56513203);
                    cmd.Parameters.AddWithValue("@fax", 456697123);
                    cmd.Parameters.AddWithValue("@dir", "Prueba");
                    cmd.Parameters.AddWithValue("@dir2", "Prueba");
                    cmd.Parameters.AddWithValue("@ciudad", "Alicante");
                    cmd.Parameters.AddWithValue("@cod_rep_ventas", 19);
                    executenonquery
                    */
                    /*
                    //Insert(c, "CLIENTES", "501, 'Prueba1', 'Prueba2', 'Prueba3', '654654654', '654654654', 'Prueba4', NULL, 'Alicante', NULL, NULL, NULL, 19, 3000");
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        cmd.ExecuteNonQuery();
                    }
                    /*
                    SqlCommand cmd = Select(c, "*", "CLIENTES", "codCliente = 1");
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
                    */
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        //esto hay que cambiarlo por placeholders
        private static SqlCommand Select(SqlConnection connection, string columns, string table, string condition = "")
        {
            if (condition != "")
                condition = " WHERE " + condition;
            return new SqlCommand("SELECT " + columns + " FROM " + table + condition, connection);
        }
        private static SqlCommand Insert(SqlConnection connection, string table, string values)
        {
            try
            {
                return new SqlCommand("INSERT INTO " + table + " VALUES (" + values + ")", connection);
            }
            catch
            {
                throw new Exception("Datos invalidos al insertar en la tabla " + table);
            }
        }
    }
}