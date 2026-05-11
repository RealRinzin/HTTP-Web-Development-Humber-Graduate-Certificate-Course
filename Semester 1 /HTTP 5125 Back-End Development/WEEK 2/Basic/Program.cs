using System.Diagnostics;

class Program
{
    static void Main()
    {

        float money;
        int option;
        float balance = 100.1f;
        Console.WriteLine("Choose the Operation");
        Console.WriteLine("1. Deposit");
        Console.WriteLine("2. Withdrawal");
        Console.WriteLine("3. Send to Someone");
        option = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the Amount");
        money = int.Parse(Console.ReadLine());
        switch (option)
        {
            case 1:
                Console.WriteLine("You have deposited $" + money);
                Console.WriteLine("Your Total balance $" + (balance + money));
                break;
            case 2:
                if (money > balance)
                {
                    Console.WriteLine("You don't have sufficient Amount");
                }
                else
                {
                    Console.WriteLine("You have withdraw $" + money);
                    Console.WriteLine("Your Total balance $" + (balance - money));
                }
                break;
            case 3:
                Console.WriteLine("You are sending this $" + money + " amount to friend");
                Console.WriteLine("Choose the Option");
                Console.WriteLine("1. James");
                Console.WriteLine("2. Preet");
                Console.WriteLine("3. John");
                int choice = int.Parse(Console.ReadLine());
                if (money > balance)
                {
                    Console.WriteLine("You don't have enough balance");
                }
                else
                {
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Sent to $" + money + " to James's Account");
                            break;
                        case 2:
                            Console.WriteLine("Sent to $" + money + " to Preet's Account");
                            break;
                        case 3:
                            Console.WriteLine("Sent to $" + money + "to John's Account");
                            break;
                        default:
                            Console.WriteLine("Your Total balance $" + (balance - money));
                            break;
                    }

                }
                Console.WriteLine("Your Total balance $" + (balance - money));
                break;
            default:
                Console.WriteLine("Your Total balance " + balance);
                break;
        }

    }
}