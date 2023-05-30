using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AutoMapper;
using Microsoft.Extensions.Localization;
using Kolokwium.ViewModel.VM;

namespace Kolokwium.Web.Controllers
{
    public class HomeController : BaseController
    {

        public HomeController(ILogger logger, IMapper mapper, IStringLocalizer localizer) 
            : base(logger, mapper, localizer)
        {
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}

















/*
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using SchoolRegister.Model.DataModels;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.VM;
namespace SchoolRegister.Web.Controllers;

[Authorize(Roles = "Teacher, Admin, Student")]
public class SubjectController : BaseController
{
    private readonly ISubjectService _subjectService;
    private readonly ITeacherService _teacherService;
    private readonly IGroupService _groupService;
    private readonly UserManager<User> _userManager;

    public SubjectController(ISubjectService subjectService, ITeacherService teacherService, IGroupService groupService, UserManager<User> userManager, IStringLocalizer localizer, ILogger logger, IMapper mapper) : base(logger, mapper, localizer) {
        _subjectService = subjectService;
        _teacherService = teacherService;
        _groupService = groupService;
        _userManager = userManager;
    }

    public IActionResult Index() {
        var user = _userManager.GetUserAsync(User).Result;
        if (_userManager.IsInRoleAsync(user, "Admin").Result) {
            return View(_subjectService.GetSubjects());
        }
        else if (_userManager.IsInRoleAsync(user, "Teacher").Result && user is Teacher teacher) {
            return View(_subjectService.GetSubjects(x => x.TeacherId == teacher.Id));
        }
        else if (_userManager.IsInRoleAsync(user, "Student").Result) {
            return RedirectToAction("Details", "Student", new { id = user.Id });
        }
        else {
            return View("Error");
        }
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public IActionResult AddOrEditSubject(int? id = null) {
        var teachersVm = _teacherService.GetTeachers();
        ViewBag.TeachersSelectList = new SelectList(teachersVm.Select(t => new {
            Text = $"{t.FirstName} {t.LastName}",
            Value = t.Id
        }), "Value", "Text");

        if (id.HasValue) {
            var subjectVm = _subjectService.GetSubject(x => x.Id == id);
            ViewBag.ActionType = "Edit";
            return View(Mapper.Map<AddOrUpdateSubjectVm>(subjectVm));
        }
        
        ViewBag.ActionType = "Add";
        return View();
    }

    public IActionResult Details(int id) {
        var subjectVm = _subjectService.GetSubject(x => x.Id == id);
        return View(subjectVm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Admin")]
    public IActionResult AddOrEditSubject(AddOrUpdateSubjectVm addOrUpdateSubjectVm)
    {
        if (ModelState.IsValid)
        {
            _subjectService.AddOrUpdateSubject(addOrUpdateSubjectVm);
            return RedirectToAction("Index");
        }
        return View();
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public IActionResult AttachTeacherToSubject() {
        var teacherId = int.Parse(HttpContext.Request.Query["teacherId"]);
        ViewBag.teacherId = teacherId;

        var subjectsVm = _subjectService.GetSubjects().Where(x => x.TeacherId != teacherId);
        ViewBag.SubjectsSelectList = new SelectList(subjectsVm, "Id", "Name");

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Admin")]
    public IActionResult AttachTeacherToSubject(AttachDetachSubjectToTeacherVm attachDetachSubjectToTeacherVm) {
        if (ModelState.IsValid) {
            _groupService.AttachTeacherToSubject(attachDetachSubjectToTeacherVm);
            return RedirectToAction("Index", "Teacher");
        }
        return View();
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public IActionResult DetachTeacherFromSubject() {
        int teacherId = int.Parse(HttpContext.Request.Query["teacherId"]);
        ViewBag.teacherId = teacherId;

        var subjectsVm = _subjectService.GetSubjects().Where(x => x.TeacherId == teacherId);
        ViewBag.SubjectsSelectList = new SelectList(subjectsVm, "Id", "Name");

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Admin")]
    public IActionResult DetachTeacherFromSubject(AttachDetachSubjectToTeacherVm attachDetachSubjectToTeacherVm) {
        if (ModelState.IsValid) {
            _groupService.DetachTeacherFromSubject(attachDetachSubjectToTeacherVm);
            return RedirectToAction("Index", "Teacher");
        }
        return View();
    }
}

*/
