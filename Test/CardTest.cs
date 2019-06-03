using NUnit.Framework;
using Model.Core;

namespace Tests
{
    public class CardTest
    {
        [Test]
        public void Basic()
        {
            Card c = new Card(CardSuit.Clubs, CardRank.Ace);
            Assert.That(c.Suit, Is.EqualTo(CardSuit.Clubs));
            Assert.That(c.Rank, Is.EqualTo(CardRank.Ace));
        }

        [Test]
        public void Equality()
        {
            Card c1 = new Card(CardSuit.Clubs, CardRank.Ace);
            Card c2 = new Card(CardSuit.Clubs, CardRank.Ace);
            Assert.That(c1.Equals(c2));
        }
    }
}