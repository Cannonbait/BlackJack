using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simulation.Core2
{

    public class Hand
    {
        private List<int> cards = new List<int>();
        public Hand()
        {

        }

        public Hand(List<int> cards)
        {
            this.cards = cards;
        }

        public void AddCard(int c)
        {
            cards.Add(c);
        }

        public int Size => cards.Count;

        public bool Bust => Value > 21;

        public void Clear()
        {
            cards.Clear();
        }

        public int Value
        {
            get
            {

                int value = cards.Sum();
                int aces = cards.Select(x => x == 11).Count();
                while (value > 21 && aces > 0)
                {
                    value -= 10;
                    aces--;
                }
                return value;
            }
        }


        public bool HasBlackjack()
        {
            return Size == 2 && Value == 21;
        }

        public Hand Clone()
        {
            return new Hand(new List<int>(cards));
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
    }
}
