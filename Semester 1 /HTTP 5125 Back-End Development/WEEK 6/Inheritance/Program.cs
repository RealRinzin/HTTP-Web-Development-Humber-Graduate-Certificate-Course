using System;
using System.Collections.Generic;

namespace Program
{
    // Base class
    class UserRole
    {
        public int Id { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }

        public UserRole(int id)
        {
            Id = id;
            CreateTime = DateTime.Now;
            UpdateTime = DateTime.Now;
        }

        public virtual string DescribeRole()
        {
            return "I am a User Role";
        }
    }

    // User class
    class User : UserRole
    {
        public string Name { get; set; }
        private static int Counter = 0;

        public User(string name, string email)
            : base(++Counter)
        {
            Name = name;
        }

        public override string DescribeRole()
        {
            return "I am a user";
        }
    }

    // AdminUser class
    class AdminUser : User
    {
        public AdminUser(string name, string email)
            : base(name, email)
        {
        }

        public override string DescribeRole()
        {
            return "I am an admin user";
        }
    }

    // GuestUser class
    class GuestUser : User
    {
        public GuestUser(string name, string email)
            : base(name, email)
        {
        }

        public override string DescribeRole()
        {
            return "I am a guest user";
        }
    }

    class Program
    {
        static void Main()
        {
            // Create one instance of each
            var user = new User("John", "john@mail.com");
            var admin = new AdminUser("Alice", "alice@mail.com");
            var guest = new GuestUser("Bob", "bob@mail.com");

            // Add all to one list
            List<UserRole> list = new List<UserRole>
            {user,admin,guest};

            // ONE loop only
            foreach (var item in list)
            {
                Console.WriteLine(item.DescribeRole());
            }
        }
    }
}
