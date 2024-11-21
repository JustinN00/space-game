using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


public abstract class SpaceObject
{
    public int health;
    public int X = 0;
    public int Y = 0;
    public int XSpeed = 0;
    public int YSpeed = 0;
    public Texture2D _ObjectImage;

    public SpaceObject(string objectImage, ContentManager contentManager, int _health = 1)
    {
        _ObjectImage = contentManager.Load<Texture2D>(objectImage);
        health = _health;

    }
    
    public abstract void Update();
}

public class Asteroid : SpaceObject
{
    public Asteroid(string asteroidImage, ContentManager contentManager) : base(asteroidImage, contentManager){

    }
    public override void Update()
    {
        
    }
}



public class Ship : SpaceObject
{
    public Ship(string shipImage, ContentManager contentManager) : base(shipImage, contentManager)
    {
    }
    public void AdjustSpeed(int XChange = 0, int YChange = 0){
        XSpeed += XChange;
        YSpeed += YChange;
    }
    public void NormalizeSpeed(){
        XSpeed = 0;
        YSpeed = 0;
    }

    public override void Update(){
        X += XSpeed;
        Y += YSpeed;
    }
}