using System;
using System.Collections.Generic;
using System.Text;

namespace CustomProject.Interfaces
{
    interface IHaveHealth
    {
        public void ReduceHealth(string id);

        public void IncreaseHealth();
    }
}
