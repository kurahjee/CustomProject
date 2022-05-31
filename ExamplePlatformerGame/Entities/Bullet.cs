using CustomProject.Entities;
using CustomProject.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomProject.Entities
{
    public class Bullet : MovableSprite
    {
        private bool _shoot;

        public Bullet(Dictionary<string, Animation> animations)
            : base(animations)
        {
            
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            base.Update(gameTime, sprites);
        }

        protected override void MovementSetUp()
        {
            Velocity.X = Speed;
        }

        protected override void CollisionSetUp(Sprite sprite)
        {

        }

        protected override void SetAnimation()
        {
            _animationManager.Play(_animations["ShootRight"]);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }
    }
}
