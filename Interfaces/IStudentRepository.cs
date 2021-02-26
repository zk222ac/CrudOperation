using CrudOperation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudOperation.Interfaces
{
   public interface IStudentRepository
    {
        public Dictionary<int, Student> GetAllStudents();
        public void AddStudent(Student student);

        public Dictionary<int, Student> FilterName(string searchCriteria);

        public Student GetStudentById(int id);

        public void UpdateStudent(Student student);

        public void DeleteStudent(int student);
    }
}
