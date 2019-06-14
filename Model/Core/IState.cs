using System;
using System.Collections.Generic;
using System.Text;

namespace Simulation.Core
{
    interface IState
    {
        void SetState();
        void RestoreState();
    }
}
