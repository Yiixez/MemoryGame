using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame.classes
{
    internal class Player
    {
        private int id = 0;
        private int points = 0;

        public Player(int id)
        {
            this.id = id;
        }

        public int getId() { return id; }
        public int getPoints() { return points; }
        public void setPoints(int points) { this.points = points; }
        public void addPoints(int points) { this.points += points; }
    }
}
