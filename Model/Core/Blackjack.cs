using System;
using System.Collections.Generic;
using System.Text;

namespace Simulation.Core
{
    public interface Blackjack
    {
        Result Hit();
        Result Stand();

        Hand PlayerHand { get; }

        Hand DealerHand { get; }

        Deck Deck { get; }


    }
}
