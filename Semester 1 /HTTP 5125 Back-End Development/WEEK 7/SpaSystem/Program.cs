using SpaBookingAppointmentManager.Models;

class Program
{
    static void Main(string[] args)
    {
        AppointmentManager appointment = new AppointmentManager();

        while (true)
        {
            Console.WriteLine("1. Add Client");
            Console.WriteLine("2. Add Service");
            Console.WriteLine("3. Book Appointment");
            Console.WriteLine("4. View Appointments");
            Console.WriteLine("5. View Services");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");

            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    Console.WriteLine("Adding client...");
                    // Call the method to add a client
                    appointment.AddClient();
                    break;

                case "2":
                    Console.WriteLine("Adding service...");
                    appointment.AddService();
                    break;

                case "3":
                    Console.WriteLine("Booking appointment...");
                    appointment.BookAppointment();
                    break;

                case "4":
                    Console.WriteLine("Viewing appointments...");
                    appointment.ViewAppointments();
                    break;
                case "5":
                    Console.WriteLine("Viewing services...");
                    appointment.ViewServices();
                    break;
 
                case "6":
                    Console.WriteLine("Exiting...");
                    return;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }



}
