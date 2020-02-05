using Game.Gui;
using Game.Units;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Game
{
    class GameController
    {
        private GameScreen myGame;
        private GuiController guiController;
        public void StartGame()
        {
            InitGame();
            Console.Clear();
            myGame.Render();
            myGame.RenderCounter();
            StartGameLoop();
        }

        private void InitGame()
        {
            myGame = new GameScreen(120, 30);

            myGame.SetHero(new Hero(60, 15, "HERO"));

            ManageEnemies();
        }
        public void ManageEnemies()
        {
            Random rnd = new Random();
            int enemyCount = 0;
            for (int i = 0; i < GetEnemyCount(); i++)
            {
                myGame.AddEnemy(new Enemy(enemyCount, rnd.Next(0, 120), 0, "enemy" + enemyCount));
                enemyCount++;
            }
            myGame.RemoveEnemies();
        }     
        private int GetEnemyCount()
        {
            return 2;
        }
        private void StartGameLoop()
        {
            do
            {
                while (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedChar = Console.ReadKey(true);

                    switch (pressedChar.Key)
                    {
                        case ConsoleKey.Escape:
                            guiController = new GuiController();
                            guiController.StartMenuLoop();
                            break;
                        case ConsoleKey.RightArrow:
                            myGame.MoveHeroRight();
                            myGame.MoveAllEnemiesDown();
                            ManageEnemies();
                            Console.Clear();
                            myGame.Render();
                            myGame.RenderCounter();
                            break;
                        case ConsoleKey.LeftArrow:
                            myGame.MoveHeroLeft();
                            myGame.MoveAllEnemiesDown();
                            ManageEnemies();
                            Console.Clear();
                            myGame.Render();
                            myGame.RenderCounter();
                            break;
                    }
                }
            } while (true);
        }
    }
}
