using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


public class SpaceObject
{
    public int X = 0;
    public int Y = 0;
    public int XSpeed = 0;
    public int YSpeed = 0;
    public Texture2D _ObjectImage;

    public SpaceObject(string objectImage, ContentManager contentManager)
    {
        _ObjectImage = contentManager.Load<Texture2D>(objectImage);

    }
}

public class Asteroid : SpaceObject
{
    public Asteroid(string asteroidImage, ContentManager contentManager) : base(asteroidImage, contentManager){

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

    public void ProcessTurn(){
        X += XSpeed;
        Y += YSpeed;
    }
}