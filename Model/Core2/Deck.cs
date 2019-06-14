using System;
using System.Collections.Generic;
using System.Text;

namespace Simulation.Core2
{

    public class Deck : IState
    {
        private static readonly List<int> deckValues = new List<int>(new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 11 });
        public List<int> Cards { get; private set; }

        private int stateDeckSize;



        private int deckSize;

        private Random rnd;

        public Deck(Random rnd, int numDecks = 1)
        {
            this.rnd = rnd;
            deckSize = deckValues.Count * numDecks * 4;
            Cards = new List<int>(deckSize);
            for (int i = 0; i < numDecks * 4; i++)
            {
                foreach (int value in deckValues)
                {
                    Cards.Add(value);
                }
            }
        }

        public Deck(Deck deck)
        {
            this.rnd = deck.rnd;
            this.deckSize = deck.deckSize;
            this.Cards = deck.Cards;
        }

        public void ResetDeck()
        {
            if (deckSize < 20)
            {
                deckSize = Cards.Count;
            }
        }

        public int Draw()
        {
            int i1 = rnd.Next(deckSize);
            int val = Cards[i1];
            Cards[i1] = Cards[deckSize - 1];
            Cards[deckSize - 1] = val;
            deckSize--;
            return val;
        }

        public void SetState()
        {
            stateDeckSize = deckSize;
        }

        public void RestoreState()
        {
            deckSize = stateDeckSize;
        }
    }
}
