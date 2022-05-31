using System.Collections.Generic;
using CustomProject.Interfaces;
using CustomProject.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CustomProject.Entities.Characters
{
    public class Player : Character, IHaveHealth, IHaveWeapon
    {
        #region Fields

        private Direction _direction;

        private Bullet _bullet;

        #endregion

        #region Properties

        public Bullet Bullet
        {
            get => _bullet;
            set => _bullet = value;
        }

        #endregion

        public Player(Dictionary<string, Animation> animations)
            : base(animations)
        {
            _direction = Direction.Right;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            _previousKey = _currentKey;
            _currentKey = Keyboard.GetState();

            if (_currentKey.IsKeyDown(Input.Attack)&&_previousKey.IsKeyUp(Input.Attack))
            {
                var bullet = _bullet.Clone() as Bullet;
                bullet.LifeSpan = 2f;
                bullet.Position = Position;
                sprites.Add(bullet);
            }

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

        protected override void MovementSetUp()
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
            if (keyState.IsKeyDown(Input.Jump))
            {
                Velocity.Y = -Speed;
            }
        }

        public void ReduceHealth(string id)
        {
            
        }

        public void IncreaseHealth()
        {
            throw new System.NotImplementedException();
        }

        public void Attack()
        {
            throw new System.NotImplementedException();
        }
    }
}
