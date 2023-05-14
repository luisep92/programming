using System.Windows;

namespace Tinder
{
    //POJO class that stores the information of an user
    public class User
    {
        #region VARIABLES
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Gender { get; set; }
        public float Valoration { get; set; }
        public Point ValorationEndPoint => new Point(Valoration/5f, 0); //Had to do this in order to fill the stars of valoration
        #endregion

        #region CONSTRUCTOR
        public User(int id, string name, int age, string description, string image, string gender, float valoration)
        {
            Id = id;
            Name = name;
            Age = age;
            Description = description;
            Image = image;
            Gender = gender;
            Valoration = valoration;
        }
        #endregion
    }
}
