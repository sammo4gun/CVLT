using Godot;
using System;

public partial class BaseScreen : Node2D
{
    public override void _Ready()
    {
        // Called every time the node is added to the scene.
        // Initialization here
    }

    public override void _Process(double delta)
    {
        // Called every frame. 'delta' is the elapsed time since the previous frame.
    }

    public virtual void ShowScreen()
    {
        Visible = true;
    }

    public virtual void HideScreen()
    {
        Visible = false;
    }
}
