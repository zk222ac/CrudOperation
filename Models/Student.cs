using System;
using System.ComponentModel.DataAnnotations;

namespace CrudOperation.Models
{
    public class Student
    {
        public Student(int id, string name, string email, string image, Profession profession)
        {
            Id = id;
            Name = name;
            Email = email;
            Image = image;
            Profession = profession;
        }
        public Student()
        {

        }
        [Range(0, 1000)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required"), MaxLength(30)]
        public string Name { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]

        public string Email { get; set; }

        [Required(ErrorMessage = "Image is required")]

        public string Image { get; set; }

        [Required(ErrorMessage = "Profession is required")]

        public Profession Profession { get; set; }

       

    }
}
