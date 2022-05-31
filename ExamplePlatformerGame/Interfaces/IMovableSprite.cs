using CustomProject.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomProject.Interfaces
{
    interface IMovableSprite
    {
        public void SetMovement();
        public string Identity { get; }
    }
}
