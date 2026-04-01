
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
namespace studentAPP.Controllers;

using studentAPP.Models;
public class StudentController : Controller
{
    private static List<Student> studentRecord = new List<Student>();
    private static int id = 1;
    public IActionResult Index()
    {
        return View(studentRecord);
    }

    [HttpPost]
    public IActionResult registerStudent(Student student)
    {
        student.Id = id++;
        studentRecord.Add(student);
        return RedirectToAction("Index");
    }
}