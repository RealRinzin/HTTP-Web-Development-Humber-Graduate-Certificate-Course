using Microsoft.AspNetCore.Mvc;
using Sem12026.Models;

namespace Sem12026.Controllers
{
    public class ClientController : Controller
    {
        public static ClientTest client = new ClientTest("TestName");
        public static List<ClientTest> clientList = new List<ClientTest>();

        public ClientController(){
            ClientTest client1 = new ClientTest("Adam");
            ClientTest client2 = new ClientTest("Alia");

            clientList.Add(client1);
            clientList.Add(client2);
        }


        public IActionResult ListCLient()
        {
            return View(clientList);
        }
    }
}
