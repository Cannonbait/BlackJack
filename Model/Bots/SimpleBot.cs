using System;
using System.Collections.Generic;
using System.Text;
using Simulation.Core;

namespace Simulation.Bots
{
    public class SimpleBot : Bot
    {

        public Result Play(IBlackjack game)
        {
            if (game.PlayerHand.Value < 17)
            {
                return game.Hit();
            }
            else
            {
                return game.Stand();
            }


        }
    }
}
