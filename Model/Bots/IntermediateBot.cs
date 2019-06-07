using System;
using System.Collections.Generic;
using System.Text;
using Simulation.Core;

namespace Simulation.Bots
{
    class IntermediateBot : Bot

    {
        public void Play(IBlackjack game)
        {
            int houseVal = game.DealerHand.Value;
            if (houseVal <= 6 && game.PlayerHand.Value > 11)
            {
                game.Stand();
            }
            else if (houseVal <= 7 && game.PlayerHand.Value <= 11)
            {
                game.Hit();
            }
            else if (houseVal >= 7 && game.PlayerHand.Value <= houseVal + 10)
            {
                game.Hit();
            }
            else
            {
                game.Stand();

            }
        }

        public int SetBet(IBlackjack game)
        {
            return 10;
        }
    }
}
