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
    }
}
