public class Human
{
    public string name {get; set;}
    public virtual void ListName()
    {
        Console.WriteLine($"{name} uses a base class");
    }

}

public class Student: Human
{
    public string programName {get; set;}
    public override void ListName()
    {
        Console.WriteLine($"{base.name} is in the {programName}");
    }
}

public class Graduate : Human
{
    public bool isEmployed = true;

}