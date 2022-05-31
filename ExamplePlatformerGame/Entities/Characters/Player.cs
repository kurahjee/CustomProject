using System.Collections.Generic;
using CustomProject.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CustomProject.Entities.Characters
{
    public class Player : Character
    {
        #region Fields

        private List<Item> _inventory;

        private Direction _direction;

        private bool hasjumped;

        #endregion

        #region Properties



        #endregion

        public Player(Dictionary<string, Animation> animations)
            : base(animations)
        {
            _direction = Direction.Right;
            _identity = "player";
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            base.Update(gameTime, sprites);
        }

        protected override void SetAnimation()
        {
            if (Velocity.X > 0)
            {
                _animationManager.Play(_animations["WalkRight"]);
            }
            else if (Velocity.X < 0)
            {
                _animationManager.Play(_animations["WalkLeft"]);
            }
            else if (Velocity.X == 0)
            {
                if (_direction == Direction.Right)
                {
                    _animationManager.Play(_animations["IdleRight"]);
                }
                if (_direction == Direction.Left)
                {
                    _animationManager.Play(_animations["IdleLeft"]);
                }
            }
            if (Velocity.Y != 0)
            {
                if (_direction == Direction.Right)
                {
                    _animationManager.Play(_animations["JumpRight"]);
                }
                else if (_direction == Direction.Left)
                {
                    _animationManager.Play(_animations["JumpLeft"]);
                }
            }
        }

        protected override void Move()
        {
            KeyboardState keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Input.Left))
            {
                _direction = Direction.Left;
                Velocity.X = -Speed;
            }
            else if (keyState.IsKeyDown(Input.Right))
            {
                _direction = Direction.Right;
                Velocity.X = Speed;
            }
            if (keyState.IsKeyDown(Input.Jump) && hasjumped == false)
            {
                Velocity.Y = -Speed;
            }
        }

        private void PickUpItem(Item item)
        {

        }
    }
}
