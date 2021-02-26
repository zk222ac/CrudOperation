using CrudOperation.Interfaces;
using CrudOperation.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CrudOperationASP.NETMVCCore5.Components
{
    // step no 1 : Create a new class whcich is match to your business logic
    // step no 2: inherit base class ViewComponent
    // StudentCount is the name of the View Component
    public class StudentCount : ViewComponent
    {
        private IStudentRepository _studentRepo;
        public StudentCount(IStudentRepository studentRepo)
        {
            _studentRepo = studentRepo;
        }

        // View component logic
        public IViewComponentResult Invoke()
        {
            var sCount = _studentRepo.GetAllStudents().Count;
            
            var vm = new StudentVm
            {
                TotalCount = sCount
            };
            // Step no 3: Create View Component Razor Page 
            // Step no 4 : Pass data into View Component
            return View(vm);
        }
    }
}
