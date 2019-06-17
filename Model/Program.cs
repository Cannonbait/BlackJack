using System;
using Simulation.Core;
using Simulation.Bots;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections.Generic;

namespace Simulation
{

    class Program
    {
        const int GAMESTOPLAY = 10000;

        static void Main(string[] args)
        {
            Random rnd = new Random();

            Stopwatch stopwatch = Stopwatch.StartNew();
            Simulate(new MonteCarloBot(100, 3), 0, rnd.Next());
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);



            //Simulate(new SimpleBot(13));
            //Simulate(new SimpleBot(14));
            //Simulate(new SimpleBot(15));

        }

        private static void Simulate(Bot bot, int initialMoney, int seed)
        {
            Game game = new Game(new Random(seed));
            for (int gamesPlayed = 0; gamesPlayed < GAMESTOPLAY; gamesPlayed++)
            {
                game.SetBet(bot.GetBet(game));
                game.NewHand();
                while (!game.HandOver)
                {
                    bot.Play(game);
                }
                //Console.WriteLine("Player: \t" + game.Player.ToString());
                //Console.WriteLine("Dealer: \t" + game.Dealer.ToString());
                game.FinishHand();
            }
            Console.WriteLine(string.Format("{0}\t Money: {1} \t Percent: {2}", bot.ToString(), game.Money, (game.Money + GAMESTOPLAY) / (GAMESTOPLAY * 2.0) * 100));
        }
    }
}
