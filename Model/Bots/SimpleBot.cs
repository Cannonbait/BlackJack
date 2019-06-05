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

        public void Play(IBlackjack game)
        {
            if (game.PlayerHand.Value < hitBelow)
            {
                game.Hit();

            }
            else
            {
                game.Stand();
            }
        }

        public override string ToString()
        {
            return String.Format("SimpleBot({0})", hitBelow);
        }
    }
}
