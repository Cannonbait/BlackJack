using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simulation.Core
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
            int aces = cards.Count(x => x == 11);
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
            Value = 0;
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
            stateCards = new List<int>(cards);
        }

        public void RestoreState()
        {
            cards = new List<int>(stateCards);
            UpdateValue();
        }
    }
}
