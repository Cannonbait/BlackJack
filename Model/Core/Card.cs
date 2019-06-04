using System;
using System.Collections.Generic;
using System.Text;

namespace Simulation.Core
{
    public enum CardSuit { Hearts, Jacks, Diamonds, Clubs };
    public enum CardRank { Two = 2, Three = 3, Four = 4, Five = 5, Six = 6, Seven = 7, Eight = 8, Nine = 9, Ten = 10, Jack = 11, Queen = 12, King = 13, Ace = 14}
    public class Card
    {
        public CardSuit Suit { get; }
        public CardRank Rank { get; }

        public Card (CardSuit suit, CardRank rank)
        {
            this.Suit = suit;
            this.Rank = rank;
        }

        public override int GetHashCode()
        {
            return (int)Suit * 3 + (int)Rank * 5;
        }

        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Card c = (Card)obj;
                return (Suit == c.Suit) && (Rank == c.Rank);
            }
        }
    }
}
