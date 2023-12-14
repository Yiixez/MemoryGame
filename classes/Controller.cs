using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame.classes
{
    internal class Controller
    {
        private Player turn = null;
        private List<Player> playerList = new List<Player>();
        private List<Card> cards = new List<Card>();

        public Player getTurn() { return turn; }
        public void switchTurn(Player p) { turn = p; }

        public void addPlayer(Player player) { playerList.Add(player); }
        public List<Player> getPlayers() { return playerList; }

        public List<Card> getCards() { return cards; }
        public void addCard(Card card) { cards.Add(card); }
        public void randomizeCards() { cards.Shuffle(); }
    }
}
