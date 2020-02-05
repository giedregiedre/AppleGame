using Game.Game;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Gui
{
    class GuiController
    {
        private GameWindow gameWindow;
        private CreditWindow creditWindow;
        private GameController gameController;
        public GuiController()
        {
            gameWindow = new GameWindow();
            gameController = new GameController();
        }
        public void ShowMenu()
        {
            gameWindow.Render();
        }
        bool objectNotCreated = true;
        public void ShowCreditWindow()
        {

            if (objectNotCreated)
            {
                creditWindow = new CreditWindow();
                objectNotCreated = false;
            }
            creditWindow.Render();
        }
        public void StartMenuLoop()
        {
            ShowMenu();
            bool showingCredits = false;
            do
            {
                while (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedChar = Console.ReadKey(true);

                    switch (pressedChar.Key)
                    {
                        case ConsoleKey.Enter:
                            if (gameWindow.IsStartButonActive())
                            {
                                gameController.StartGame();
                            }
                            else if (gameWindow.IsCreditsButonActive())
                            {
                                if (!showingCredits)
                                {
                                    ShowCreditWindow();
                                    showingCredits = true;
                                }
                                else
                                {
                                    showingCredits = false;
                                    ShowMenu();
                                }
                            }
                            else if (gameWindow.IsQuitButonActive())
                            {
                                Environment.Exit(0);
                            }
                            break;
                        case ConsoleKey.Escape:
                            if (gameWindow.IsCreditsButonActive())
                            {
                                if (showingCredits)
                                {
                                    showingCredits = false;
                                    ShowMenu();
                                }
                            }
                            else if (gameWindow.IsQuitButonActive())
                            {
                                Environment.Exit(0);
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            gameWindow.SetActiveButtonToTheRight();
                            break;
                        case ConsoleKey.LeftArrow:
                            gameWindow.SetActiveButtonToTheLeft();
                            break;
                    }
                }
            } while (true);
            
            
        }
    }
}
