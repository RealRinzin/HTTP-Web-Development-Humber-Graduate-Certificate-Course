using SpaClient.Models;
using SpaService.Models;
using SpaAppointment.Models;
using System.Security.Cryptography.X509Certificates;
class Program
{

    static void Main()
    {
        // Accessing the Appointment Class Object
        AppointmentManager appointmentManager = new AppointmentManager();
        // Accessing the methods

        // UserOptions List
        string[] OptionLists = new string[] { "1. Add Client / Delete Client", "2. Add Service / Delete Service", "3. Add Appointment / Delete Appointment" };
        // Variables
        bool status = true;
        // Display this list of options for the Appointment Manager
        Console.WriteLine("\n");
        Console.WriteLine("Welcome to SPA Booking!!!");
        Console.WriteLine("-------------------------------");
        for (int i = 0; i < OptionLists.Length; i++)
        {
            Console.WriteLine(OptionLists[i]);
        }
        Console.WriteLine("-------------------------------");
        // User choice
        int userChoice = int.Parse(Console.ReadLine());
        // Check if the status is True / False
        // While loop exit for false status 

        while (status)
        {
            Console.WriteLine("\n");
            Console.WriteLine("Its back to main ");
            Console.WriteLine("\n");
            switch (userChoice)
            {

                case 1:
                    // Add Client
                    // Add new client
                    // Receive the name and id of the client
                    // We will be passing 
                    Console.WriteLine("Client Operation");
                    Console.WriteLine("1. Add Client");
                    Console.WriteLine("2. Delete Client");
                    Console.WriteLine("3. Main Menu");
                    int clientOperationChoice = int.Parse(Console.ReadLine());
                    // Check the Case Condition
                    switch (clientOperationChoice)
                    {
                        // Add new client 
                        case 1:
                            appointmentManager.addNewClient();
                            break;
                        case 2:
                            appointmentManager.deleteTheClient();
                            break;
                        case 3:
                            status = false;
                            break;
                        default:
                            break;
                    }
                    break;
                // Service Operation
                case 2:
                    // Add Service
                    Console.WriteLine("Service");
                    // status = false;
                    break;
                case 3:
                    // Update 
                    Console.WriteLine("Appointment");
                    // status = false;
                    break;
                // Display
                default:
                    // status = false;
                    break;

            }
        }

    }
}
