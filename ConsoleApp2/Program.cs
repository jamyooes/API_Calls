/*
James Yoo
API
Activity 4
Requirements:
-Create a console app with a class that has an interface.
-Push code to git repo
-Class should have at least 1 interface
-Class should have at least three different types of properties
 (Not only fields, but properties)
-Interface should have 3 out of 4: instance methods, properties, events, and indexers.
-Have an instance of the class in the main method

I had trouble doing events. I wasn't too sure if I did it correctly
I referenced this https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/events/how-to-implement-interface-events
 */
using System;

interface Human 
{
    //Interface Properties
    public string FirstName { get; set; } 
    public string LastName { get; set; } 
    public DateTime DateOfBirth { get; set; } 
    public string Sex { get; set; }

    //Interface Event
    event EventHandler Greet;
    void GreetNow();
    //Instance methods
    public string Greetings();
}

public class Student: Human 
{
    //Fields
    private string firstName;
    private string lastName;
    private DateTime dateOfBirth;
    private string sex;
    private DateTime graduationDate;
    private double gpa;
    private string major;

    //Interface Properties
    public string FirstName 
    {
        get { return firstName; }
        set { firstName = value; }
    } 
    public string LastName 
    {
        get {return lastName; }
        set { lastName = value; }
    } 
    public DateTime DateOfBirth 
    {
        get {return dateOfBirth; }
        set { dateOfBirth = value; }
    } 
    public string Sex
    {
        get {return sex; }
        set { sex = value; }
    } 

    //Class Properties
    public DateTime GraduationDate
    {
        get { return graduationDate; }
        set { graduationDate = value; }
    } 
    public double GPA
    {
        get { return gpa; }
        set { gpa = value; }
    } 
    public string Major
    {
        get { return major; }
        set { major = value; }
    }

    //Event
    public event EventHandler Greet;

    public void GreetNow()
    {
        OnGreet(new EventArgs());
    }

    void OnGreet(EventArgs e)
    {
        if (Greet != null) Greet(this, e);
    }

    //Instance Method. I suggest putting a first name, but can remove the firstName part and will still be an instance method 
    public string Greetings() { return $"Hello, {firstName}!"; }
}

class Program
{
    public static void Main(string[] args)
    {
        Student James = new Student();
        James.FirstName = "James";  //Tested set accessors 
        Console.WriteLine(James.FirstName); //Tested get accessor
        James.Greet += new EventHandler(Greetings); //Subscribe to an event
        James.GreetNow();          // Outputs "Good day!"
        Console.WriteLine(James.Greetings());  //Test instance method
    }
    public static void Greetings(object source, EventArgs e)
    {
        Console.WriteLine("Good day!");
    }
}