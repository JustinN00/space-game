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
    private BattleField battleField;
    private InputHandler inputHandler;
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
        playerShip = new Ship("ball", Content);
        playerTerminal = new Terminal(_graphics, Content);
        battleField = new BattleField(_graphics, Content);
        inputHandler = new InputHandler(playerTerminal, battleField);
        maxX = _graphics.PreferredBackBufferWidth;
        maxY = _graphics.PreferredBackBufferHeight;
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
    }

    protected override void Update(GameTime gameTime)
    {
        currentKeyboardState = Keyboard.GetState();
        if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        foreach (Keys key in Keyboard.GetState().GetPressedKeys()){
            if(CheckAlreadyPressed(key)){
                inputHandler.ReadInput(key);
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
        battleField.DrawToSurface();
        _spriteBatch.Begin();
        _spriteBatch.Draw(battleField._battlefieldSurface,new Vector2(0, 0), Color.White);
        _spriteBatch.Draw(playerTerminal._terminalSurface,new Vector2(0,_graphics.PreferredBackBufferHeight - playerTerminal._terminalSurface.Height), Color.White);
        _spriteBatch.End();
        base.Draw(gameTime);
    }
}
