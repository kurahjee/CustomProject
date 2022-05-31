using CustomProject.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomProject.Entities.TileMap
{
    public class Tile : Sprite
    {
        public int TileID { get; set; }

        public Tile(Texture2D texture) : base(texture)
        {

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture,
                             Position,
                             null,
                             Color.White,
                             0,
                             Vector2.Zero,
                             1,
                             SpriteEffects.None,
                             (float)LayerDepth.MainPlatform / (float)LayerDepth.MAX_LAYER);
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
        }
    }
}
