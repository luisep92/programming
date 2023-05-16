using Microsoft.Data.SqlClient;
using System;
using Tinder;

namespace DBManagement
{
    //Class in charge of connecting and executing commands from the database
    public class DBManager
    {
        #region VARIABLES
        private static readonly string _selectString = "SELECT * FROM APPUSER WHERE name LIKE '%{0}%'";
        public static SqlConnectionStringBuilder ConnectionBuilder;
        #endregion

        #region CONSTRUCTOR
        static DBManager()
        {
            var builder = new SqlConnectionStringBuilder();
            #region ASSIGN DATA
            builder.DataSource = "lep-server.database.windows.net";
            builder.UserID = "deir";
            builder.Password = DataSerializer.DeserializePwd();
            builder.InitialCatalog = "TinDB";
            #endregion
            ConnectionBuilder = builder;
        }
        #endregion

        #region FUNCTIONS
        //Add user to the database
        public static void AddUser(string name, int age, string description, string image, string gender, float valoration)
        {
            try
            {
                using (SqlConnection c = new SqlConnection(ConnectionBuilder.ConnectionString))
                {
                    c.Open();
                    SqlCommand cmd = new SqlCommand("dbo.AddUser", c);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@age", age);
                    cmd.Parameters.AddWithValue("@image", image);
                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@valoration", valoration);
                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                throw new Exception("Error trying to add user");
            }
        }

        //Edit an user from the database
        public static void EditUser(int id, string name, int age, string description, string image, string gender, float valoration)
        {
            try
            {
                using (SqlConnection c = new SqlConnection(ConnectionBuilder.ConnectionString))
                {
                    c.Open();
                    SqlCommand cmd = new SqlCommand("dbo.editUser", c);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@age", age);
                    cmd.Parameters.AddWithValue("@image", image);
                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@valoration", valoration);
                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                throw new Exception("Error trying to add user");
            }
        }

        //Delete an user from database
        public static void DeleteUser(int id)
        {
            try
            {
                using (SqlConnection c = new SqlConnection(ConnectionBuilder.ConnectionString))
                {
                    c.Open();
                    SqlCommand cmd = new SqlCommand("dbo.removeUser", c);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idUser", id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                throw new Exception("Error trying to delete user");
            }
        }
      
        //Update the list of users. Can't return a list because it does not update the itemscontroller, so it directly updates the existing one.
        public static void Filter(string keyword)
        {
            
            var list = AppManager.Instance.UserList;
            try
            {
                using (SqlConnection c = new SqlConnection(ConnectionBuilder.ConnectionString))
                {
                    c.Open();
                    string select = string.Format(_selectString, keyword);
                    SqlCommand cmd = new SqlCommand(select, c);
                    list.Clear();
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            int id = r.GetInt32(0);
                            string name = r.GetString(1);
                            int age = Convert.ToInt32( r.GetByte(2));
                            string image = r.GetString(3);
                            string gender = r.GetString(4);
                            string description = r.GetString(5);
                            float valoration = Convert.ToSingle(r.GetDecimal(6));
                            
                            list.Add(new User(id, name, age, description, image, gender, valoration));
                        }
                    }
                }
            }
            catch
            {
                throw new Exception("Error trying to filter user");
            }
        }
        #endregion
    }
}
