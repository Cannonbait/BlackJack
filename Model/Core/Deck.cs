using System;
using System.Collections.Generic;
using System.Text;

namespace Simulation.Core
{


    public class Deck : ICloneable
    {
        public List<Card> Cards { get; private set; } = new List<Card>();
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
            this.Cards = cards;
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

        public int Size => Cards.Count;

        public void ResetDeck()
        {
            Cards.Clear();
            Cards = new List<Card>(completeDeck);
        }

        public Card Draw()
        {
            if (Size == 0)
            {
                ResetDeck();
            }
            int i = rng.Next(Cards.Count);
            Card c = Cards[i];
            Cards.RemoveAt(i);
            return c;
        }

        public object Clone()
        {
            return new Deck(new List<Card>(Cards), rng);
        }

        public void Remove(Card c)
        {
            Cards.Remove(c);
        }
    }
}
