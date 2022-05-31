using CustomProject.Entities;
using CustomProject.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamplePlatformerGame.Entities
{
    public class Weapon : MovableSprite
    {
        private bool isShoot = false;

        public bool IsActive
        {
            get => isShoot;
            set => isShoot = value;
        }

        public Weapon(Dictionary<string, Animation> animations) : base(animations)
        {
        }

        protected override void SetAnimation()
        {
            _animationManager.Play(_animations["Shot"]);
        }

        protected override void Move()
        {
            Velocity.X = Speed;
            Velocity.Y = gravity;
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            base.Update(gameTime, sprites);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if(isShoot)
                base.Draw(gameTime, spriteBatch);
        }
    }
}
