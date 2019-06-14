using System;
using System.Collections.Generic;
using System.Text;

namespace Simulation.Core
{

    public class Deck : IState
    {
        private static readonly List<int> deckValues = new List<int>(new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 11 });
        public List<int> Cards { get; private set; }

        private int stateDeckSize;

        public int CardsLeft { get; private set; }

        private Random rnd;

        public Deck(Random rnd, int numDecks = 1)
        {
            this.rnd = rnd;
            CardsLeft = deckValues.Count * numDecks * 4;
            Cards = new List<int>(CardsLeft);
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
            this.CardsLeft = deck.CardsLeft;
            this.Cards = deck.Cards;
        }

        public void ResetDeck()
        {
            if (CardsLeft < 20)
            {
                CardsLeft = Cards.Count;
            }
        }

        public int Draw()
        {
            int i1 = rnd.Next(CardsLeft);
            int val = Cards[i1];
            Cards[i1] = Cards[CardsLeft - 1];
            Cards[CardsLeft - 1] = val;
            CardsLeft--;
            return val;
        }

        public void SetState()
        {
            stateDeckSize = CardsLeft;
        }

        public void RestoreState()
        {
            CardsLeft = stateDeckSize;
        }
    }
}
