using CustomProject.Managers;
using CustomProject.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomProject.Entities
{
    public class Sprite : GameObject
    {
        #region Fields

        protected AnimationManager _animationManager;

        protected Dictionary<string, Animation> _animations;

        private Vector2 _position;

        private Texture2D _texture;

        private Color _color;

        #endregion

        #region Properties

        public Vector2 Position
        {
            get { return _position; }
            set
            {
                _position = value;

                if (_animationManager != null)
                {
                    _animationManager.Position = _position;
                }
            }
        }

        public Texture2D Texture
        {
            get { return _texture; }
            set { _texture = value; }
        }

        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public Input Input { get; set; }

        public float Speed = 8f;

        public Vector2 Velocity;

        public Rectangle Rectangle
        {
            get
            {
                if (_animationManager != null)
                {
                    return new Rectangle(
                        (int)Position.X, (int)Position.Y,
                        _animations.First().Value.FrameWidth, _animations.First().Value.FrameHeight);
                }

                return new Rectangle((int)Position.X, (int)Position.Y, this.Texture.Width, this.Texture.Height);
            }
        }

        #endregion

        public Sprite(Dictionary<string, Animation> animations)
        {
            _animations = animations;
            _animationManager = new AnimationManager(_animations.First().Value);
        }

        public Sprite(Texture2D texture)
        {
            _texture = texture;
            _color = Color.White;
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            if (_animationManager != null)
            {
                SetAnimation();
                _animationManager.Update(gameTime);
            }
        }

        protected virtual void SetAnimation()
        {
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (_texture != null)
            {
                spriteBatch.Draw(Texture,
                             Position,
                             Rectangle,
                             Color,
                             0,
                             Vector2.Zero,
                             1,
                             SpriteEffects.None,
                             (float)LayerDepth.MainPlatform / (float)LayerDepth.MAX_LAYER);
            }
            else if (_animationManager != null)
            {
                _animationManager.Draw(spriteBatch);
            }
        }

        #region Collision

        protected bool IsTouchingLeft(Sprite sprite)
        {
            return this.Rectangle.Right + this.Velocity.X >= sprite.Rectangle.Left &&
                   this.Rectangle.Left < sprite.Rectangle.Left &&
                   this.Rectangle.Bottom > sprite.Rectangle.Top &&
                   this.Rectangle.Top < sprite.Rectangle.Bottom;
        }

        protected bool IsTouchingRight(Sprite sprite)
        {
            return this.Rectangle.Left + this.Velocity.X < sprite.Rectangle.Right &&
              this.Rectangle.Right > sprite.Rectangle.Right &&
              this.Rectangle.Bottom > sprite.Rectangle.Top &&
              this.Rectangle.Top < sprite.Rectangle.Bottom;
        }

        protected bool IsTouchingTop(Sprite sprite)
        {
            return this.Rectangle.Bottom + this.Velocity.Y > sprite.Rectangle.Top &&
              this.Rectangle.Top < sprite.Rectangle.Top &&
              this.Rectangle.Right > sprite.Rectangle.Left &&
              this.Rectangle.Left < sprite.Rectangle.Right;
        }

        protected bool IsTouchingBottom(Sprite sprite)
        {
            return this.Rectangle.Top + this.Velocity.Y < sprite.Rectangle.Bottom &&
              this.Rectangle.Bottom > sprite.Rectangle.Bottom &&
              this.Rectangle.Right > sprite.Rectangle.Left &&
              this.Rectangle.Left < sprite.Rectangle.Right;
        }

        #endregion
    }
}
