using System.IO;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Diagnostics;
using Microsoft.Data.SqlClient;

namespace DBManagement
{
    //Used to serialize / deserialize data. This class is internal for obvious reasons.
    internal class DataManager
    {
        #region VARIABLES
        private static string path = "resources/Data";
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        internal static string ConnectionString;
        #endregion


        #region FUNCTIONS
        //Gets the password of the database, that is serialized in JSON, in bytes
        //**Sé que no se le puede ni si quiera llamar encriptado, pero al menos no aparece la contraseña a cañón y a menos que se toque codigo no se puede ver **
        [DebuggerHidden]
        private static string DeserializePwd()
        {
            string ret = "";
            List<string> bytes;
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                bytes = JsonSerializer.Deserialize<List<string>>(fs);
            }

            foreach (string s in bytes)
            {
                ret += (char)byte.Parse(s);
            }

            return ret;
        }

        //Set up the connection string
        [DebuggerHidden]
        internal static void SetBuilder()
        {
            var b = new SqlConnectionStringBuilder();

            b.DataSource = "lep-server.database.windows.net";
            b.UserID = "deir";
            b.Password = DeserializePwd();
            b.InitialCatalog = "TinDB";

            ConnectionString = b.ConnectionString;
        }
        #endregion
    }
}
