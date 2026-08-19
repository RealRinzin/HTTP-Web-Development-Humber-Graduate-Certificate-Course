namespace Sem12026.Models
{
    public class ClientTest
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ClientTest(string name) { 
            Name= name;
            Id++;
        }
    }
}
