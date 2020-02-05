using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Units
{
    class Enemy : Unit
    {
        private int id;
        public Enemy(int id, int x, int y, string name) : base(x, y, name)
        {
            this.id = id;
            X = x;
            Y = y;
        }

        public void MoveDown(int moveDownSpeed)
        {
            Y+=moveDownSpeed;
        }
    }
}
