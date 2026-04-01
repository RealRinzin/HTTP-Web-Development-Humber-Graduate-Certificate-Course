
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
namespace studentAPP.Controllers;

using studentAPP.Models;
public class CourseController : Controller
{
    private static List<Course> courseRecord = new List<Course>();
    private static int id = 1;
    public IActionResult Index()
    {
        return View(courseRecord);
    }

    [HttpPost]
    public IActionResult registerCourse(Course course)
    {
        course.Id = id++;
        courseRecord.Add(course);
        return RedirectToAction("Index");
    }
}