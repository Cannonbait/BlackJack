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

        public int Value => HandValue(cards);

        public int HandValue(HashSet<Card> cards)
        {
            int value = 0;
            int aces = 0;
            foreach (Card card in cards)
            {
                if (card.Rank == CardRank.Ace)
                {
                    value += 11;
                    aces++;
                }
                else if (card.Rank == CardRank.Jack || card.Rank == CardRank.Queen || card.Rank == CardRank.King)
                {
                    value += 10;
                }
                else
                {
                    value += (int)card.Rank;
                }
            }
            while (value > 21 && aces > 0)
            {
                value -= 10;
                aces--;
            }
            return value;
        }

        public bool HasBlackjack()
        {
            return Size == 2 && Value == 21;
        }
    }
}
