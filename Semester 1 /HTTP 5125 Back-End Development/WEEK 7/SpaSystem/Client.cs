namespace SpaBookingSystem.Models
{
    public class Client
    {
        public string Name { get; set; }
        public int Id { get; set; }

        
        public Client(string name, int id)
        {
            Name = name;
            Id = id;
        }

    }
}
