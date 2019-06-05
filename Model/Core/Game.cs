using System;
using System.Collections.Generic;
using System.Text;

namespace Simulation.Core
{
    public enum Result { Dealer, Player, Tie, None };

    public class Game : IBlackjack, ICloneable
    {
        private Deck deck = new Deck();

        public bool HandOver { get; private set; } = false;



        private Hand Dealer { get; } = new Hand();
        private Hand Player { get; } = new Hand();


        public Hand PlayerHand => (Hand)Player.Clone();
        public Hand DealerHand => (Hand)Dealer.Clone();

        public Deck Deck => (Deck)deck.Clone();

        public Game()
        {
            NewHand();
        }

        public Game(Game game)
        {
            Dealer = game.DealerHand;
            Player = game.PlayerHand;
            deck = game.Deck;
            HandOver = game.HandOver;
        }

        public void NewHand()
        {
            Dealer.Clear();
            Player.Clear();
            Dealer.AddCard(deck.Draw());
            Player.AddCard(deck.Draw());
            Player.AddCard(deck.Draw());
            HandOver = false;
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

        public void Hit()
        {
            PlayerDraw();
            if (PlayerHand.Value > 21)
            {
                HandOver = true;
            }
        }

        public void Stand()
        {
            while (Dealer.Value < 17)
            {
                DealerDraw();
            }
            HandOver = true;

        }

        public Object Clone()
        {
            return new Game(this);
        }
    }
}
