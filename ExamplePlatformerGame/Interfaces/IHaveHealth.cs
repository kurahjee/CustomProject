using System;
using System.Collections.Generic;
using System.Text;

namespace ExamplePlatformerGame.Interfaces
{
    interface IHaveHealth
    {
        public void ReduceHealth();

        public void IncreaseHealth();

        public bool IsDeath { get; }
    }
}
