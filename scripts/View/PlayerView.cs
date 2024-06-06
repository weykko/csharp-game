using Godot;
using System;
using System.Threading.Tasks;

public class PlayerView
{
    private AnimatedSprite2D animationRockets;
    private AnimatedSprite2D animationFire;
    private static AnimatedSprite2D baseSprite;
    public ProgressBar HealthBar;

    public PlayerView(Node playerNode)
    {
        animationRockets = playerNode.GetNode<AnimatedSprite2D>("AnimationRockets");
        animationFire = playerNode.GetNode<AnimatedSprite2D>("AnimatedWeapon");
        HealthBar = playerNode.GetNode<ProgressBar>("PlayerView/HealthBar");
        baseSprite = playerNode.GetNode<AnimatedSprite2D>("Base");
    }

    public static void UpdateSprite()
    {
        if (PlayerModel.Health > 75)
            baseSprite.Play("100hp");
        else if (PlayerModel.Health > 50)
            baseSprite.Play("75hp");
        else if (PlayerModel.Health > 25)
            baseSprite.Play("50hp");
        else 
            baseSprite.Play("25hp");
    }
    
    public void PlayMoveAnimation(string animation)
    {
        animationRockets.Play(animation);
    }

    public void PlayFireAnimation(string animation)
    {
        animationFire.Play(animation);
    }
}
