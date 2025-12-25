using System.Data;
using Microsoft.AspNetCore.Mvc;
using School.Data.Entities;
using School.Service.ServiceInterfaces;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Controllers
{
    public class SchoolClassController(ISchoolClassService schoolClassService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetSchoolClass(int? editingId = null)
        {
            var classes = await schoolClassService.GetAllAsync();
            var model = new SchoolClassViewModel()
            {
                Classes = classes,
                EditingId = editingId,
                Class = editingId.HasValue ? await schoolClassService.GetByIdAsync(editingId.Value) : new School_Class() // either empty school class or the one to edit
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
        [HttpPost]
        public async Task<IActionResult> Update(SchoolClassViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await schoolClassService.Update(viewModel.Class);
                    TempData["Success"] = "Class updated successfully.";
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
            viewModel.EditingId = viewModel.Class.Id;
            return View("GetSchoolClass", viewModel);
        }
    }
}
