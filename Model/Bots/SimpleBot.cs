using System;
using System.Collections.Generic;
using System.Text;
using Simulation.Core;

namespace Simulation.Bots
{
    public class SimpleBot : Bot
    {
        private int hitBelow;
        public SimpleBot(int hitBelow)
        {
            this.hitBelow = hitBelow;
        }

        public Result Play(IBlackjack game)
        {
            if (game.PlayerHand.Value < hitBelow)
            {
                return game.Hit();
            }
            else
            {
                return game.Stand();
            }
        }

        public override string ToString()
        {
            return String.Format("SimpleBot({0})", hitBelow);
        }
    }
}
