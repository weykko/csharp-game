using Godot;
using System;

public partial class main : Node2D
{
	[Export]
	public PackedScene PlayerScene;
	private Marker2D spawnPoint;
	public static VBoxContainer gameOver;
	public static VBoxContainer gameWin;
	public static int counterKills;
	public static Node2D Enemies;
	
	public override void _Ready()
	{
		spawnPoint = GetNode<Marker2D>("SpawnPoint"); // Находим точку спавна
		gameOver = GetNode<VBoxContainer>("GameOver");
		gameWin = GetNode<VBoxContainer>("GameWin");
		Enemies = GetNode<Node2D>("Enemies");
		gameOver.Visible = false;
		gameWin.Visible = false;
		counterKills = 0;
	}
	
	public override void _PhysicsProcess(double delta)
	{
		if (Enemies.GetChildCount() == 0) GameWin();
	}
	
	private void SpawnPlayer()
	{
		var playerInstance = (CharacterBody2D)PlayerScene.Instantiate<CharacterBody2D>();
		playerInstance.Position = spawnPoint.Position; // Устанавливаем позицию спавна
		AddChild(playerInstance);
	}

	public void RestartPressed()
	{
		GetTree().ReloadCurrentScene();
	}
	
	public void MenuPressed()
	{
		GetTree().ChangeSceneToFile("res://scenes/main_menu.tscn");
	}
	
	public static void GameOver()
	{
		gameOver.Visible = true;
	}
	
	public static void GameWin()
	{
		 gameWin.Visible = true;
	}
}
