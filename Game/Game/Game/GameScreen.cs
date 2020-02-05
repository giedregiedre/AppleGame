using Game.Gui;
using Game.Units;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Game
{
    class GameScreen
    {
        private int width;
        private int height;
        private Hero hero;
        private List<Enemy> enemies = new List<Enemy>();

        private Frame CounterFrame = new Frame(0, 0, 21, 5, '%');
        private TextLine CounterText = new TextLine(2, 2, 15, "Apples eaten = ");
        private int AppleCount = 0;

        public void CountApples()
        {
            foreach (Enemy enemy in enemies)
            {
                if (hero.X == enemy.X && hero.Y == enemy.Y)
                {
                    AppleCount++;
                }
            }
            Console.SetCursorPosition(18, 2);
            Console.Write(AppleCount);
        }
        public GameScreen(int width, int height)
        {
            this.width = width;
            this.height = height;
        }
        public void RemoveEnemies()
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].Y >= height - 3)
                {
                    enemies.Remove(enemies[i]);
                }
            }
        }
        public void SetHero(Hero hero)
        {
            this.hero = hero;
        }
        public void MoveHeroLeft()
        {
            if (hero.GetX() > 0)
            {
                hero.MoveLeft();
            }
        }
        public void MoveHeroRight()
        {
            if (hero.GetX() < width)
            {
                hero.MoveRight();
            }
        }
        public void AddEnemy(Enemy enemy)
        {
            enemies.Add(enemy);
        }
        public void MoveAllEnemiesDown()
        {
            foreach (Enemy enemy in enemies)
            {
                enemy.MoveDown(1);
            }
        }
        public void RenderCounter()
        {
            CounterFrame.Render();
            CounterText.Render();
            CountApples();
        }
        public void Render()
        {
            foreach (Enemy enemy in enemies)
            {
                Console.SetCursorPosition(enemy.X, enemy.Y);
                Console.Write('A');
            }
            Console.SetCursorPosition(hero.X, hero.Y);
            Console.Write('H');
        }
    }
}
