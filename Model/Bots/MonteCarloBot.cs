using System;
using System.Collections.Generic;
using System.Text;
using Simulation.Core;

namespace Simulation.Bots
{
    class MonteCarloBot : Bot
    {
        private const int TRIALS = 10;
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
            int bestDraw = 0;
            double bestPercentage = 0.0;
            for (int i = 0; i < 3; i++)
            {
                double result = Simulate((Game)game.Clone(), i);
                if (result > bestPercentage)
                {
                    bestDraw = i;
                    bestPercentage = result;
                }
            }
            List<Card> cards = new List<Card>(game.PlayerHand.Cards);
            for (int i = 0; i < bestDraw; i++)
            {
                Result res = game.Hit();
                if (res == Result.Player || res == Result.Dealer)
                {
                    return res;
                }
            }

            return game.Stand();
        }
    }
}
