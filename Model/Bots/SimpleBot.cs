using System;
using System.Collections.Generic;
using System.Text;
using Simulation.Core2;

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
            if (game.Player.Value < hitBelow)
            {
                game.Hit();

            }
            else
            {
                game.Stand();
            }
        }

        public int GetBet(IBlackjack game)
        {
            return 1;
        }

        public override string ToString()
        {
            return String.Format("SimpleBot({0})", hitBelow);
        }
    }
}
