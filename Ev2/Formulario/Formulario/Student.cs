using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formulario
{
    internal class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Description { get; set; }

        public Student(string name, int age, string description)
        {
            Name = name;
            Age = age;
            Description = description;
        }
    }
}
