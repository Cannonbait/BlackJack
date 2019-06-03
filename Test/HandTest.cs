
using NUnit.Framework;
using Model.Core;

namespace Test
{
    class HandTest
    {
        [Test]
        public void Size()
        {
            Card c1 = new Card(CardSuit.Clubs, CardRank.Queen);
            Card c2 = new Card(CardSuit.Hearts, CardRank.Seven);
            Hand h = new Hand();
            h.AddCard(c1);
            h.AddCard(c2);
            Assert.That(h.Size, Is.EqualTo(2));
            Card c3 = new Card(CardSuit.Hearts, CardRank.Five);
            h.AddCard(c3);
            Assert.That(h.Size, Is.EqualTo(3));
        }

        [Test]
        public void Summation()
        {
            Card c1 = new Card(CardSuit.Clubs, CardRank.Queen);
            Card c2 = new Card(CardSuit.Hearts, CardRank.Seven);
            Hand h = new Hand();
            h.AddCard(c1);
            h.AddCard(c2);
            Assert.That(h.Value, Is.EqualTo(17));

            c1 = new Card(CardSuit.Clubs, CardRank.Ace);
            c2 = new Card(CardSuit.Hearts, CardRank.Seven);
            h = new Hand();
            h.AddCard(c1);
            h.AddCard(c2);
            Assert.That(h.Value, Is.EqualTo(18));
        }

        [Test]
        public void SummationSoft()
        {
            Card c1 = new Card(CardSuit.Clubs, CardRank.Ace);
            Card c2 = new Card(CardSuit.Hearts, CardRank.Ace);
            Hand h = new Hand();
            h.AddCard(c1);
            h.AddCard(c2);
            Assert.That(h.Value, Is.EqualTo(12));
            Card c3 = new Card(CardSuit.Diamonds, CardRank.Jack);
            h.AddCard(c3);
            Assert.That(h.Value, Is.EqualTo(12));
        }

        [Test]
        public void Bust()
        {
            Card c1 = new Card(CardSuit.Clubs, CardRank.Three);
            Card c2 = new Card(CardSuit.Hearts, CardRank.Queen);
            Card c3 = new Card(CardSuit.Diamonds, CardRank.Jack);
            Hand h = new Hand();
            h.AddCard(c1);
            h.AddCard(c2);
            Assert.That(!h.Bust);
            h.AddCard(c3);
            Assert.That(h.Bust);

        }
    }
}
