using System;
using System.Collections.Generic;
using System.Text;

namespace Simulation.Core
{
    public interface Blackjack
    {
        void Hit();
        void Stand();

        Hand PlayerHand { get; }

        Hand DealerHand { get; }

        int GamesPlayed { get; }
        int PlayerWins { get; }
        int DealerWins { get; }
        //void DoubleDown();
        //void Split();


    }
}
