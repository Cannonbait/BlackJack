using System;
using System.Collections.Generic;
using System.Text;
using Simulation.Core;

namespace Simulation.Bots
{
    class IntermediateBot : Bot

    {
        public Result Play(IBlackjack game)
        {
            int houseVal = game.DealerHand.Value;
            if (houseVal <= 6 && game.PlayerHand.Value > 11)
            {
                return game.Stand();
            }
            else if (houseVal <= 7 && game.PlayerHand.Value <= 11)
            {
                return game.Hit();
            }
            else if (houseVal >= 7 && game.PlayerHand.Value <= houseVal + 10)
            {
                return game.Hit();
            }
            return game.Stand();
        }
    }
}
