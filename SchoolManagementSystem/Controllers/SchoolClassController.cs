using System.Data;
using Microsoft.AspNetCore.Mvc;
using School.Data.Entities;
using School.Service.ServiceImplementations;
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
        [HttpPost]
        public async Task<IActionResult> AddClass(SchoolClassViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await schoolClassService.AddAsync(viewModel.Class);
                    TempData["Success"] = "Class added successfully.";
                    return RedirectToAction("GetSchoolClass");
                }
            }
            catch (DuplicateNameException ex)
            {
                ModelState.AddModelError("Class.Name", ex.Message);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"An error occurred: {ex.Message}");
                Console.WriteLine(ex);
            }
            viewModel.Classes = await schoolClassService.GetAllAsync();
            viewModel.EditingId = null;
            return View("GetSchoolClass", viewModel);
        }
    }
}
