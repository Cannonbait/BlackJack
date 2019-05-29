using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

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
            Assert.That(g.House.Hand.Size, Is.EqualTo(0));
            Assert.That(g.Player.Hand.Size, Is.EqualTo(0));
        }

        [Test]
        public void HandSizeStartGame()
        {
            g.StartGame();
            Assert.That(g.House.Hand.Size, Is.EqualTo(1));
            Assert.That(g.Player.Hand.Size, Is.EqualTo(2));
            Assert.That(g.House.Hand.Value, Is.LessThan(12));
            Assert.That(g.House.Hand.Value, Is.GreaterThan(1));
            Assert.That(g.Player.Hand.Value, Is.GreaterThan(3));
            Assert.That(g.Player.Hand.Value, Is.LessThanOrEqualTo(21));
        }

        [Test]
        public void Draw()
        {
            g.StartGame();
            g.House.Draw();
            Assert.That(g.House.Hand.Size, Is.EqualTo(2));
            g.House.Draw();
            Assert.That(g.House.Hand.Size, Is.EqualTo(3));
            g.Player.Draw();
            Assert.That(g.Player.Hand.Size, Is.EqualTo(3));
            g.Player.Draw();
            Assert.That(g.Player.Hand.Size, Is.EqualTo(4));
        }

        [Test]
        public void DealerWins()
        {
            Card c1 = new Card(CardSuit.Hearts, CardValue.Jack);
            Card c2 = new Card(CardSuit.Hearts, CardValue.Ace);
            g.House.Hand.AddCard(c1);
            g.House.Hand.AddCard(c2);
            Card c3 = new Card(CardSuit.Clubs, CardValue.Jack);
            Card c4 = new Card(CardSuit.Clubs, CardValue.Queen);
            g.Player.Hand.AddCard(c3);
            g.Player.Hand.AddCard(c4);
            Assert.That(g.Winner(), Is.EqualTo(Winner.Dealer));
        }

        [Test]
        public void DealerWins2()
        {
            Card c1 = new Card(CardSuit.Hearts, CardValue.Jack);
            Card c2 = new Card(CardSuit.Hearts, CardValue.Nine);
            g.House.Hand.AddCard(c1);
            g.House.Hand.AddCard(c2);
            Card c3 = new Card(CardSuit.Clubs, CardValue.Jack);
            Card c4 = new Card(CardSuit.Clubs, CardValue.Queen);
            Card c5 = new Card(CardSuit.Clubs, CardValue.Three);
            g.Player.Hand.AddCard(c3);
            g.Player.Hand.AddCard(c4);
            g.Player.Hand.AddCard(c5);
            Assert.That(g.Winner(), Is.EqualTo(Winner.Dealer));
        }

        [Test]
        public void DealerWins3()
        {
            Card c1 = new Card(CardSuit.Hearts, CardValue.Jack);
            Card c2 = new Card(CardSuit.Hearts, CardValue.Ace);
            g.House.Hand.AddCard(c1);
            g.House.Hand.AddCard(c2);
            Card c3 = new Card(CardSuit.Clubs, CardValue.Jack);
            Card c4 = new Card(CardSuit.Clubs, CardValue.Eight);
            Card c5 = new Card(CardSuit.Clubs, CardValue.Three);
            g.Player.Hand.AddCard(c3);
            g.Player.Hand.AddCard(c4);
            g.Player.Hand.AddCard(c5);
            Assert.That(g.Winner(), Is.EqualTo(Winner.Dealer));
        }

        [Test]
        public void Tie()
        {
            Card c1 = new Card(CardSuit.Hearts, CardValue.Jack);
            Card c2 = new Card(CardSuit.Hearts, CardValue.Ace);
            g.House.Hand.AddCard(c1);
            g.House.Hand.AddCard(c2);
            Card c3 = new Card(CardSuit.Clubs, CardValue.Jack);
            Card c4 = new Card(CardSuit.Clubs, CardValue.Ace);
            g.Player.Hand.AddCard(c3);
            g.Player.Hand.AddCard(c4);
            Assert.That(g.Winner(), Is.EqualTo(Winner.Tie));
        }

        [Test]
        public void PlayerWins()
        {
            Card c1 = new Card(CardSuit.Hearts, CardValue.Jack);
            Card c2 = new Card(CardSuit.Hearts, CardValue.Eight);
            g.House.Hand.AddCard(c1);
            g.House.Hand.AddCard(c2);
            Card c3 = new Card(CardSuit.Clubs, CardValue.Jack);
            Card c4 = new Card(CardSuit.Clubs, CardValue.Ace);
            g.Player.Hand.AddCard(c3);
            g.Player.Hand.AddCard(c4);
            Assert.That(g.Winner(), Is.EqualTo(Winner.Player));
        }

        [Test]
        public void PlayerWins2()
        {
            Card c1 = new Card(CardSuit.Hearts, CardValue.Jack);
            Card c2 = new Card(CardSuit.Hearts, CardValue.Eight);
            Card c3 = new Card(CardSuit.Hearts, CardValue.Three);
            g.House.Hand.AddCard(c1);
            g.House.Hand.AddCard(c2);
            g.House.Hand.AddCard(c3);
            Card c3 = new Card(CardSuit.Clubs, CardValue.Jack);
            Card c4 = new Card(CardSuit.Clubs, CardValue.Ace);
            g.Player.Hand.AddCard(c3);
            g.Player.Hand.AddCard(c4);
            Assert.That(g.Winner(), Is.EqualTo(Winner.Player));
        }

        [Test]
        public void PlayerWins3()
        {
            Card c1 = new Card(CardSuit.Hearts, CardValue.Jack);
            Card c2 = new Card(CardSuit.Hearts, CardValue.Four);
            Card c3 = new Card(CardSuit.Hearts, CardValue.Eight);
            g.House.Hand.AddCard(c1);
            g.House.Hand.AddCard(c2);
            g.House.Hand.AddCard(c3);
            Card c3 = new Card(CardSuit.Clubs, CardValue.Jack);
            Card c4 = new Card(CardSuit.Clubs, CardValue.Five);
            g.Player.Hand.AddCard(c3);
            g.Player.Hand.AddCard(c4);
            Assert.That(g.Winner(), Is.EqualTo(Winner.Player));
        }
    }
}
