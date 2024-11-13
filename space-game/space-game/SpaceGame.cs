using System;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace space_game;
public class SpaceGame : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Ship playerShip;
    private Terminal playerTerminal;
    int maxX;
    int maxY;
    KeyboardState currentKeyboardState;
    KeyboardState previousKeyboardState;

    public SpaceGame()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        playerShip = new Ship("ball", Content);
        playerTerminal = new Terminal(_graphics, Content);
        maxX = _graphics.PreferredBackBufferWidth;
        maxY = _graphics.PreferredBackBufferHeight;
        base.Initialize();
    }

    protected override void LoadContent()
    {
        
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {


        currentKeyboardState = Keyboard.GetState();




        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        if(Keyboard.GetState().IsKeyDown(Keys.Up)){
            playerShip.speed += 1;
        }
        if(Keyboard.GetState().IsKeyDown(Keys.Down)){
            playerShip.speed -= 1;
        }
        if (Keyboard.GetState().IsKeyDown(Keys.Enter) && CheckAlreadyPressed(Keys.Enter)){
            playerShip.UpdateCords(maxX, maxY);
        }
        foreach (Keys key in Keyboard.GetState().GetPressedKeys()){
            if(CheckAlreadyPressed(key)){
                playerTerminal.GetInput(key);
            }
        }

        base.Update(gameTime);

        previousKeyboardState = currentKeyboardState;
    }

    private bool CheckAlreadyPressed(Keys key){
        return currentKeyboardState.IsKeyDown(key) && previousKeyboardState.IsKeyUp(key);
    }


    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.White);
        playerTerminal.DrawToSurface();

        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        _spriteBatch.Draw(playerShip._shipImage, new Vector2(playerShip.X,playerShip.Y), Color.White);
        _spriteBatch.End();
        base.Draw(gameTime);
    }
}
