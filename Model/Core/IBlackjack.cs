using System;
using System.Collections.Generic;
using System.Text;

namespace Simulation.Core
{
    public interface IBlackjack
    {
        void Hit();
        void Stand();

        void DoubleDown();

        void SetBet(int bet);

        Result Winner();

        bool HandOver { get; }

        Hand PlayerHand { get; }

        Hand DealerHand { get; }

        Deck Deck { get; }

        Object Clone();

    }
}
