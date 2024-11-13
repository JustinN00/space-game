using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class Ship
{
    public Texture2D _shipImage;
    public int X;
    public int Y;

    private int XDirection = 1;
    private int YDirection = 1;
    public int speed = 10;
    
    public Ship(string shipImage, ContentManager contentManager)
    {
        _shipImage = contentManager.Load<Texture2D>("ball");
    }

    public void UpdateCords(int maxX, int maxY){
        int nextX = this.X + XDirection;
        if (nextX + this._shipImage.Width < maxX && XDirection == 1){this.X += XDirection * speed;}
        else if (nextX > 0 && XDirection == -1){this.X += XDirection * speed;}
        else {this.XDirection *= -1;}

        int nextY = this.Y + YDirection;
        if ( nextY + this._shipImage.Height < maxY && YDirection == 1){this.Y += YDirection * speed;}
        else if (nextY > 0 && YDirection == -1){this.Y += YDirection * speed;}
        else {this.YDirection *= -1;}
    }
}