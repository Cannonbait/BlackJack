using System;
using System.Collections.Generic;
using System.Text;
using Simulation.Core;

namespace Simulation.Bots
{
    class MonteCarloBot : Bot
    {
        private int trials;
        private int maxDraw;
        private double doubleDown;

        public MonteCarloBot() : this(200, 2, 0.5) { }

        public MonteCarloBot(int trials, int maxDraw, double doubleDown)
        {
            this.trials = trials;
            this.maxDraw = maxDraw;
            this.doubleDown = doubleDown;
        }
        public double Simulate(IBlackjack game, int playerDraws)
        {
            int wins = 0;
            for (int i = 0; i < trials; i++)
            {
                if (SimulateHand((Game)game.Clone(), playerDraws) == Result.Player)
                {
                    wins++;
                }
            }
            return (double)wins / trials;

        }

        private Result SimulateHand(IBlackjack game, int playerDraws)
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

            for (int currentDraw = 1; currentDraw < maxDraw; currentDraw++)
            {
                winDraw += Simulate(game, currentDraw);
                if (currentDraw == 1 && winDraw > doubleDown)
                {
                    game.DoubleDown();
                    return;
                }
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
            return "MonteCarloBot:" + "\tTrials: " + trials + "\tMaxDraw: " + maxDraw + "\tDoubleDown: " + doubleDown;
        }

        public int SetBet(IBlackjack game)
        {
            return 1;
        }
    }
}
