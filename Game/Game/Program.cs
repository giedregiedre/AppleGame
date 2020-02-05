using Game.Game;
using Game.Gui;
using System;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            GuiController guiController = new GuiController();
            guiController.StartMenuLoop();
        }
    }
}
