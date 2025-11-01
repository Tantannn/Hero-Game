using Godot;
using System;

namespace RocketGame.scripts;

public partial class Deadzone : Area2D
{
	private void _OnBodyEntered(Node2D body)
	{
		GD.Print($"Body entered deadzone: {body.Name}");t
		var timer = GetTree().CreateTimer(1.0f); 
		timer.Timeout += OnTimeout;
	}

	private void OnTimeout()
	{
		GetTree().ReloadCurrentScene();
	}
}
