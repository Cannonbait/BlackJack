﻿using System;
using Simulation.Core;
using Simulation.Bots;

namespace Simulation
{
    class Program
    {
        const int GAMESTOPLAY = 500;
        static void Main(string[] args)
        {
            Simulate(new SimpleBot());
            Simulate(new MonteCarloBot());

        }

        private static void Simulate(Bot bot)
        {
            Blackjack blackjack = new Game();
            bot.Play(blackjack, GAMESTOPLAY);
            Console.WriteLine(string.Format("{0}%", (double)blackjack.PlayerWins / blackjack.GamesPlayed * 100));
        }
    }
}
