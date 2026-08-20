using Microsoft.EntityFrameworkCore;

namespace DatabaseConnectionApp.Models
{
    public class Client
    {
        public int Id {get;set;}
        public string first_name {get;set;}
        public string last_name {get;set;}
        // public string phone_no {get;set;}

        // public Client(int id, string first_name, string last_name, string phone_no)
        // {    
        //     this.Id = id;
        //     this.first_name = first_name;
        //     this.last_name = last_name;
        //     this.phone_no = phone_no;  
        // }
    }
}