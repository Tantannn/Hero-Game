using Godot;
using System;

public partial class player : CharacterBody2D
{
	public const float Speed = 100.0f;
	public const float JumpVelocity = -250.0f;

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		var sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");

		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
			sprite.Play("jump");
		}

		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
			sprite.Play("run");
			if (direction.X > 0)
			{
				sprite.FlipH = false;
			}
			else
			{
				sprite.FlipH = true;
			}
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			sprite.Play("idle");
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
