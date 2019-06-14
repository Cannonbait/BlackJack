using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simulation.Core2
{

    public class Hand : IState
    {
        private List<int> cards = new List<int>();

        private List<int> stateCards;

        public int Value { get; private set; }
        public Hand() { }

        public Hand(Hand hand)
        {
            cards = hand.cards;
            Value = hand.Value;
        }

        public void UpdateValue()
        {
            int newValue = cards.Sum();
            int aces = cards.Select(x => x == 11).Count();
            while (newValue > 21 && aces > 0)
            {
                newValue -= 10;
                aces--;
            }
            Value = newValue;
        }

        public void AddCard(int c)
        {
            cards.Add(c);
            UpdateValue();
        }

        public int Size => cards.Count;

        public bool Bust => Value > 21;

        public void Clear()
        {
            cards.Clear();
        }


        public bool HasBlackjack()
        {
            return Size == 2 && Value == 21;
        }


        public override string ToString()
        {
            string str = "";
            foreach (int c in cards)
            {
                str += c + " ";
            }
            return str;
        }

        public void SetState()
        {
            stateCards = cards;
        }

        public void RestoreState()
        {
            cards = stateCards;
            UpdateValue();
        }
    }
}
