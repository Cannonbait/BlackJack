using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Core
{
    public enum Result { Dealer, Player, Tie };

    public class Game
    {
        private Deck deck = new Deck();

        public Hand Dealer { get; } = new Hand();
        public Hand Player { get; } = new Hand();

        public void StartGame()
        {
            deck.ResetDeck();
            Dealer.AddCard(deck.Draw());
            Player.AddCard(deck.Draw());
            Player.AddCard(deck.Draw());

        }

        public void PlayerDraw()
        {
            Player.AddCard(deck.Draw());
        }

        public void HouseDraw()
        {
            Dealer.AddCard(deck.Draw());
        }

        public Result Winner()
        {
            if (Player.Bust)
            {
                return Result.Dealer;
            }
            else if (Dealer.Bust)
            {
                return Result.Player;
            }
            else if (Dealer.HasBlackjack() && Player.HasBlackjack())
            {
                return Result.Tie;
            }
            else if (Dealer.Value > Player.Value || Dealer.Value == Player.Value && !Player.HasBlackjack())
            {
                return Result.Dealer;
            }
            else
            {
                return Result.Player;
            }
        }
    }
}
