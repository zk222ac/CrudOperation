using CrudOperation.Interfaces;
using CrudOperation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudOperation.Services
{
    public class FakeStudentRepository : IStudentRepository
    {
        public Dictionary<int,Student> Students { get; set; }

        public FakeStudentRepository()
        {
            Students = new Dictionary<int, Student>();
            Students.Add(1, new Student(1, "ajohn", "jh@gmail.com", "john.jpg", Profession.Administration));
            Students.Add(2, new Student(2, "alex", "al@gmail.com", "alex.jpg", Profession.Production));
            Students.Add(3, new Student(3, "malina", "ma@gmail.com", "malina.jpg", Profession.Business));
            Students.Add(4, new Student(4, "nilma", "ni@gmail.com", "nilma.jpg", Profession.Accounting));

        }
        public void AddStudent(Student stu)
        {
            var student = AutoIncrementId(stu);
            Students.Add(student.Id, student);
        }

       

        public Dictionary<int, Student> FilterName(string searchCriteria)
        {
            Dictionary<int, Student> output = new Dictionary<int, Student>();
            foreach (var student in Students.Values)
            {
                if(student.Name.StartsWith(searchCriteria))
                {
                    output.Add(student.Id, student);
                }
            }

            return output;
        }

        public Dictionary<int, Student> GetAllStudents()
        {
            return Students;
        }

        public Student GetStudentById(int id)
        {
            if (Students.ContainsKey(id))
            {
                return Students[id];
            }
            return new Student();
        }

        public void UpdateStudent(Student student)
        {
            if(student != null)
            {
                Students[student.Id].Name = student.Name;
                Students[student.Id].Email = student.Email;
                Students[student.Id].Image = student.Image;
                Students[student.Id].Profession = student.Profession;
            }
        }

        public Student AutoIncrementId(Student student)
        {
            if(Students.Values.Count > 0)
            {
                int maxId = Students.Values.Max(t => t.Id) + 1;
                student.Id = maxId;
            }
            else
            {
                student.Id = 1;
            }           

           return student;
        }   

        public void DeleteStudent(int id)
        {
            if (id != 0)
            {
                Students.Remove(id);
            }
        }
    }
}
