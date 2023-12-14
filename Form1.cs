using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using MemoryGame.classes;

namespace MemoryGame
{
    public partial class Form1 : Form
    {
        private Dictionary<Card, Button> Pairs = new Dictionary<Card, Button>();
        private Controller controller = new Controller();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            addPlayers(2);
            controller.switchTurn(controller.getPlayers()[0]);
            turn.Text = "Turn: Player " + controller.getTurn().getId().ToString();

            for (int i = 0; i < 8; i++)
            {
                controller.addCard(new Card(i));
                controller.addCard(new Card(i));
            }
            controller.randomizeCards();

            foreach (var card in controller.getCards())
            {
                Button button = new Button();
                button.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
                Pairs.Add(card, button);
                layoutPanel.Controls.Add(button);
            };

            foreach (var item in Pairs)
            {
                item.Value.Click += new EventHandler(btn_Click);
            }
        }

        private async void btn_Click(object sender, EventArgs e)
        {
            List<Card> cards = new List<Card>();
            List<Button> buttons = new List<Button>();

            foreach (var item in Pairs)
            {
                if (item.Value.Equals(sender))
                {
                    if (item.Key.getVisibility())
                        return; //Item is already visible

                    item.Key.setVisibility(true);
                    item.Value.Text = item.Key.getId().ToString();
                }
            }

            foreach (var item in Pairs)
            {
                if (item.Key.getVisibility() == true)
                {
                    cards.Add(item.Key);
                    buttons.Add(item.Value);
                }
            }

            if (cards.Count == 2)
            {
                foreach (var item in Pairs)
                {
                    if (item.Key.getVisibility().Equals(false))
                        item.Value.Enabled = false;
                }
                await checkTurnSwitchAsync(cards, buttons);
            }
        }

        private async Task checkTurnSwitchAsync(List<Card> cards, List<Button> buttons)
        {
            await Task.Delay(3000);
            if (cards[0].getId() == cards[1].getId())
            {
                cards[0].setVisibility(false);
                cards[1].setVisibility(false);
                cards[0].setEnabled(false);
                cards[1].setEnabled(false);
                buttons[0].Enabled = false;
                buttons[1].Enabled = false;
                controller.getTurn().addPoints(2);
                points1.Text = controller.getPlayers()[0].getPoints().ToString();
                points2.Text = controller.getPlayers()[1].getPoints().ToString();

                foreach (var item in Pairs)
                {
                    if (item.Key.isEnabled().Equals(false))
                        item.Value.Enabled = false;
                    else
                        item.Value.Enabled = true;
                }
            }
            else
            {
                cards[0].setVisibility(false);
                cards[1].setVisibility(false);
                buttons[0].Text = "";
                buttons[1].Text = "";

                if (controller.getPlayers()[0] == controller.getTurn())
                    controller.switchTurn(controller.getPlayers()[1]);
                else if (controller.getPlayers()[1] == controller.getTurn())
                    controller.switchTurn(controller.getPlayers()[0]);

                turn.Text = "Turn: Player " + controller.getTurn().getId().ToString();

                foreach (var item in Pairs)
                {
                    if (item.Key.isEnabled().Equals(false))
                        item.Value.Enabled = false;
                    else
                        item.Value.Enabled = true;
                }
            }
        }

        private void addPlayers(int amount)
        {
            for (int i = 0; i < amount; ++i)
            {
                Player p = new Player(i + 1);
                controller.addPlayer(p);
            }
        }

        private void newGame_Click(object sender, EventArgs e)
        {
            foreach (Player player in controller.getPlayers())
            {
                player.setPoints(0);
            }

            foreach (var item in Pairs)
            {
                item.Key.setVisibility(false);
                item.Key.setEnabled(true);
                item.Value.Enabled = true;
                item.Value.Text = "";
            }

            if (controller.getPlayers()[0] == controller.getTurn())
                controller.switchTurn(controller.getPlayers()[1]);
            else if (controller.getPlayers()[1] == controller.getTurn())
                controller.switchTurn(controller.getPlayers()[0]);

            turn.Text = "Turn: Player " + controller.getTurn().getId().ToString();
            points1.Text = controller.getPlayers()[0].getPoints().ToString();
            points2.Text = controller.getPlayers()[1].getPoints().ToString();
        }
    }
}
