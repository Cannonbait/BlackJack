using System;
using System.Collections.Generic;
using System.Text;

namespace Simulation.Core2
{
    interface IState
    {
        void SetState();
        void RestoreState();
    }
}
