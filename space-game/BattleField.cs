using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class BattleField
{
    public RenderTarget2D _battlefieldSurface;
    private GraphicsDeviceManager _graphicsDeviceManager;
    private GraphicsDevice _graphicsDevice;
    private SpriteBatch _spriteBatch;
    private Texture2D _lineTexture;
    private int _gridSpace = 20;
    public Ship _playerShip;
    public List<SpaceObject> _SpaceObjects;

    public BattleField(GraphicsDeviceManager _graphics, ContentManager contentManager){
        _graphicsDeviceManager = _graphics;
        _graphicsDevice = _graphics.GraphicsDevice;
        _battlefieldSurface = new RenderTarget2D(_graphics.GraphicsDevice, _graphics.PreferredBackBufferWidth, (_graphics.PreferredBackBufferHeight /4) * 3);
        _spriteBatch = new SpriteBatch(_graphicsDevice);
        _playerShip = new Ship("ball", contentManager);
        _SpaceObjects = [new Asteroid("asteroid", contentManager)];
        foreach(SpaceObject spaceObject in _SpaceObjects){
            spaceObject.X = 10;
            spaceObject.Y = 10;
        }
    }

    public void DrawToSurface(){
        _lineTexture = new Texture2D(_graphicsDevice, 1,1);
        _lineTexture.SetData(new[] {Color.White});
        _graphicsDevice.SetRenderTarget(_battlefieldSurface);
        _graphicsDevice.Clear(Color.Black);
        _spriteBatch.Begin();
        //Drawing Grid lines
        for (int x = 0; x < _graphicsDeviceManager.PreferredBackBufferWidth; x += _gridSpace){
            _spriteBatch.Draw(_lineTexture, new Rectangle(x, 0, 1,_graphicsDeviceManager.PreferredBackBufferHeight), Color.White);
        }
        for (int y = 0; y < _graphicsDeviceManager.PreferredBackBufferHeight; y += _gridSpace){
            _spriteBatch.Draw(_lineTexture, new Rectangle(0, y, _graphicsDeviceManager.PreferredBackBufferWidth, 1), Color.White);
        }

        //Drawing ships
        _spriteBatch.Draw(_playerShip._ObjectImage, new Rectangle(_playerShip.X * _gridSpace, _playerShip.Y * _gridSpace, _gridSpace, _gridSpace),Color.White);
        _spriteBatch.Draw(_playerShip._ObjectImage, new Rectangle((_playerShip.X + _playerShip.XSpeed) * _gridSpace, (_playerShip.Y + _playerShip.YSpeed) * _gridSpace, _gridSpace, _gridSpace),Color.White * 0.5f);
        foreach(SpaceObject spaceObject in _SpaceObjects){
            _spriteBatch.Draw(spaceObject._ObjectImage, new Rectangle(spaceObject.X * _gridSpace, spaceObject.Y * _gridSpace, _gridSpace, _gridSpace),Color.White);
            //TODO do I want all space objects to have a projection
            _spriteBatch.Draw(spaceObject._ObjectImage, new Rectangle((spaceObject.X + spaceObject.XSpeed) * _gridSpace, (spaceObject.Y + spaceObject.YSpeed) * _gridSpace, _gridSpace, _gridSpace),Color.White * 0.5f);

        }

        _spriteBatch.End();

        _graphicsDevice.SetRenderTarget(null);
    }
    public void UpdateObjects(){
        _playerShip.Update();
        foreach(SpaceObject spaceObject in _SpaceObjects){
            if (spaceObject.X == _playerShip.X && spaceObject.Y == _playerShip.Y){Console.WriteLine("Ship destroyed");}
            spaceObject.Update();
        }
    }
    public void CheckCollisions(){
        
    }
}