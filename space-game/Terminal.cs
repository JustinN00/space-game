using System;
using System.Data;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


public class Terminal
{
    public RenderTarget2D _terminalSurface;
    private GraphicsDeviceManager _graphicsDeviceManager;
    private GraphicsDevice _graphicsDevice;
    private SpriteBatch _spriteBatch;
    private SpriteFont _font;
    private string _text = "";

    public Terminal(GraphicsDeviceManager _graphics, ContentManager contentManager){
        _graphicsDeviceManager = _graphics;
        _graphicsDevice = _graphics.GraphicsDevice;
        _terminalSurface = new RenderTarget2D(_graphics.GraphicsDevice, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight / 4);
        _spriteBatch = new SpriteBatch(_graphicsDevice);
        _font = contentManager.Load<SpriteFont>("terminalFont");
    }

    public void DrawToSurface(){
        _graphicsDevice.SetRenderTarget(_terminalSurface);
        _graphicsDevice.Clear(Color.Black);
        _spriteBatch.Begin();
        _spriteBatch.DrawString(_font, _text, new Vector2(0,0),Color.White);
        _spriteBatch.End();
        _graphicsDevice.SetRenderTarget(null);
    }

    public void ProcessInput(Keys key){
        if (key == Keys.Space){_text += " ";}
        else if (key == Keys.Back && _text != ""){_text = _text.Remove(_text.Length - 1);}
        else if (key >= Keys.A && key <= Keys.Z){_text += key.ToString();}
        else {_text += "N/I";}
    }

    public string ReturnCommand(){
        string command = _text;
        _text = "";
        return command;
    }
}