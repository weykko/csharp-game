using Godot;
using System;

public class RocketView
{
    private AnimatedSprite2D animationRocket;
    
    public RocketView(Node node)
    {
        animationRocket = node.GetNode<AnimatedSprite2D>("AnimatedRocket");
    }
    
    public void PlayMoveAnimation(string animation)
    {
        animationRocket.Play(animation);
    }
}
