

class Program
{
    static void Main()
    {
        // See https://aka.ms/new-console-template for more information
        Console.WriteLine("Hello, World!");
        // Initialization the variables
        string userName;
        int age;
        float balance = 2.1f;
        // Assign the username values
        userName = "Rinzin";
        // Output Print
        Console.WriteLine("Enter the Age");
        // Input Console
        age = int.Parse(Console.ReadLine());
        // Output the username name
        Console.WriteLine(userName);
        // Output 
        Console.WriteLine("My name is" + userName + " my age is " + age + "and balance is $"+balance);

    }
}