using EventSystem;
using Godot;
using NaturalEvents;
using System;
using System.Collections.Generic;

public partial class World : Node2D
{
    // Events
    public SleepEvent Sleep { get; set; } = new SleepEvent();

    public List<Individual> Individuals { get; set; } = [];

    public override void _Ready()
    {
        GD.Print("World is ready");
        // Initialize individuals
        var individual1 = new Individual();
        AddChild(individual1);
        Individuals.Add(individual1);
    }

    public override void _Process(double delta)
    {
        if (Input.IsActionPressed("trigger"))
        {
            // Trigger the sleep event on the individual
            GD.Print(Sleep.ToString());
            Sleep.TriggerEvent(Individuals[0]);
        }
    }

    public void ShowWorld()
    {
        Visible = true;
    }

    public void HideWorld()
    {
        Visible = false;
    }
}
