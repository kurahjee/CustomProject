using CustomProject.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomProject.Interfaces
{
    interface IMovableSprite
    {
        public MovableSprite FetchMovableObject(List<Sprite> sprites);
        public string Identity { get; }
    }
}
