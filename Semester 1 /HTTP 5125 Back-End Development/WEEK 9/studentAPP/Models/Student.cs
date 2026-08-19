namespace studentAPP.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        // public Student(string name_,string email_,string phone_)
        // {
        //     Id++;
        //     Name = name_;
        //     Email = email_;
        //     Phone = phone_;
        // }
    }
}