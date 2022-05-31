using CustomProject.Interfaces;
using CustomProject.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomProject.Entities
{
    public class MovableSprite : Sprite
    {
        protected readonly float gravity = 9.8f;

        protected string _identity;

        public string Identity
        {
            get { return _identity; }
        }

        public MovableSprite(Dictionary<string, Animation> animations) : base(animations)
        {
        }

        public MovableSprite(Texture2D texture) : base(texture)
        {
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            Move();

            DetectCollisionSetting(sprites);

            base.Update(gameTime, sprites);

            Position += Velocity;
            Velocity.X = 0;
            Velocity.Y = gravity;
        }

        protected override void SetAnimation()
        {
        }

        protected virtual void Move()
        {
        }

        public virtual void DetectCollisionSetting(List<Sprite> sprites)
        {
            foreach (var sprite in sprites)
            {
                if (sprite == this)
                    continue;

                if ((this.Velocity.X > 0 && this.IsTouchingLeft(sprite)) ||
                    (this.Velocity.X < 0 & this.IsTouchingRight(sprite)))
                    this.Velocity.X = 0;

                if ((this.Velocity.Y > 0 && this.IsTouchingTop(sprite)) ||
                    (this.Velocity.Y < 0 & this.IsTouchingBottom(sprite)))
                    this.Velocity.Y = 0;
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }

        public bool AreYou(string id)
        {
            return _identity == id ? true : false;
        }
    }
}
