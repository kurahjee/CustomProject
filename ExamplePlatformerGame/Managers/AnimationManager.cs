using CustomProject.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomProject.Managers
{
    public sealed class AnimationManager
    {
        #region Fields

        private Animation _animation;

        private float _timer = 0;

        public Vector2 Position { get; set; }

        #endregion

        public AnimationManager(Animation animation)
        {
            _animation = animation;
        }

        public void Play(Animation animation)
        {
            if (_animation == animation)
                return;

            _animation = animation;

            _animation.CurrentFrame = 0;

            _timer = 0;
        }

        public void Stop(Animation animation)
        {
            _timer = 0;

            _animation.CurrentFrame = 0;
        }

        public void Update(GameTime gameTime)
        {
            _timer += ((float)gameTime.ElapsedGameTime.TotalSeconds) * 4;

            if (_timer > _animation.FrameSpeed)
            {
                _timer = 0f;

                _animation.CurrentFrame++;

                if (_animation.CurrentFrame >= _animation.FrameCount)
                {
                    _animation.CurrentFrame = 0;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_animation.Texture,
                             Position,
                             new Rectangle(_animation.CurrentFrame * _animation.FrameWidth,
                                           0,
                                           _animation.FrameWidth,
                                           _animation.FrameHeight),
                             Color.White, 0, Vector2.Zero, 1, SpriteEffects.None,
                             (float)LayerDepth.MainPlatform / (float)LayerDepth.MAX_LAYER);
        }
    }
}
