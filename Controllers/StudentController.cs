using CrudOperation.Interfaces;
using CrudOperation.Models;
using CrudOperation.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CrudOperation.Controllers
{
    // first step : Create common folder name is Components ( inside the main root folder) 
    // Create a View component Class (studentCount)
    // Create exactly the same folder Components (inside the shared folder) 
    // and then you have a create a folder which is similar the name of Viewcomponent class(StudentCount)
    // Default Page --> provide your business logic ( I show student count)
    //   @await Component.InvokeAsync("StudentCount")
    public class StudentController : Controller
    {
        #region Instant field
        private IStudentRepository _studentRepo;
        #endregion

        #region Property
        public int CountStudents { get; set; }
        #endregion

        #region Constructor
        public StudentController(IStudentRepository studentRepo)
        {
            _studentRepo = studentRepo;
        }

        #endregion

        #region Action Methods
        
        public IActionResult Index(string searchCriteria)
        {

            var dicStudents = _studentRepo.GetAllStudents();
            // if search criteria is not empty then find the filter data
            if(!String.IsNullOrEmpty(searchCriteria))
            {
                dicStudents = _studentRepo.FilterName(searchCriteria);
            }

            int CountStudents = dicStudents.Count;

            // Before pass data into View , we VM (because contains complex data in it)
            StudentVm vm = new StudentVm()
            {
                Students = dicStudents,
                TotalCount = CountStudents,
               
            };
            // here we pass Student View Model
            return View(vm);
        }

        // when we click button on "Create Student" ,
        // we call this method for display bydefault page CreateStudent  
        public IActionResult IndexCreate()
        {
            return View(nameof(CreateStudent));
        }

        // This method is called when we send Post request with some infomration
        public IActionResult CreateStudent(Student student)
        {
            try
            {    // if model state property is valid then we create new student succesfully           
                if (ModelState.IsValid)
                {
                    _studentRepo.AddStudent(student);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Create", "Unable to Create new Student: " + ex);
            }

            return View(student);
        }   

        // This method also send Post request for editing information
        public IActionResult EditStudent(Student student)
        {
            try
            {    // if model state property is valid then we create new student succesfully           
                if (ModelState.IsValid)
                {
                    _studentRepo.UpdateStudent(student);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Create", "Unable to Create new Student: " + ex);
            }

            return View(student);
        }
        // when we click button edit , first time the page appears is EditStudent
        public IActionResult IndexEdit(int Id)
        {
            Student student = null;
            if(Id != 0)
            {
                student = _studentRepo.GetStudentById(Id);
            }
            else
            {
                return NotFound();
            }
           
            return View(nameof(EditStudent),student);
        }

        // Delete Method 

        public IActionResult DeleteStudent(int Id)
        {
            if(Id != 0)
            {
                 _studentRepo.DeleteStudent(Id);
            }
            else
            {
                return NotFound();
            }
            return View();
        }

        #endregion

    }
}
