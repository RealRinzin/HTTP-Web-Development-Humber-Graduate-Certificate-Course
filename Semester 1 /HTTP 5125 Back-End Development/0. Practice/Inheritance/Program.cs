namespace Inheritance
{
    // Fruit Class OBject
    class ArthematicOperation
    {
        public int firstNumber;
        public int secondNumber;

        // public ArthematicOperation(int firstNumber_,int secondNumber_)
        // {
        //     firstNumber = firstNumber_;
        //     secondNumber = secondNumber_;
        // }

        // Addition Function

        public void Addition(int firstNumber, int secondNumber)
        {
            Console.WriteLine(firstNumber + secondNumber);
        }
    }

    class Operations : ArthematicOperation
    {
        public void Substraction(int num1, int num2)
        {
            Console.WriteLine(num2 - num1);
        }

    }

    // Main Program Class
    class Program
    {
        static void Main()
        {
            ArthematicOperation myAdd = new ArthematicOperation();
            Operations test = new Operations();
            // myAdd.Addition(34,34);
            test.Addition(1, 23);
            test.Substraction(2,10);

        }
    }
}