﻿using System;
using System.Collections.Generic;

public class SpecialisedSoldier : Private, ISpecialisedSoldier
{
    public SpecialisedSoldier(int id, string firstName, string lastName, double salary, string corps) 
        : base(id, firstName, lastName, salary)
    {
        this.Corps = corps;
    }
    public string Corps { get; private set; }
    public override string ToString()
    {
        return $"{base.ToString()}" + Environment.NewLine + $"Corps: {this.Corps}";
    }
}