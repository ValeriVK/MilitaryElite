using System;
using System.Collections.Generic;
using System.Text;

public class LeutenantGeneral : Private, ILeutenantGeneral
{
    public LeutenantGeneral(int id, string firstName, string lastName, double salary, IList<IPrivate> privates) 
        : base(id, firstName, lastName, salary)
    {
        this.Privates = privates;
    }
    public IList<IPrivate> Privates { get; }
    public override string ToString()
    {
        var sb = new StringBuilder($"{base.ToString()}" + Environment.NewLine);
        sb.AppendLine("Privates:");
        sb.AppendLine($"  {string.Join(Environment.NewLine + "  ", this.Privates)}");
        return sb.ToString().Trim();
    }
}