using System;
using Simulation.Core;
using Simulation.Bots;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Simulation
{

    class Program
    {
        const int GAMESTOPLAY = 1;

        static void Main(string[] args)
        {
            BlackjackGame game = new BlackjackGame();
            for (int i = 0; i < 13; i++)
            {
                Console.WriteLine(game.Draw());

            }




            //Random rnd = new Random();
            //Stopwatch stopwatch = Stopwatch.StartNew();
            //Simulate(new StatisticBot(), 0, rnd.Next());
            //stopwatch.Stop();
            //Console.WriteLine(stopwatch.ElapsedMilliseconds);

            //Task[] taskArray = new Task[4];
            //taskArray[0] = new Task(() => Simulate(new MonteCarloBot(100, 3, 0.5), 0, rnd.Next()));
            //taskArray[1] = new Task(() => Simulate(new MonteCarloBot(100, 4, 0.5), 0, rnd.Next()));
            //taskArray[2] = new Task(() => Simulate(new MonteCarloBot(200, 3, 0.5), 0, rnd.Next()));
            //taskArray[3] = new Task(() => Simulate(new MonteCarloBot(200, 4, 0.5), 0, rnd.Next()));
            //taskArray[0].Start();
            //taskArray[1].Start();
            //taskArray[2].Start();
            //taskArray[3].Start();
            //Task.WaitAll(taskArray);


            //Simulate(new SimpleBot(13));
            //Simulate(new SimpleBot(14));
            //Simulate(new SimpleBot(15));

        }

        private static void Simulate(Bot bot, int initialMoney, int seed)
        {
            Game game = new Game(new Random(seed));
            for (int gamesPlayed = 0; gamesPlayed < GAMESTOPLAY; gamesPlayed++)
            {
                //Console.WriteLine(id + "\t" + game.Money);
                game.SetBet(bot.SetBet(game));
                game.NewHand();
                while (!game.HandOver)
                {
                    bot.Play(game);
                }
                game.FinishHand();
            }
            Console.WriteLine(string.Format("{0}\t Money: {1} \t Percent: {2}", bot.ToString(), game.Money, (game.Money + GAMESTOPLAY) / (GAMESTOPLAY * 2.0) * 100));
        }
    }
}
