using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Test
{
    class HandTest
    {
        [Test]
        public void Size()
        {
            Card c1 = new Card(CardSuit.Club, CardValue.Queen);
            Card c2 = new Card(CardSuit.Heart, CardValue.Seven);
            Hand h = new Hand();
            h.AddCard(c1);
            h.AddCard(c2);
            Assert.That(h.Size, Is.EqualTo(2));
            Card c3 = new Card(CardSuit.Heart, CardValue.Five);
            Assert.That(h.Size, Is.EqualTo(3));
        }

        [Test]
        public void Summation()
        {
            Card c1 = new Card(CardSuit.Club, CardValue.Queen);
            Card c2 = new Card(CardSuit.Heart, CardValue.Seven);
            Hand h = new Hand();
            h.AddCard(c1);
            h.AddCard(c2);
            Assert.That(h.Value, Is.EqualTo(17));

            c1 = new Card(CardSuit.Club, CardValue.Ace);
            c2 = new Card(CardSuit.Heart, CardValue.Seven);
            h = new Hand();
            h.AddCard(c1);
            h.AddCard(c2);
            Assert.That(h.Value, Is.EqualTo(18));
        }

        [Test]
        public void SummationSoft()
        {
            Card c1 = new Card(CardSuit.Club, CardValue.Ace);
            Card c2 = new Card(CardSuit.Heart, CardValue.Ace);
            Hand h = new Hand();
            h.AddCard(c1);
            h.AddCard(c2);
            Assert.That(h.Value, Is.EqualTo(12));
            Card c3 = new Card(CardSuit.Diamond, CardValue.Jack);
            h.AddCard(c3);
            Assert.That(h.Value, Is.EqualTo(12));
        }

        [Test]
        public void Bust()
        {
            Card c1 = new Card(CardSuit.Club, CardValue.Three);
            Card c2 = new Card(CardSuit.Heart, CardValue.Queen);
            Card c3 = new Card(CardSuit.Diamond, CardValue.Jack);
            Hand h = new Hand();
            h.AddCard(c1);
            h.AddCard(c2);
            Assert.That(!h.Bust);
            h.AddCard(c3);
            Assert.That(h.Bust);

        }
    }
}
