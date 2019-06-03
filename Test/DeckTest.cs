using NUnit.Framework;
using Model.Core;

namespace Test
{
    class DeckTest
    {
        [Test]
        public void Basic()
        {
            Deck d = new Deck();
            Assert.That(d.Size, Is.EqualTo(52));
        }

        [Test]
        public void Draw()
        {
            Deck d = new Deck();
            d.Draw();
            Assert.That(d.Size, Is.EqualTo(51));
        }

        [Test]
        public void Reset()
        {
            Deck d = new Deck();
            d.Draw();
            d.Draw();
            d.Draw();
            d.ResetDeck();
            Assert.That(d.Size, Is.EqualTo(52));
        }
    }
}
