using Godot;
using System;

public partial class Rocket : Area2D
{
	private RocketView animations;

	public override void _Ready()
	{
		animations = new RocketView(this);
		Connect("body_entered", new Callable(this, nameof(OnBodyEntered)));
	}
	
	public override void _PhysicsProcess(double delta)
	{
		Position += Transform.X * RocketModel.Speed;
		animations.PlayMoveAnimation("flying");
	}
	
	public void OnBodyEntered(Node body)
	{
		QueueFree();
		// if (body is StaticBody2D)
		// 	QueueFree();
		if (body is Alien)
		{
			((Alien)body).TakeDamage(1);
		}
	}
}
