using System;
using System.Collections.Generic;
using System.Text;
using Simulation.Core;

namespace Simulation.Bots
{
    public class SimpleBot : Bot
    {

        public double Play(IBlackjack game, int gamesPlayed)
        {
            int totalPlayed = 0;
            int wins = 0;
            while (totalPlayed < gamesPlayed)
            {
                Result res;
                if (game.PlayerHand.Value < 17)
                {
                    res = game.Hit();
                }
                else
                {
                    res = game.Stand();
                }

                if (res != Result.None)
                {
                    totalPlayed++;
                    if (res == Result.Player)
                    {
                        wins++;
                    }
                }
            }
            return (double)wins / totalPlayed * 100;
        }
    }
}
