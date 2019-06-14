using System;
using System.Collections.Generic;
using System.Text;
using Simulation.Core2;

namespace Simulation.Bots
{
    public interface Bot
    {
        void Play(IBlackjack game);

        int GetBet(IBlackjack game);
    }
}
