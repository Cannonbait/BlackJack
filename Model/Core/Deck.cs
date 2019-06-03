using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Core
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
            Shuffle();
        }

        public void Shuffle()
        {
            for (int i1 = 0; i1 < cards.Count-1; i1++)
            {
                int i2 = rnd.Next(i1, cards.Count);
                Card tmp = cards[i2];
                cards[i2] = cards[i1];
                cards[i1] = tmp;
            }
        }

        public Card Draw()
        {
            Card c = cards[0];
            cards.RemoveAt(0);
            return c;
        }
    }
}
