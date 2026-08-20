namespace SpaBookingSystem.Models
{
    public class Service
    {
        public string ServiceName { get; set; }
        public double Price { get; set; }

        public Service(string serviceName, double price)
        {
            ServiceName = serviceName;
            Price = price;
        }
        // Method to display service information
        public void DisplayServiceInfo()
        {
            Console.WriteLine($"{ServiceName} - ${Price}");
        }
    }
}
