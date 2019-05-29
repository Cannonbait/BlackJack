using NUnit.Framework;

namespace Tests
{
    public class CardTest
    {
        [Test]
        public void Basic()
        {
            Card c = new Card(CardSuit.Club, CardValue.Ace);
            Assert.That(c.Suit, Is.EqualTo(CardSuit.Club));
            Assert.That(c.Value, Is.EqualTo(CardValue.Ace));
        }
    }
}