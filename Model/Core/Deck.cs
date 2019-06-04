using System;
using System.Collections.Generic;
using System.Text;

namespace Simulation.Core
{


    public class Deck
    {
        List<Card> cards = new List<Card>();
        private Random rnd = new Random();

        public Deck()
        {
            ResetDeck();
        }

        public int Size => cards.Count;

        public void ResetDeck()
        {
            cards.Clear();
            foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
            {
                foreach (CardRank rank in Enum.GetValues(typeof(CardRank)))
                {
                    cards.Add(new Card(suit, rank));
                }
            }
        }

        public Card Draw()
        {
            int i = rnd.Next(cards.Count);
            Card c = cards[i];
            cards.RemoveAt(i);
            return c;
        }
    }
}
