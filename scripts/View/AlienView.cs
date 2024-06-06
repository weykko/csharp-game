using Godot;
using System;

public class AlienView
{
    private AnimatedSprite2D animationAlien;

    public AlienView(Node alienNode)
    {
        animationAlien = alienNode.GetNode<AnimatedSprite2D>("AnimatedAlien");
    }
    
    public void PlayMoveAnimation(string animation)
    {
        animationAlien.Play(animation);
    }
}
