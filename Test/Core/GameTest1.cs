using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Simulation.Core;
namespace Test
{
    class GameTest1
    {
        Game g;
        [SetUp]
        public void Setup()
        {
            g = new Game(new Random());
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
            g.NewHand();
            Assert.That(g.Dealer.Size, Is.EqualTo(1));
            Assert.That(g.Player.Size, Is.EqualTo(2));
            Assert.That(g.Dealer.Value, Is.LessThan(12));
            Assert.That(g.Dealer.Value, Is.GreaterThan(1));
            Assert.That(g.Player.Value, Is.GreaterThan(3));
            Assert.That(g.Player.Value, Is.LessThanOrEqualTo(21));
        }


        [Test]
        public void DealerHigherValueHand()
        {
            g.ClearHands();
            g.Dealer.AddCard(10);
            g.Dealer.AddCard(11);
            g.Player.AddCard(10);
            g.Player.AddCard(10);
            Assert.That(g.Winner(), Is.EqualTo(Result.Dealer));
        }

        [Test]
        public void PlayerBusts()
        {
            g.ClearHands();
            g.Dealer.AddCard(10);
            g.Dealer.AddCard(11);
            g.Player.AddCard(10);
            g.Player.AddCard(10);
            g.Player.AddCard(2);
            Assert.That(g.Winner(), Is.EqualTo(Result.Dealer));
        }

        [Test]
        public void DealerBlackjackVsPlayer21()
        {
            g.ClearHands();
            g.Dealer.AddCard(10);
            g.Dealer.AddCard(11);
            g.Player.AddCard(10);
            g.Player.AddCard(8);
            g.Player.AddCard(3);
            Assert.That(g.Winner(), Is.EqualTo(Result.Dealer));
        }

        [Test]
        public void Tie()
        {
            g.ClearHands();
            g.Dealer.AddCard(10);
            g.Dealer.AddCard(10);
            g.Player.AddCard(10);
            g.Player.AddCard(10);
            Assert.That(g.Winner(), Is.EqualTo(Result.Tie));
        }

        [Test]
        public void PlayerHigherValueHand()
        {
            g.ClearHands();
            g.Dealer.AddCard(10);
            g.Dealer.AddCard(7);
            g.Player.AddCard(10);
            g.Player.AddCard(11);
            Assert.That(g.Winner(), Is.EqualTo(Result.Player));
        }

        [Test]
        public void PlayerBlackjackVSHouse21()
        {
            g.ClearHands();
            g.Dealer.AddCard(10);
            g.Dealer.AddCard(7);
            g.Dealer.AddCard(4);
            g.Player.AddCard(10);
            g.Player.AddCard(11);
            Assert.That(g.Winner(), Is.EqualTo(Result.Player));
        }

        [Test]
        public void DealerBusts()
        {
            g.ClearHands();
            g.Dealer.AddCard(10);
            g.Dealer.AddCard(7);
            g.Dealer.AddCard(5);
            g.Player.AddCard(10);
            g.Player.AddCard(6);
            Assert.That(g.Winner(), Is.EqualTo(Result.Player));
        }

        [Test]
        public void Tie18()
        {
            g.ClearHands();
            g.Dealer.AddCard(10);
            g.Dealer.AddCard(8);
            g.Player.AddCard(10);
            g.Player.AddCard(8);
            Assert.That(g.Winner(), Is.EqualTo(Result.Tie));
        }

        [Test]
        public void SaveState()
        {
            g.SetState();
            int playerCards = g.Player.Size;
            int dealerCards = g.Dealer.Size;
            int deckSize = g.Deck.CardsLeft;
            g.PlayerDraw();
            g.DealerDraw();
            g.RestoreState();
            Assert.That(g.Player.Size, Is.EqualTo(playerCards));
            Assert.That(g.Dealer.Size, Is.EqualTo(dealerCards));
            Assert.That(g.Deck.CardsLeft, Is.EqualTo(deckSize));
        }

        [Test]
        public void Hit()
        {
            g.NewHand();
            g.Hit();
            Assert.That(g.Player.Size, Is.EqualTo(3));
        }

        [Test]
        public void HandOver()
        {
            g.NewHand();
            Assert.That(!g.HandOver);
            g.SetState();
            while (!g.HandOver)
            {
                g.Hit();
            }
            Assert.That(g.HandOver);
            g.RestoreState();
            Assert.That(!g.HandOver);


        }
    }
}
