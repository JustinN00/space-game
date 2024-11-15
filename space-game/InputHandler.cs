using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class InputHandler
{
    private Terminal _terminal;
    private BattleField _battlefield;
    public InputHandler(Terminal terminal, BattleField battleField)
    {
        _terminal = terminal;
        _battlefield = battleField;
    }
    public void ReadInput(Keys keys){
        if (keys == Keys.Enter){
             ParseCommand(_terminal.ReturnCommand());
             _battlefield._ships[0].XSpeed += 1;
             _battlefield.UpdateShips();
        }
        else{
            _terminal.ProcessInput(keys);
        }
    }
    public void ParseCommand(string rawCommand){
        Console.WriteLine(rawCommand);
    }
}