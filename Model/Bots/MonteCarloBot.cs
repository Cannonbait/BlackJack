using System;
using System.Collections.Generic;
using System.Text;
using Simulation.Core;

namespace Simulation.Bots
{
    class MonteCarloBot : Bot
    {
        const int SIMULATIONS = 500;
        public void Play(Blackjack game, int gamesPlayed)
        {
            while (game.GamesPlayed < gamesPlayed)
            {
                MakePlay(game);
            }
        }

        private void MakePlay(Blackjack game)
        {

            for (int i = 0; i < SIMULATIONS; i++)
            {

            }

        }
    }
}
