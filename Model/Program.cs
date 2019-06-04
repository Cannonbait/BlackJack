using System;
using Simulation.Core;
using Simulation.Bots;

namespace Simulation
{
    class Program
    {
        static void Main(string[] args)
        {
            int gamesToPlay = 500;
            Blackjack blackjack = new Game();
            Bot bot = new SimpleBot();
            bot.Play(blackjack, gamesToPlay);

            Console.WriteLine(string.Format("{0}%", (double)blackjack.PlayerWins / blackjack.GamesPlayed * 100));
        }
    }
}
