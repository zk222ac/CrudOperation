using CrudOperation.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudOperation.ViewModel
{
    public class StudentVm
    {
        public Dictionary<int, Student> Students { get; set; }
        
        public int TotalCount { get; set; }



    }
}
