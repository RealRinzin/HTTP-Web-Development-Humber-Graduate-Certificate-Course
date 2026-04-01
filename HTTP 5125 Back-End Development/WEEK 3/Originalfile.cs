// See https://aka.ms/new-console-template for more information

using System.Diagnostics.Contracts;

class Student
{

    public float averGrade;

    public void SubmitHomework()
    {
        Console.WriteLine("submitted homework");
    }
}

class Program
{
    public float savingsAccount;
    public Program()
    {
        savingsAccount = 0.0f;
    }
    static void Main()
    {
        Program program_ = new Program();
        program_.savingsAccount = 100.0f;
        program_.AddToSaving();

        switch (userInput)
        {
            case 0:
                program_.AddToSaving();
            break;
            case 1:
                program_.Withdraw();
            break;
            case 2:
                program_.Transfer();
            break;

            default:

            break;
        }
    }

    public void AddToSaving()
    {
        float amount = float.Parse(Console.ReadLine());
        savingsAccount += amount;
        Console.WriteLine("Savings are now this: " + savingsAccount);
    }


    public 
}


