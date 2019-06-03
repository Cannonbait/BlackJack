using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Model.Core;

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
            Assert.That(g.Dealer.Size, Is.EqualTo(0));
            Assert.That(g.Player.Size, Is.EqualTo(0));
        }

        [Test]
        public void HandSizeStartGame()
        {
            g.StartGame();
            Assert.That(g.Dealer.Size, Is.EqualTo(1));
            Assert.That(g.Player.Size, Is.EqualTo(2));
            Assert.That(g.Dealer.Value, Is.LessThan(12));
            Assert.That(g.Dealer.Value, Is.GreaterThan(1));
            Assert.That(g.Player.Value, Is.GreaterThan(3));
            Assert.That(g.Player.Value, Is.LessThanOrEqualTo(21));
        }

        [Test]
        public void DrawCard()
        {
            g.StartGame();
            g.HouseDraw();
            Assert.That(g.Dealer.Size, Is.EqualTo(2));
            g.HouseDraw();
            Assert.That(g.Dealer.Size, Is.EqualTo(3));
            g.PlayerDraw();
            Assert.That(g.Player.Size, Is.EqualTo(3));
            g.PlayerDraw();
            Assert.That(g.Player.Size, Is.EqualTo(4));
        }

        [Test]
        public void DealerHigherValueHand()
        {
            Card c1 = new Card(CardSuit.Hearts, CardRank.Jack);
            Card c2 = new Card(CardSuit.Hearts, CardRank.Ace);
            g.Dealer.AddCard(c1);
            g.Dealer.AddCard(c2);
            Card c3 = new Card(CardSuit.Clubs, CardRank.Jack);
            Card c4 = new Card(CardSuit.Clubs, CardRank.Queen);
            g.Player.AddCard(c3);
            g.Player.AddCard(c4);
            Assert.That(g.Winner(), Is.EqualTo(Result.Dealer));
        }

        [Test]
        public void PlayerBusts()
        {
            Card c1 = new Card(CardSuit.Hearts, CardRank.Jack);
            Card c2 = new Card(CardSuit.Hearts, CardRank.Nine);
            g.Dealer.AddCard(c1);
            g.Dealer.AddCard(c2);
            Card c3 = new Card(CardSuit.Clubs, CardRank.Jack);
            Card c4 = new Card(CardSuit.Clubs, CardRank.Queen);
            Card c5 = new Card(CardSuit.Clubs, CardRank.Three);
            g.Player.AddCard(c3);
            g.Player.AddCard(c4);
            g.Player.AddCard(c5);
            Assert.That(g.Winner(), Is.EqualTo(Result.Dealer));
        }

        [Test]
        public void DealerBlackjackVsPlayer21()
        {
            Card c1 = new Card(CardSuit.Hearts, CardRank.Jack);
            Card c2 = new Card(CardSuit.Hearts, CardRank.Ace);
            g.Dealer.AddCard(c1);
            g.Dealer.AddCard(c2);
            Card c3 = new Card(CardSuit.Clubs, CardRank.Jack);
            Card c4 = new Card(CardSuit.Clubs, CardRank.Eight);
            Card c5 = new Card(CardSuit.Clubs, CardRank.Three);
            g.Player.AddCard(c3);
            g.Player.AddCard(c4);
            g.Player.AddCard(c5);
            Assert.That(g.Winner(), Is.EqualTo(Result.Dealer));
        }

        [Test]
        public void Tie()
        {
            Card c1 = new Card(CardSuit.Hearts, CardRank.Jack);
            Card c2 = new Card(CardSuit.Hearts, CardRank.Ace);
            g.Dealer.AddCard(c1);
            g.Dealer.AddCard(c2);
            Card c3 = new Card(CardSuit.Clubs, CardRank.Jack);
            Card c4 = new Card(CardSuit.Clubs, CardRank.Ace);
            g.Player.AddCard(c3);
            g.Player.AddCard(c4);
            Assert.That(g.Winner(), Is.EqualTo(Result.Tie));
        }

        [Test]
        public void PlayerHigherValueHand()
        {
            Card c1 = new Card(CardSuit.Hearts, CardRank.Jack);
            Card c2 = new Card(CardSuit.Hearts, CardRank.Eight);
            g.Dealer.AddCard(c1);
            g.Dealer.AddCard(c2);
            Card c3 = new Card(CardSuit.Clubs, CardRank.Jack);
            Card c4 = new Card(CardSuit.Clubs, CardRank.Ace);
            g.Player.AddCard(c3);
            g.Player.AddCard(c4);
            Assert.That(g.Winner(), Is.EqualTo(Result.Player));
        }

        [Test]
        public void PlayerBlackjackVSHouse21()
        {
            Card c1 = new Card(CardSuit.Hearts, CardRank.Jack);
            Card c2 = new Card(CardSuit.Hearts, CardRank.Eight);
            Card c3 = new Card(CardSuit.Hearts, CardRank.Three);
            g.Dealer.AddCard(c1);
            g.Dealer.AddCard(c2);
            g.Dealer.AddCard(c3);
            Card c4 = new Card(CardSuit.Clubs, CardRank.Jack);
            Card c5 = new Card(CardSuit.Clubs, CardRank.Ace);
            g.Player.AddCard(c4);
            g.Player.AddCard(c5);
            Assert.That(g.Winner(), Is.EqualTo(Result.Player));
        }

        [Test]
        public void DealerBusts()
        {
            Card c1 = new Card(CardSuit.Hearts, CardRank.Jack);
            Card c2 = new Card(CardSuit.Hearts, CardRank.Four);
            Card c3 = new Card(CardSuit.Hearts, CardRank.Eight);
            g.Dealer.AddCard(c1);
            g.Dealer.AddCard(c2);
            g.Dealer.AddCard(c3);
            Card c4 = new Card(CardSuit.Clubs, CardRank.Jack);
            Card c5 = new Card(CardSuit.Clubs, CardRank.Five);
            g.Player.AddCard(c4);
            g.Player.AddCard(c5);
            Assert.That(g.Winner(), Is.EqualTo(Result.Player));
        }
    }
}
