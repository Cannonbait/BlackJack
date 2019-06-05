using System;
using System.Collections.Generic;
using System.Text;
using Simulation.Core;

namespace Simulation.Bots
{
    class MonteCarloBot : Bot
    {
        private const int TRIALS = 100;
        public static double Simulate(IBlackjack game, int playerDraws)
        {
            int wins = 0;
            for (int i = 0; i < TRIALS; i++)
            {
                Game simGame = (Game)game.Clone();
                for (int y = 0; y < playerDraws; y++)
                {
                    game.Hit();
                }
                if (simGame.Stand() == Result.Player)
                {
                    wins++;
                }
            }
            return (double)wins / TRIALS;

        }

        public Result Play(IBlackjack game)
        {
            //Find out if drawing any number of cards has better winchance than drawing 0 cards
            double winZero = Simulate(game, 0);

            for (int currentDraw = 0; currentDraw < 1; currentDraw++)
            {
                if (Simulate((Game)game.Clone(), currentDraw) > winZero)
                {
                    return game.Hit();
                }
            }
            return game.Stand();
        }

        public override string ToString()
        {
            return "MonteCarloBot";
        }
    }
}
