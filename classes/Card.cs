using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame.classes
{
    internal class Card
    {
        private int id = 0;
        private bool visible = false;
        private bool enabled = true;

        public Card(int id)
        {
            this.id = id;
        }

        public int getId() { return id; }
        public bool getVisibility() { return visible; }

        public void setVisibility(bool visible) { this.visible = visible; }    
        public bool isEnabled() { return enabled; }
        public void setEnabled(bool enabled) {  this.enabled = enabled; }
    }
}
