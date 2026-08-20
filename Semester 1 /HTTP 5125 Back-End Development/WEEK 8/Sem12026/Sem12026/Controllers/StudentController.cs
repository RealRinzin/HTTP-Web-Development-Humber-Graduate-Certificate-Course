using Microsoft.AspNetCore.Mvc;
using Sem12026.Models;
using Sem12026.Models.ViewModel;

namespace Sem12026.Controllers
{
    public class StudentController : Controller
    {
        public ListingPageModel listingPageModel;



        public static List<Student> studentListSt;
        public static List<Course> coursesListSt;
        public Student student1;
        public Student student2;


        public Course testCourse;
        public StudentController() {
            if (studentListSt ==null && coursesListSt == null) {
                student1 = new Student("Adam", "smt@gmail.com", "+11434423");
                student2 = new Student("taranpdsadareet", "ssasasadfsfsdfwr@gmail.com", "+5435423");

               studentListSt = new List<Student>();
               coursesListSt = new List<Course>();

                studentListSt.Add(student1);
                studentListSt.Add(student2);
                
            }
            
       
        

            listingPageModel = new ListingPageModel();
            listingPageModel.studentList = new List<Student>();
            listingPageModel.courseList = new List<Course>();
            listingPageModel.course = new Course();


            listingPageModel.studentList = studentListSt;
            listingPageModel.courseList = coursesListSt;
        }

        public IActionResult ListingPage() { 
        
            return View(listingPageModel);
        }

        [HttpPost]
        public IActionResult AddCourse(Course course)
        {
            course.Id++;
            //TODO: add this course to a course list
            listingPageModel.courseList.Add(course);
            return RedirectToAction("ListingPage");
        }



    }
}
