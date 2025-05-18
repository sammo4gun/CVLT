using Godot;
using System;

public partial class Individual : Node2D
{
    public override void _Ready()
    {
        Trait trait = new Trait("Strength", "Physical power", 10);
        GD.Print(trait.ToString());
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
