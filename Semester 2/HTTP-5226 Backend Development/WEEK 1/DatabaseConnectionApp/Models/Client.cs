using Microsoft.EntityFrameworkCore;

namespace DatabaseConnectionApp.Models
{
    public class Client
    {
        public int Id {get;set;}
        public string first_name {get;set;}
        public string last_name {get;set;}
        public string phone_no {get;set;}

        // public Client()
        // {
            
        // }
    }
}