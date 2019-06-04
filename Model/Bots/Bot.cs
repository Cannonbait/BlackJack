using System;
using System.Collections.Generic;
using System.Text;
using Simulation.Core;

namespace Simulation.Bots
{
    public interface Bot
    {
        double Play(IBlackjack game, int gamesPlayed);
    }
}
