using Godot;
using System;

public partial class World : Node2D
{
    public override void _Ready()
    {
        GD.Print("World is ready");
    }

    public override void _Process(double delta)
    {
        // Called every frame. 'delta' is the elapsed time since the previous frame.
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
