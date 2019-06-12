﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Simulation.Core
{
    public enum Result { Dealer, Player, Tie, None };

    public class Game : IBlackjack, ICloneable
    {
        public Deck Deck { get; private set; }

        public bool HandOver { get; private set; } = true;



        private Hand Dealer { get; } = new Hand();
        private Hand Player { get; } = new Hand();

        public int Money { get; private set; } = 0;

        public int BetSize { get; private set; } = 1;

        public Random Rng { get; private set; }


        public Hand PlayerHand => Player;

        public Hand DealerHand => Dealer;


        public Game(Random rng)
        {
            this.Rng = rng;
            Deck = new Deck(Rng);
        }

        public Game(Game game)
        {
            Dealer = (Hand)game.DealerHand.Clone();
            Player = (Hand)game.PlayerHand.Clone();
            Deck = (Deck)game.Deck.Clone();
            HandOver = game.HandOver;
            this.Rng = game.Rng;
        }

        public void NewHand()
        {
            HandOver = false;
            Money -= BetSize;
            Dealer.Clear();
            Player.Clear();
            Dealer.AddCard(Deck.Draw());
            Player.AddCard(Deck.Draw());
            Player.AddCard(Deck.Draw());
        }

        public void SetBet(int betSize)
        {
            if (HandOver == true)
            {
                BetSize = betSize;
            }
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
            else if (Dealer.HasBlackjack() && Player.HasBlackjack() || Dealer.Value == Player.Value && !Dealer.HasBlackjack() && !Player.HasBlackjack())
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

        public void DoubleDown()
        {
            Money -= BetSize;
            BetSize = BetSize * 2;
            Hit();
            Stand();
        }

        public void FinishHand()
        {
            Result result = Winner();
            if (result == Result.Player)
            {
                Money += (BetSize * 2);
            }
            else if (result == Result.Tie)
            {
                Money += BetSize;
            }
            HandOver = true;
        }

        public Object Clone()
        {
            return new Game(this);
        }
    }
}
