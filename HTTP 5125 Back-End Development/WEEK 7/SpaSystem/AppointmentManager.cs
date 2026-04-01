using SpaBookingSystem.Models;
namespace SpaBookingAppointmentManager.Models
//why above namespace line? explain it.
// The namespace declaration at the top of the file is used to organize code and prevent naming conflicts. In this case, the AppointmentManager class is part of the SpaBookingAppointmentManager.Models namespace, which helps to group related classes together. This way, if there are other classes with the same name in different namespaces, they won't conflict with each other. It also makes it easier to understand the structure of the code and where to find specific classes.
//
{

    public class AppointmentManager
    {
        List<Service> serviceList = new List<Service>();
        List<Client> clientList = new List<Client>();
        List<Appointment> appointmentList = new List<Appointment>();

        //constructor to initialize the service list with some default services
        public AppointmentManager()
        {
            serviceList.Add(new Service("Massage", 60));
            serviceList.Add(new Service("Facial", 45));
            serviceList.Add(new Service("Manicure", 30));
        }

        public void AddClient()
        {
            Console.Write("Enter client name: ");
            string name = Console.ReadLine() ?? "";
            // ?? "" because if the user inputs nothing, it will assign an empty string to name instead of null

            Console.Write("Enter client ID: ");
            int id = int.Parse(Console.ReadLine() ?? "0");
            foreach (Client client in clientList)
            {
                if (client.Id == id)
                {
                    Console.WriteLine("Client ID already exists. Please enter a unique ID.");
                    return;
                }
            }

            clientList.Add(new Client(name, id));
            foreach (Client client in clientList)
            {
                Console.WriteLine($"Client Name: {client.Name}, Client ID: {client.Id}");
            }

        }

        //add service to the service list
        public void AddService()
        {
            Console.Write("Enter service name: ");
            string serviceName = Console.ReadLine();
            Console.Write("Enter service price: ");
            double price = double.Parse(Console.ReadLine());

            serviceList.Add(new Service(serviceName, price));
            Console.WriteLine("Service added successfully!");
        }

        //view all services in the service list
        public void ViewServices()
        {
            Console.WriteLine("Available Services:");
            foreach (Service service in serviceList)
            {
                Console.WriteLine($"{service.ServiceName} - ${service.Price}");
            }
        }

        //booking an appointment
        public void BookAppointment()
        {
            // show all clients in the client list if there are any clients, otherwise prompt to add a client first
            if (clientList.Count > 0)
            {
                Console.WriteLine("Clients:");
                foreach (Client cl in clientList)
                {
                    Console.WriteLine($"Client ID: {cl.Id}, Name: {cl.Name}");
                }
            }
            else
            {
                Console.WriteLine("No clients found. Please add a client first.");
                return;
            }
            Console.Write("Enter client ID: ");
            int clientId = int.Parse(Console.ReadLine());
            var client = clientList.Find(c => c.Id == clientId);
            if (client == null)
            {
                Console.WriteLine("Client not found. Please add the client first.");
                return;
            }
            Console.WriteLine($"Client found: {client.Name}");
            Console.WriteLine("Available Services:");
            for (int i = 0; i < serviceList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {serviceList[i].ServiceName} - ${serviceList[i].Price}");
            }
            Console.Write("Select a service by number: ");
            int serviceIndex = int.Parse(Console.ReadLine()) - 1;
            if (serviceIndex < 0 || serviceIndex >= serviceList.Count)
            {
                Console.WriteLine("Invalid service selection.");
                return;
            }
            var service = serviceList[serviceIndex];
            Console.Write("Enter appointment date and time (yyyy-MM-dd HH:mm): ");
            DateTime appointmentDate = DateTime.Parse(Console.ReadLine());
            // Check for overlapping appointments
            foreach (var appointment in appointmentList)
            {
                if (appointment.AppointmentDate == appointmentDate)
                {
                    Console.WriteLine("This time slot is already booked. Please choose a different time.");
                    return;
                }
            }
            appointmentList.Add(new Appointment(client, service, appointmentDate));
            Console.WriteLine("Appointment booked successfully!");
        }

        //view all appointments
        public void ViewAppointments()
        {
            if (appointmentList.Count == 0)
            {
                Console.WriteLine("No appointments booked yet.");
                return;
            }
            foreach (Appointment appointment in appointmentList)
            {
                Console.WriteLine($"Appointment: {appointment.Client.Name} - {appointment.Service.ServiceName} - {appointment.AppointmentDate}");
            }
        }
    }
}