using System;
using System.Collections.Generic;
using System.Text;

namespace Simulation.Core
{
    public enum Result { Dealer, Player, Tie, None };

    public class Game : IBlackjack, IState
    {
        public Deck Deck { get; private set; }

        public bool HandOver { get; private set; } = true;



        public Hand Dealer { get; private set; } = new Hand();
        public Hand Player { get; private set; } = new Hand();

        public int Money { get; private set; } = 0;

        public int BetSize { get; private set; } = 1;

        public Random Rng { get; private set; }

        private bool stateHandOver;


        public Game(Random rng)
        {
            this.Rng = rng;
            Deck = new Deck(Rng);
        }

        public Game(Game game)
        {
            Dealer = new Hand(game.Dealer);
            Player = new Hand(game.Player);
            Deck = new Deck(game.Deck);
            HandOver = game.HandOver;
            this.Rng = game.Rng;
        }

        public void NewHand()
        {
            HandOver = false;
            Money -= BetSize;
            Dealer.Clear();
            Player.Clear();
            Deck.ResetDeck();
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


        public void DealerDraw()
        {
            Dealer.AddCard(Deck.Draw());
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
            else if (Dealer.Value == Player.Value && Dealer.HasBlackjack() == Player.HasBlackjack())
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
            Player.UpdateValue();
            if (Player.Value > 21)
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
            BetSize *= 2;
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

        public void SetState()
        {
            Player.SetState();
            Dealer.SetState();
            Deck.SetState();
            stateHandOver = HandOver;
        }

        public void RestoreState()
        {
            Player.RestoreState();
            Dealer.RestoreState();
            Deck.RestoreState();
            HandOver = stateHandOver;

        }
    }
}
