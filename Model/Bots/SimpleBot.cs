using System;
using System.Collections.Generic;
using System.Text;
using Simulation.Core;

namespace Simulation.Bots
{
    public class SimpleBot : Bot
    {

        public void Play(Blackjack game, int gamesPlayed)
        {
            while (game.GamesPlayed < gamesPlayed)
            {
                if (game.PlayerHand.Value < 17)
                {
                    game.Hit();
                }
                else
                {
                    game.Stand();
                }
            }
        }
    }
}
