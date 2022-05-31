using CustomProject.Interfaces;
using CustomProject.Models;
using ExamplePlatformerGame.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomProject.Entities.Characters
{
    public class Enemy : Character
    {

        private MouseState mouse = Mouse.GetState();

        public Enemy(Dictionary<string, Animation> animations)
            : base(animations)
        {

        }

        public Enemy(Texture2D texture)
            : base(texture)
        {

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            MovableSprite player = MovableSpriteManager.Instance.FetchObject("player");

            base.Update(gameTime, sprites);
        }

        protected override void Move()
        {
            
        }

        private bool IsPlayerInRange(Player player)
        {

            return false;
        }

        protected override void SetAnimation()
        {
            _animationManager.Play(_animations["Idle"]);
        }
    }
}
