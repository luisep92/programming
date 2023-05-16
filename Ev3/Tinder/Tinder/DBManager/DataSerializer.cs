using System.IO;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace DBManagement
{
    //Used to serialize / deserialize data. This class is internal for obvious reasons.
    internal class DataSerializer
    {
        #region VARIABLES
        private static string path = "resources/Data";
        #endregion

        #region FUNCTIONS
        //Gets the password of the database, that is serialized in JSON, in bytes
        //Sé que no se le puede ni si quiera llamar encriptado, pero al menos no aparece la contraseña a cañón y no me quería comer mucho la cabeza
        internal static string DeserializePwd()
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
        #endregion
    }
}
