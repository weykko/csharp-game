using Godot;
using System;
using System.Threading.Tasks;

public partial class Player : CharacterBody2D
{
	[Export] 
	public PackedScene rocket;
	
	private double Timer = 1;
	private PlayerView view;
	private PlayerModel models;

	
	public override void _Ready()
	{
		view = new PlayerView(this);
		models = new PlayerModel();
		PlayerModel.playerBody = this;
		view.HealthBar.MaxValue = PlayerModel.Health;
	}

	public override void _PhysicsProcess(double delta)
	{
		PlayerView.UpdateSprite();
		MovePlayer();
		RotatePlayer();
		if (Input.IsActionJustPressed("fire") && Timer >= PlayerModel.fireRate)
		{
			FirePlayer();
		}
		else Timer += delta;
		view.HealthBar.Value = PlayerModel.Health;
	}

	private void MovePlayer()
	{
		Vector2 velocity = Velocity;
		Vector2 direction = Input.GetVector(
			"move_left",
			"move_right",
			"move_up",
			"move_down");
		if (direction != Vector2.Zero)
		{
			velocity = direction * PlayerModel.Speed;
			view.PlayMoveAnimation("move");
		}
		else
		{
			velocity = new Vector2(0, 0);
			view.PlayMoveAnimation("idle");
		}

		Velocity = velocity;
		MoveAndSlide();
		
		LookAt(GetGlobalMousePosition());
	}

	private void RotatePlayer()
	{
		// if (Velocity != Vector2.Zero)
		// {
		//		Rotation = Velocity.Angle() + Mathf.Pi / 2;
		// }
		LookAt(GetGlobalMousePosition());
		Rotation += Mathf.Pi / 2;
	}

	private async Task FirePlayer()
	{
		view.PlayFireAnimation("fire");

		await Task.Delay(40);

		var r1 = rocket.Instantiate<Area2D>();
		GetTree().Root.AddChild(r1);
		r1.Transform = GetNode<Marker2D>("Gun1").GlobalTransform;

		var r2 = rocket.Instantiate<Area2D>();
		GetTree().Root.AddChild(r2);
		r2.Transform = GetNode<Marker2D>("Gun2").GlobalTransform;

		Timer = 0;
	}
	
	public void BodyEntered(Node body)
	{
		if (body is Alien) TakeDamage(20);
	}

	public void TakeDamage(int value)
	{
		PlayerModel.Health -= value;
		if (PlayerModel.Health <= 0) Die();
	}
	
	public void Die()
	{
		QueueFree();
  		main.GameOver();
	}
}
