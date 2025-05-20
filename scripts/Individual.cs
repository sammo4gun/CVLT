using Godot;
using System;

public partial class Individual : Node2D
{
    // Properties
    public string IndividualName { get; set; } = "Johsnson";
    public int Age { get; set; } = 19;

    // Traits
    public Trait Strength { get; set; } = new Trait("Strength", "Physical power", 10);
    public Trait Joy { get; set; } = new Trait("Joy", "Social connection", 10);

    public override void _Ready()
    {
        GD.Print(Strength.ToString());
    }

    public bool ModifyTrait(string traitName, int value)
    {
        switch (traitName)
        {
            case "Strength":
                Strength.Value += value;
                GD.Print($"Strength modified by {value}. New value: {Strength.Value}");
                return true;
            case "Joy":
                Joy.Value += value;
                return true;
            default:
                GD.Print($"Trait {traitName} not found.");
                return false;
        }
    }

    public override void _Process(double delta)
    {
        // Called every frame. 'delta' is the elapsed time since the previous frame.
    }

    public void ShowIndividual()
    {
        Visible = true;
    }

    public void HideIndividual()
    {
        Visible = false;
    }
}
