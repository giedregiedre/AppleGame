using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Gui
{
    sealed class GameWindow : Window
    {
        private TextBlock titleTextBlock;
        private List<Button> Buttons = new List<Button>();

        public GameWindow() : base(0, 0, 120, 30, '%')
        {
            titleTextBlock = new TextBlock(10, 5, 100, new List<String> { "Eat Apples!", "Giedres J kuryba!", "Made in Vilnius Coding School!" });

            Buttons.Add(new Button(20, 13, 18, 5, "Start"));
            Buttons[0].SetActive();
            Buttons.Add(new Button(50, 13, 18, 5, "Credits"));
            Buttons.Add(new Button(80, 13, 18, 5, "Quit"));
        }

        public override void Render()
        {
            base.Render();

            titleTextBlock.Render();

            foreach (Button button in Buttons)
            {
                button.Render();
            }

            Console.SetCursorPosition(0, 0);
        }
        public void SetActiveButtonToTheRight()
        {
            for (int i = 0; i < Buttons.Count; i++)
            {
                if (Buttons[i].IsActive)
                {
                    Buttons[i].SetNotActive();
                    Buttons[i].Render();
                    if (i == Buttons.Count - 1)
                    {
                        Buttons[0].SetActive();
                        Buttons[0].Render();
                        break;
                    }
                    else
                    {
                        Buttons[i + 1].SetActive();
                        Buttons[i + 1].Render();
                        break;
                    }
                }
            }
        }
        public void SetActiveButtonToTheLeft()
        {
            for (int i = 0; i < Buttons.Count; i++)
            {
                if (Buttons[i].IsActive)
                {
                    Buttons[i].SetNotActive();
                    Buttons[i].Render();
                    if (i == 0)
                    {
                        Buttons[2].SetActive();
                        Buttons[2].Render();
                        break;
                    }
                    else
                    {
                        Buttons[i - 1].SetActive();
                        Buttons[i - 1].Render();
                        break;
                    }
                }
            }
        }
        public bool IsStartButonActive()
        {
            if (Buttons[0].IsActive)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsCreditsButonActive()
        {
            if (Buttons[1].IsActive)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsQuitButonActive()
        {
            if (Buttons[2].IsActive)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
