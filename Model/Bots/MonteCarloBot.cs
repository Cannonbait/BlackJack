using System;
using System.Collections.Generic;
using System.Text;
using Simulation.Core;

namespace Simulation.Bots
{
    class MonteCarloBot : Bot
    {
        private const int TRIALS = 500;
        private const int MAXDRAW = 4;
        public static double Simulate(IBlackjack game, int playerDraws)
        {
            int wins = 0;
            for (int i = 0; i < TRIALS; i++)
            {
                Game simGame = (Game)game.Clone();
                if (SimulateHand((Game)game.Clone(), playerDraws) == Result.Player)
                {
                    wins++;
                }
            }
            return (double)wins / TRIALS;

        }

        private static Result SimulateHand(IBlackjack game, int playerDraws)
        {
            for (int draws = 0; draws < playerDraws; draws++)
            {
                game.Hit();
            }
            game.Stand();
            return game.Winner();

        }

        public void Play(IBlackjack game)
        {
            //Draw a card if better winrate than drawing 0
            double winZero = Simulate(game, 0);
            double winDraw = 0;
            //Console.WriteLine("Zero draw prob: " + winZero);

            for (int currentDraw = 1; currentDraw < MAXDRAW; currentDraw++)
            {
                winDraw += Simulate((Game)game.Clone(), currentDraw);
                if (winDraw > winZero)
                {
                    game.Hit();
                    return;
                }
            }
            game.Stand();
        }

        public override string ToString()
        {
            return "MonteCarloBot";
        }
    }
}
