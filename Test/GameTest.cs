using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Simulation.Core;
namespace Test
{
    class GameTest
    {
        Game g;
        [SetUp]
        public void Setup()
        {
            g = new Game();
        }
        [Test]
        public void HandSizeInitial()
        {
            Assert.That(g.DealerHand.Size, Is.EqualTo(1));
            Assert.That(g.PlayerHand.Size, Is.EqualTo(2));
        }

        [Test]
        public void HandSizeStartGame()
        {
            g.NewHand();
            Assert.That(g.DealerHand.Size, Is.EqualTo(1));
            Assert.That(g.PlayerHand.Size, Is.EqualTo(2));
            Assert.That(g.DealerHand.Value, Is.LessThan(12));
            Assert.That(g.DealerHand.Value, Is.GreaterThan(1));
            Assert.That(g.PlayerHand.Value, Is.GreaterThan(3));
            Assert.That(g.PlayerHand.Value, Is.LessThanOrEqualTo(21));
        }


        [Test]
        public void DealerHigherValueHand()
        {
            g.ClearHands();
            Card c1 = new Card(CardSuit.Hearts, CardRank.Jack);
            Card c2 = new Card(CardSuit.Hearts, CardRank.Ace);
            g.DealerDraw(c1);
            g.DealerDraw(c2);
            Card c3 = new Card(CardSuit.Clubs, CardRank.Jack);
            Card c4 = new Card(CardSuit.Clubs, CardRank.Queen);
            g.PlayerDraw(c3);
            g.PlayerDraw(c4);
            Assert.That(g.Winner(), Is.EqualTo(Result.Dealer));
        }

        [Test]
        public void PlayerBusts()
        {
            g.ClearHands();
            Card c1 = new Card(CardSuit.Hearts, CardRank.Jack);
            Card c2 = new Card(CardSuit.Hearts, CardRank.Nine);
            g.DealerDraw(c1);
            g.DealerDraw(c2);
            Card c3 = new Card(CardSuit.Clubs, CardRank.Jack);
            Card c4 = new Card(CardSuit.Clubs, CardRank.Queen);
            Card c5 = new Card(CardSuit.Clubs, CardRank.Three);
            g.PlayerDraw(c3);
            g.PlayerDraw(c4);
            g.PlayerDraw(c5);
            Assert.That(g.Winner(), Is.EqualTo(Result.Dealer));
        }

        [Test]
        public void DealerBlackjackVsPlayer21()
        {
            g.ClearHands();
            Card c1 = new Card(CardSuit.Hearts, CardRank.Jack);
            Card c2 = new Card(CardSuit.Hearts, CardRank.Ace);
            g.DealerDraw(c1);
            g.DealerDraw(c2);
            Card c3 = new Card(CardSuit.Clubs, CardRank.Jack);
            Card c4 = new Card(CardSuit.Clubs, CardRank.Eight);
            Card c5 = new Card(CardSuit.Clubs, CardRank.Three);
            g.PlayerDraw(c3);
            g.PlayerDraw(c4);
            g.PlayerDraw(c5);
            Assert.That(g.Winner(), Is.EqualTo(Result.Dealer));
        }

        [Test]
        public void Tie()
        {
            g.ClearHands();
            Card c1 = new Card(CardSuit.Hearts, CardRank.Jack);
            Card c2 = new Card(CardSuit.Hearts, CardRank.Ace);
            g.DealerDraw(c1);
            g.DealerDraw(c2);
            Card c3 = new Card(CardSuit.Clubs, CardRank.Jack);
            Card c4 = new Card(CardSuit.Clubs, CardRank.Ace);
            g.PlayerDraw(c3);
            g.PlayerDraw(c4);
            Assert.That(g.Winner(), Is.EqualTo(Result.Tie));
        }

        [Test]
        public void PlayerHigherValueHand()
        {
            g.ClearHands();
            Card c1 = new Card(CardSuit.Hearts, CardRank.Jack);
            Card c2 = new Card(CardSuit.Hearts, CardRank.Eight);
            g.DealerDraw(c1);
            g.DealerDraw(c2);
            Card c3 = new Card(CardSuit.Clubs, CardRank.Jack);
            Card c4 = new Card(CardSuit.Clubs, CardRank.Ace);
            g.PlayerDraw(c3);
            g.PlayerDraw(c4);
            Assert.That(g.Winner(), Is.EqualTo(Result.Player));
        }

        [Test]
        public void PlayerBlackjackVSHouse21()
        {
            g.ClearHands();
            Card c1 = new Card(CardSuit.Hearts, CardRank.Jack);
            Card c2 = new Card(CardSuit.Hearts, CardRank.Eight);
            Card c3 = new Card(CardSuit.Hearts, CardRank.Three);
            g.DealerDraw(c1);
            g.DealerDraw(c2);
            g.DealerDraw(c3);
            Card c4 = new Card(CardSuit.Clubs, CardRank.Jack);
            Card c5 = new Card(CardSuit.Clubs, CardRank.Ace);
            g.PlayerDraw(c4);
            g.PlayerDraw(c5);
            Assert.That(g.Winner(), Is.EqualTo(Result.Player));
        }

        [Test]
        public void DealerBusts()
        {
            g.ClearHands();
            Card c1 = new Card(CardSuit.Hearts, CardRank.Jack);
            Card c2 = new Card(CardSuit.Hearts, CardRank.Four);
            Card c3 = new Card(CardSuit.Hearts, CardRank.Eight);
            g.DealerDraw(c1);
            g.DealerDraw(c2);
            g.DealerDraw(c3);
            Card c4 = new Card(CardSuit.Clubs, CardRank.Jack);
            Card c5 = new Card(CardSuit.Clubs, CardRank.Five);
            g.PlayerDraw(c4);
            g.PlayerDraw(c5);
            Assert.That(g.Winner(), Is.EqualTo(Result.Player));
        }
    }
}
