using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simulation.Core
{
    public enum Result { Dealer, Player, Tie, None };

    public class Game : IBlackjack, IState
    {
        public Deck Deck { get; private set; }

        public Hand Dealer { get; private set; } = new Hand();
        public List<Hand> Hands { get; private set; } = new List<Hand>();

        public int Money { get; private set; } = 0;

        public Random Rng { get; private set; }

        public int CurrentHand { get; private set; }

        public bool HandOver => Hands[CurrentHand].HandOver;

        public bool HandsOver => CurrentHand == Hands.Count;

        public Hand ActiveHand => Hands[CurrentHand];



        public Game(Random rng)
        {
            this.Rng = rng;
            Deck = new Deck(Rng);
            Hands.Add(new Hand());
        }

        public Game(Game game)
        {
            Dealer = new Hand(game.Dealer);

            foreach (Hand hand in game.Hands)
            {
                Hands.Add(new Hand(hand));
            }
            Deck = new Deck(game.Deck);
            this.Rng = game.Rng;
        }

        public void NewHand(int bet)
        {
            Dealer.Clear();
            CurrentHand = 0;
            if (Hands.Count > 1)
            {
                Hands.RemoveRange(1, Hands.Count - 1);
            }
            foreach (Hand hand in Hands)
            {
                hand.Clear();
                hand.BetSize = bet;
                Money -= hand.BetSize;
            }
            Deck.ResetDeck();
            Dealer.AddCard(Deck.Draw());
            foreach (Hand hand in Hands)
            {
                hand.AddCard(Deck.Draw());
                hand.AddCard(Deck.Draw());
            }
        }


        public void PlayerDraw()
        {
            Hands[CurrentHand].AddCard(Deck.Draw());
        }


        public void DealerDraw()
        {
            Dealer.AddCard(Deck.Draw());
        }



        public void ClearHands()
        {
            Hands.ForEach(x => x.Clear());
            Dealer.Clear();
        }


        public Result Winner()
        {
            return Winner(Hands[CurrentHand]);
        }

        private Result Winner(Hand hand)
        {
            if (hand.Bust)
            {
                return Result.Dealer;
            }
            else if (hand.Bust)
            {
                return Result.Player;
            }
            else if (Dealer.Value == hand.Value && Dealer.HasBlackjack() == hand.HasBlackjack())
            {
                return Result.Tie;
            }
            else if (Dealer.Value > hand.Value || Dealer.Value == hand.Value && !hand.HasBlackjack())
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
            Hands[CurrentHand].UpdateValue();
            if (Hands[CurrentHand].HandOver)
            {
                CurrentHand++;
            }
        }

        public void Stand()
        {
            if (CurrentHand < Hands.Count)
            {
                CurrentHand++;
                return;
            }
        }

        public void DoubleDown()
        {
            Money -= Hands[CurrentHand].BetSize;
            Hands[CurrentHand].BetSize *= 2;
            Hit();
            Stand();
        }

        public void FinishHand()
        {
            while (Dealer.Value < 17)
            {
                DealerDraw();
            }
            foreach (Hand hand in Hands)
            {
                Result result = Winner(hand);
                if (result == Result.Player && hand.HasBlackjack())
                {
                    Money += (hand.BetSize * 3);
                }
                if (result == Result.Player)
                {
                    Money += (hand.BetSize * 2);
                }
                else if (result == Result.Tie)
                {
                    Money += hand.BetSize;
                }
            }
        }

        public void SetState()
        {
            foreach (Hand hand in Hands)
            {
                hand.SetState();
            }
            Dealer.SetState();
            Deck.SetState();
        }

        public void RestoreState()
        {
            foreach (Hand hand in Hands)
            {
                hand.RestoreState();
            }
            Dealer.RestoreState();
            Deck.RestoreState();

        }

        public void Split()
        {
            throw new NotImplementedException();
        }

        public void Surrender()
        {
            throw new NotImplementedException();
        }

        public void Insurance()
        {
            throw new NotImplementedException();
        }

        public bool CanSplit()
        {
            throw new NotImplementedException();
        }

        public bool CanSurrender()
        {
            throw new NotImplementedException();
        }

        public bool CanInsure()
        {
            throw new NotImplementedException();
        }
    }
}
