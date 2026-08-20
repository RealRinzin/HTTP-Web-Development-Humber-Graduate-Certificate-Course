using System;

namespace MyApplication
{

    // We have created a class called Student 
    // Initialized 3 public variables which can be access outside of the class
    // We have created a constructor which can receive parameter from where ever we created this Student Object

    class Student
    {
        // If we need the private variable to use outside of the class,
        // We can use get, set for that variable like private int fee {get; set;}
        public string name{get; set;}
        public string course{get; set;}
        public string email {get; set;}
        private int fee{get; set;}
        // Function to calculate the interest rate
        // public static string AddNumber(int fee,string name) // When we have many parameter types
        public void AddNumber()
        {
            // return fee * 3;
            Console.WriteLine(fee*fee);
        }
        // COnstructor to initialize the variables
        public Student(string name_, string course_, string email_, int fee_) // We are initialize the parameters received from the user and then assign to the object variables
        {
            name = name_;
            course = course_;
            email = email_;
            fee = fee_;
        }
    }

    // This is the Main program, when we run the program, it will start from this class
    class Program
    {
        static void Main()
        {
            // Here we are creating a new object called std1 for the Student object and passing the required parameters
            Student std1 = new Student("Rinzin", "Web Development", "rinzin@gmail.com", 1000);
            std1.AddNumber();
            // Here we are accessing the field or properties of the std1 objects
            Console.WriteLine(std1.name);
            Console.WriteLine(std1.email);
            Console.WriteLine(std1.course);
        }
    }
}