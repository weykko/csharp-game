using Godot;
using System;
using System.Threading.Tasks;

public class PlayerModel
{
    public static float Speed;
    public static double fireRate;
    public static int Health;
    public static CharacterBody2D playerBody;

    public PlayerModel()
    {
        Speed = 300.0f;
        fireRate = 1 / 3;
        Health = 100;
    }
}
