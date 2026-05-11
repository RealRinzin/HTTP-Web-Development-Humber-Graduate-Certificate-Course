using Shopping.Models;
class Program
{
    // Items in array
    Item[] items = new Item[3];
    // Cart in List
    List<Item> Cart = new List<Item>();
    static void Main()
    {

        Program program_ = new Program();
        // Variables
        int userChoiceOperation;
        bool status = true; // loop status check
        string message = "Choose the Item you want to buy!!!";
        // Add more items variables
        int addYesNo;

        // Adding dummy records for the items
        program_.items[0] = new Item("iPhone 17 Pro", 499.90f, "Expensive but cool");
        program_.items[1] = new Item("Nothing Phone", 399.90f, "Nothing but expensive");
        program_.items[2] = new Item("Google Pixel", 200.90f, "Good AI feature");
        // Looping through the while condition
        while (status)
        {
            // List of Items
            Console.WriteLine("");
            Console.WriteLine("List of all the items");
            Console.WriteLine("============================================================");
            Console.WriteLine("S.No         Name      Price         Description");
            Console.WriteLine("__________________________________________________");
            // Looping through the items to display for users
            for (var i = 0; i < program_.items.Length; i++)
            {
                Console.WriteLine($"{i + 1}.    {program_.items[i].name}    $ {program_.items[i].price}         {program_.items[i].description}");

            }
            Console.WriteLine(message);
            // User Input Choice
            userChoiceOperation = int.Parse(Console.ReadLine());
            // Check if the user input value is between 1 and 3
            if (userChoiceOperation > 0 && userChoiceOperation <= 3)
            {

                // ADDING items to the list
                // program_.Cart.Add(new Item("iPhone 17", 1200.50f, "Latest model"));
                program_.Cart.Add(program_.items[userChoiceOperation - 1]);
                Console.WriteLine("=====================Your CART=======================================");
                for (var i = 0; i < program_.Cart.Count; i++)
                {
                    Console.WriteLine($" {i + 1}. {program_.Cart[i].name} - ${program_.Cart[i].price}");

                }
                Console.WriteLine("============================================================+=======");
                // message = "Do you want to add more Item";
                status = false;
                Console.WriteLine("Do You want to add more items.");
                Console.WriteLine("1. Yes");
                Console.WriteLine("2. No");
                // YES / NO Options
                addYesNo = int.Parse(Console.ReadLine());
                // addMore = false;
                if (addYesNo == 1)
                {
                    foreach (Item cart in program_.Cart)
                    {
                        program_.items = program_.items.Where(item => item.name != cart.name).ToArray();
                    }

                    status = true;
                }
                else
                {
                    status = false;
                    Console.WriteLine("===============Thank you. See you again!!===================================");
                    Console.WriteLine("=====================Your CART=======================================");
                    for (var i = 0; i < program_.Cart.Count; i++)
                    {
                        Console.WriteLine($" {i + 1}. {program_.Cart[i].name} - ${program_.Cart[i].price}");

                    }
                }
            }
            else
            {
                // status check
                status = true;
                message = "Kindly choose between 1 - " + program_.items.Length;

            }
        }


    }
}