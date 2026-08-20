// See https://aka.ms/new-console-template for more information
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;

class App
{
    // Amount variable for the account balance
    public float accountBalance;
    // Amount variable for the user
    public float amount;
    // status check of the input for while loop
    // fallback
    public bool status;
    // Constructor App
    public App()
    {
        // Assigning values for balance
        accountBalance = 0.0f;
        amount = 0.0f;
        status = true;
    }
    // MAIN PROGRAM
    static void Main()
    {
        // Creating a new Object reference for the App
        App accountOperation = new App();
        // set the value for the account balance 
        accountOperation.accountBalance = 100.45f; // balance
        // User Input Amounts
        int userChoiceOperation;
        float userInputAmount;

        // Loop Fallback if user input wrong option
        while (accountOperation.status)
        {
            // Operation 
            Console.WriteLine("===========================================");
            Console.WriteLine("Choose the Operation");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdrawal");
            Console.WriteLine("3. Send to Someone");
            Console.WriteLine("===========================================");
            // user Input
            userChoiceOperation = int.Parse(Console.ReadLine());
            // Check Condition if the user 
            // Input value is between 3 and 1
            if (userChoiceOperation <= 3 && userChoiceOperation >= 1)
            {
                accountOperation.status = false;
                Console.WriteLine("Please enter the total Amount!");
                // User input the Operations
                //Enter the Amount
                userInputAmount = float.Parse(Console.ReadLine());
                // Switch Operations
                switch (userChoiceOperation)
                {
                    case 1:
                        accountOperation.depositToAccount(userInputAmount);
                        break;

                    case 2:
                        accountOperation.withdrawFromAccount(userInputAmount);
                        break;

                    case 3:
                        accountOperation.transferFromAccount(userInputAmount);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine("Please Enter between 1-3!!!");
                // Set it to true to fallback to the loop
                accountOperation.status = true;
            }

        }
    }

    // Operation to the Bank
    // 1. Deposit
    // 2. Withdraw
    // 3. Transfer
    // Deposit Operation
    public void depositToAccount(float userInputAmount)
    {
        accountBalance += userInputAmount;

        Console.WriteLine("You have deposited $" + userInputAmount + " and your balance is $" + accountBalance);
    }
    // Withdraw Operation
    public void withdrawFromAccount(float userInputAmount)
    {
        // Check if the user withdraw is more than
        // available balance in the account
        if (accountBalance > userInputAmount)
        {
            accountBalance -= userInputAmount;
            Console.WriteLine("You have withdrawn $" + userInputAmount + " and your balance is $" + accountBalance);
        }
        else
        {
            Console.WriteLine("Sorry!!!,You account is low");
        }

    }
    // Transfer to other account
    public void transferFromAccount(float userInputAmount)
    {
        // Check if the user withdraw is more than
        // available balance in the account
        if (accountBalance > userInputAmount)
        {
            accountBalance -= userInputAmount;
            Console.WriteLine("You have transferred $" + userInputAmount + " and your balance is $" + accountBalance);
        }
        else
        {
            Console.WriteLine("Sorry!!!,You can't transfer since you account balance is lower than requested amount");

        }
    }

}