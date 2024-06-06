using Godot;
using System;
using System.Threading.Tasks;

public partial class Alien : CharacterBody2D
{
	private int Health = 10;
	public float Speed = 50;
	private AlienView animations;

	public override void _Ready()
	{
		animations = new AlienView(this);
	}
	
	public override void _PhysicsProcess(double delta)
	{
		animations.PlayMoveAnimation("move");
		Vector2 velocity = Velocity;
		var player = PlayerModel.playerBody;
		velocity = Position.DirectionTo(new Vector2(0, 200)) * Speed;

		Velocity = velocity;
		MoveAndSlide();
	}

	public void TakeDamage(int damage)
	{
		Health -= damage;
		if (Health <= 0) Die();
	}
	
	public void BodyEntered(Node body)
	{
		if (body is Earth) main.GameOver();
	}
	
	private async void Die()
	{		
		QueueFree();
	}
}
