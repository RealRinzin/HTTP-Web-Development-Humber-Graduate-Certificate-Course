using System.ComponentModel.DataAnnotations;

namespace Sem12026.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public Student(string name_, string email, string phone) {
            Id++;
            Name = name_;
            Email = email;
            Phone = phone;
        }

    }
}
