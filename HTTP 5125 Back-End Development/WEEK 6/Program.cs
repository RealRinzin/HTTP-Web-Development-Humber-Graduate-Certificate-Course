using System.Diagnostics.Contracts;
using System.Net.ServerSentEvents;
using System.Reflection.Metadata;


class Program
{
    //Field (accessible in all non-static methods of Program)
    public float savingsAccount;
    private Client client;

    //private AppointmentMan appMan;
    public Program()
    {
       // Initialize the client in the constructor
        // client = new Client();
        // client.Name = "James";

        //appMan = new AppointmentMan();
    }

    static void Main()
    {
        Program program_ = new Program();
       // program_.PrintClient(program_.client);

        Client user1 = new Client(1,"Josh");
        Client user2 = new Client(2,"Bob");
        Client user3 = new Client(3, "Ana");
    
        Console.WriteLine(user1.Name);
        Console.WriteLine(user2.Name);
        Console.WriteLine(user3.Name);

                //this is accessing a static variable
        Console.WriteLine(Client.UserCount);

        Student Joseph = new Student();
        Joseph.programName = "Web Dev";
        Joseph.name = "Joseph";
        Joseph.ListName();

        Graduate Diana = new Graduate();
        Diana.name = "Diana";
        Diana.isEmployed = true;
        Console.WriteLine($"{Diana.name}: Employment status: {Diana.isEmployed}");

        Human Taranpreet = new Human();
        Taranpreet.name = "Taranpreet ";
        Taranpreet.ListName();
        // //Inheritance example
        // Dog d = new Dog();
        // d.Eat();   // inherited
        // d.MakeASound();  // own method
    }

    
    // void PrintClient(Client client_)
    // {
    //     Console.WriteLine(client_.Name);
    // }






    // static void Main(){
    //     Program program_ = new Program();
        
    //     program_.appMan.CreateNewClient("Adam", 1);
    //     program_.appMan.CreateNewClient("Eva", 2);

    //     foreach(var client in program_.appMan.clientList)
    //     {
    //         Console.WriteLine($"{client.ID}) {client.name} \n");
    //     }

    // }

    





}


