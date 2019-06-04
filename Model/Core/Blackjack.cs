using System;
using System.Collections.Generic;
using System.Text;

namespace Simulation.Core
{
    public interface IBlackjack
    {
        Result Hit();
        Result Stand();

        Hand PlayerHand { get; }

        Hand DealerHand { get; }

        Deck Deck { get; }


    }
}
