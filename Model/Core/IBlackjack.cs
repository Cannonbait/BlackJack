using System;
using System.Collections.Generic;
using System.Text;

namespace Simulation.Core
{
    public interface IBlackjack
    {
        void Hit();
        void Stand();

        void DoubleDown();

        void Split();

        void Surrender();

        void Insurance();

        bool CanSplit();

        bool CanSurrender();

        bool CanInsure();

        Result Winner();

        bool HandsOver { get; }

        bool HandOver { get; }

        int Money { get; }

        List<Hand> Hands { get; }

        Hand ActiveHand { get; }

        Hand Dealer { get; }

        Deck Deck { get; }

        void SetState();
        void RestoreState();

        void NewHand(int i);

        void FinishHand();


    }
}
