using Godot;
using System;

namespace RocketGame.scripts ;

public partial class Deadzone : Area2D
{
	private void _OnBodyEntered(Node2D body)
	{
		GD.Print($"Body entered deadzone: {body.Name}");
		GetTree().ReloadCurrentScene();
	}
}
