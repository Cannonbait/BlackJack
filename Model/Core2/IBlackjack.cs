using System;
using System.Collections.Generic;
using System.Text;

namespace Simulation.Core2
{
    public interface IBlackjack
    {
        void Hit();
        void Stand();

        void DoubleDown();

        void SetBet(int bet);

        Result Winner();

        bool HandOver { get; }

        Hand Player { get; }

        Hand Dealer { get; }

        Deck Deck { get; }

        void SetState();
        void RestoreState();


    }
}
