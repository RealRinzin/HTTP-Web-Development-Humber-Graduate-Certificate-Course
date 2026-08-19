namespace SpaAppointment.Models
{
    using SpaClient.Models;
    using SpaService.Models;
    using SpaAppointment.Models;
    class AppointmentManager
    {

        List<Client> Clients = new List<Client>();

        // AddClients
        public void addNewClient()
        {
            Console.WriteLine("Enter the client ID");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the client Name");
            string name = Console.ReadLine();
            Console.WriteLine(name, id);
            // Add the name to the list
            Clients.Add(new Client(id, name, "email", 23132, false));
            Console.WriteLine("\n");
            Console.WriteLine("========Client List==============");
            Console.WriteLine("ID       Name");
            for (int i = 0; i < Clients.Count; i++)
            {
                Console.WriteLine($"{Clients[i].id}         {Clients[i].name}");
            }
            Console.WriteLine("\n");

            Console.WriteLine("Add Successfully");


        }
        // delete Clients
        public void deleteTheClient()
        {
            Console.WriteLine("Enter the client ID");
            int id = int.Parse(Console.ReadLine());

            Clients.RemoveAll((p => p.id == id));
            Console.WriteLine("Delete Client");
            for (int i = 0; i < Clients.Count; i++)
            {
                Console.WriteLine($"{Clients[i].id} {Clients[i].name}");
            }
            // displayTheClients(Clients);
        }
        // Function
        // public void displayTheClients(List)
        // {
        //     Console.WriteLine("hellow");
        // }
    }
}
