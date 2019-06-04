using System;
using System.Collections.Generic;
using System.Text;

namespace Simulation.Core
{
    public enum Result { Dealer, Player, Tie };

    public class Game : Blackjack
    {
        private Deck deck = new Deck();

        private int playerWinCount = 0;
        private int dealerWinCount = 0;

        private int gamesPlayed = 0;


        public Hand Dealer { get; } = new Hand();
        public Hand Player { get; } = new Hand();

        public int GamesPlayed => gamesPlayed;

        public int PlayerWins => playerWinCount;

        public int DealerWins => dealerWinCount;

        public Hand PlayerHand => Player;
        public Hand DealerHand => Dealer;

        public Deck Deck => deck;

        public Game()
        {
            NewGame();
        }

        public void NewGame()
        {
            if (deck.Size < 10)
            {
                deck.ResetDeck();
            }
            Dealer.Clear();
            Player.Clear();
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

        public void Hit()
        {
            Player.AddCard(deck.Draw());
            if (Player.Bust)
            {
                dealerWinCount++;
                gamesPlayed++;
                NewGame();
            }
        }

        public void Stand()
        {
            while (Dealer.Value < 17)
            {
                Dealer.AddCard(deck.Draw());
            }
            Result winner = Winner();
            if (winner == Result.Dealer)
            {
                dealerWinCount++;
            }
            else if (winner == Result.Player)
            {
                playerWinCount++;
            }
            gamesPlayed++;
            NewGame();
        }

    }
}
