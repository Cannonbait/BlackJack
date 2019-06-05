using System;
using System.Collections.Generic;
using System.Text;

namespace Simulation.Core
{
    public enum Result { Dealer, Player, Tie, None };

    public class Game : IBlackjack, ICloneable
    {
        private Deck deck = new Deck();



        private Hand Dealer { get; } = new Hand();
        private Hand Player { get; } = new Hand();


        public Hand PlayerHand => (Hand)Player.Clone();
        public Hand DealerHand => (Hand)Dealer.Clone();

        public Deck Deck => deck;

        public Game()
        {
            NewGame();
        }

        public Game(Hand dealer, Hand player, Deck deck)
        {
            Dealer = dealer;
            Player = player;
            this.deck = deck;
        }

        public void NewGame()
        {
            Dealer.Clear();
            Player.Clear();
            Dealer.AddCard(deck.Draw());
            Player.AddCard(deck.Draw());
            Player.AddCard(deck.Draw());
        }

        public void PlayerDraw()
        {
            Player.AddCard(Deck.Draw());
        }

        public void PlayerDraw(Card c)
        {
            Deck.Remove(c);
            Player.AddCard(c);
        }

        public void DealerDraw()
        {
            Dealer.AddCard(Deck.Draw());
        }


        public void DealerDraw(Card c)
        {
            Deck.Remove(c);
            Dealer.AddCard(c);
        }

        public void ClearHands()
        {
            Player.Clear();
            Dealer.Clear();
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

        public Result Hit()
        {
            PlayerDraw();
            if (Player.Bust)
            {
                NewGame();
                return Result.Dealer;
            }
            else if (Player.Value == 21)
            {
                NewGame();
                return Result.Player;
            }
            return Result.None;

        }

        public Result Stand()
        {
            while (Dealer.Value < 17)
            {
                DealerDraw();
            }
            Result winner = Winner();
            NewGame();
            return winner;
        }

        public object Clone()
        {
            return new Game((Hand)Dealer.Clone(), (Hand)Player.Clone(), (Deck)deck.Clone());
        }
    }
}
