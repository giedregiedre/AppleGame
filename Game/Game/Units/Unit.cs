using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Units
{
    class Unit
    {
        public int X { get; set; }
        public int Y { get; set; }
        private string Name;

        public Unit(int x, int y, string name)
        {
            X = x;
            Y = y;
            Name = name;
        }
    }
}
