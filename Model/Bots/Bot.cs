using System;
using System.Collections.Generic;
using System.Text;
using Simulation.Core;

namespace Simulation.Bots
{
    public interface Bot
    {
        Result Play(IBlackjack game);
    }
}
