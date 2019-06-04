using System;
using System.Collections.Generic;
using System.Text;

namespace Simulation.Core
{

    public class Hand
    {
        private HashSet<Card> cards = new HashSet<Card>();
        public void AddCard(Card c)
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
                int value = 0;
                int aces = 0;
                foreach (Card card in cards)
                {
                    if (card.Rank == CardRank.Ace)
                    {
                        aces++;
                    }
                    value += card.Value;
                }
                while (value > 21 && aces > 0)
                {
                    value -= 10;
                    aces--;
                }
                return value;
            }
        }


        public bool AddCardBust(Card card)
        {
            cards.Add(card);
            bool bust = Bust;
            cards.Remove(card);
            return bust;

        }

        public bool HasBlackjack()
        {
            return Size == 2 && Value == 21;
        }

        public HashSet<Card> Cards => cards;
    }
}
