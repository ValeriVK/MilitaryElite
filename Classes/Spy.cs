using System;

public class Spy : Private, ISpy
{
    public Spy(int id, string firstName, string lastName, double salary, int codeNumber)
        : base(id, firstName, lastName, salary)
    {
        this.CodeNumber = codeNumber;
    }
    public int CodeNumber { get; private set; }
    public override string ToString()
    {
        return $"Name: {this.FirstName} {this.LastName} Id: {this.Id}" + Environment.NewLine + $"Code Number: {this.CodeNumber}";
    }

    
}