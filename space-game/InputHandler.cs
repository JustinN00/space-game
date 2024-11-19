using System;
using System.Collections.Generic;
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
             _battlefield.UpdateShips();
        }
        else{
            _terminal.ProcessInput(keys);
        }
    }
    public void ParseCommand(string rawCommand){
        //TODO using split or something allow for multiple inputs at once
        // string[] splitCommand = rawCommand.Split(' ');
        // List<(string, int)> parsedCommands;
        // foreach(string command in splitCommand){
        //     //parse each command to determine if it is an additional command or a modifier.

        // }


        switch(rawCommand)
        {
            case "RIGHT":
                _battlefield._ships[0].XSpeed += 1;
                break;
            case "LEFT":
                _battlefield._ships[0].XSpeed -= 1;
                break;
            case "UP":
                _battlefield._ships[0].YSpeed -= 1;
                break;
            case "DOWN":
                _battlefield._ships[0].YSpeed += 1;
                break;
            case "NORMALIZE":
                _battlefield._ships[0].NormalizeSpeed();
                break;
            case "FIRE":
                break;
        }

        Console.WriteLine(rawCommand);
    }
}