using CustomProject.Models;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace CustomProject.Entities.Items
{
    public class Item : Sprite
    {
        public Item(Dictionary<string, Animation> animations)
            : base(animations)
        {

        }

        public Item(Texture2D texture)
            : base(texture)
        {

        }
    }
}
