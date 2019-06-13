using System;
using System.Collections.Generic;
using System.Text;

namespace Simulation.Core2
{

    class Deck
    {
        private static readonly List<int> deckValues = new List<int>(new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 11 });
        public List<int> cards { get; private set; }

        private int deckSize;

        private Random rnd;

        public Deck(Random rnd, int numDecks = 1)
        {
            this.rnd = rnd;
            deckSize = deckValues.Count * numDecks * 4;
            cards = new List<int>(deckSize);
            for (int i = 0; i < numDecks * 4; i++)
            {
                foreach (int value in deckValues)
                {
                    cards.Add(value);
                }
            }
        }

        public Deck(Deck deck)
        {
            this.rnd = deck.rnd;
            this.deckSize = deck.deckSize;
            this.cards = deck.cards;
        }

        public void ResetDeck()
        {
            if (deckSize < 5)
            {
                deckSize = cards.Count;
            }
        }

        public int Draw()
        {
            int i1 = rnd.Next(deckSize);
            int val = cards[i1];
            cards[i1] = cards[deckSize - 1];
            cards[deckSize - 1] = val;
            deckSize--;
            return val;
        }


    }
}
