using System;
using System.Collections.Generic;
using System.Text;

namespace Simulation.Core
{


    public class Deck : ICloneable
    {
        List<Card> cards = new List<Card>();
        static List<Card> completeDeck = new List<Card>();
        private readonly Random rng;

        public Deck(Random rng)
        {
            this.rng = rng;
            GenerateCompleteDeck();
            ResetDeck();
        }

        public Deck(List<Card> cards, Random rng)
        {
            GenerateCompleteDeck();
            this.cards = cards;
            this.rng = rng;
        }

        private void GenerateCompleteDeck()
        {
            if (completeDeck.Count == 0)
            {
                completeDeck.Clear();
                foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
                {
                    foreach (CardRank rank in Enum.GetValues(typeof(CardRank)))
                    {
                        completeDeck.Add(new Card(suit, rank));
                    }
                }
            }
        }

        public int Size => cards.Count;

        public void ResetDeck()
        {
            cards.Clear();
            cards = new List<Card>(completeDeck);
        }

        public Card Draw()
        {
            if (Size == 0)
            {
                ResetDeck();
            }
            int i = rng.Next(cards.Count);
            Card c = cards[i];
            cards.RemoveAt(i);
            return c;
        }

        public object Clone()
        {
            return new Deck(new List<Card>(cards), rng);
        }

        public void Remove(Card c)
        {
            cards.Remove(c);
        }
    }
}
