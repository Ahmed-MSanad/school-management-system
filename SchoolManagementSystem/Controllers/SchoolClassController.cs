using Microsoft.AspNetCore.Mvc;
using School.Data.Entities;
using School.Service.ServiceInterfaces;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Controllers
{
    public class SchoolClassController(ISchoolClassService schoolClassService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetSchoolClass()
        {
            var classes = await schoolClassService.GetAllAsync();
            var model = new SchoolClassViewModel()
            {
                Classes = classes,
                Class = new School_Class()
            };
            return View(model);
        }
    }
}
