using Formulario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formulario
{
    internal class AppManager
    {
        private static AppManager _instance = new AppManager();
        public List<Student> _students = new List<Student>();

        public static AppManager Instance => _instance;
        public List<Student> Students
        {
            get => _students;
            set
            {
                if(value != null)
                     _students = value;
            }
        }
    }
}
