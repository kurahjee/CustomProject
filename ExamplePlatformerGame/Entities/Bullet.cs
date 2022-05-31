using CustomProject.Entities;
using CustomProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamplePlatformerGame.Entities
{
    public class Bullet : MovableSprite
    {
        public Bullet(Dictionary<string, Animation> animations)
            : base(animations)
        {

        }
    }
}
