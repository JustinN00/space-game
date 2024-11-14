using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class Ship
{
    public Texture2D _shipImage;

    public int XSpeed = 0;
    public int YSpeed = 0;
    public int X = 0;
    public int Y = 0;

    public Ship(string shipImage, ContentManager contentManager)
    {
        _shipImage = contentManager.Load<Texture2D>("ball");
    }
    public void AdjustSpeed(int XChange = 0, int YChange = 0){
        XSpeed += XChange;
        YSpeed += YChange;
    }

    public void ProcessTurn(){
        X += XSpeed;
        Y += YSpeed;
    }
}