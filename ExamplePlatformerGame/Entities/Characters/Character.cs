using CustomProject.Interfaces;
using CustomProject.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomProject.Entities.Characters
{
    public class Character : MovableSprite
    {
        #region Fields

        private int _health;

        private Texture2D _healthTexture;

        private Rectangle _healthRectangle;

        private MouseState pastMouse;

        private int _damage;

        #endregion

        #region Properties

        public int Health
        {
            get => _health;
            set => _health = value;
        }

        public Texture2D HealthTexture
        {
            get => _healthTexture;
            set => _healthTexture = value;
        }

        public Color HealthBarColor { get; set; }

        public int Damage
        {
            get => _damage;
            set => _damage = value;
        }

        public bool IsAlive { get { return _health > 0 ? true : false; } }

        #endregion

        public Character(Dictionary<string, Animation> animations)
            : base(animations)
        {

        }

        public Character(Texture2D texture)
            : base(texture)
        {

        }

        protected override void SetAnimation()
        {

        }

        protected override void MovementSetUp()
        {
        }

        private void DrawHealthBar(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_healthTexture, _healthRectangle, HealthBarColor);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            DrawHealthBar(spriteBatch);
            if (IsAlive)
            {
                base.Draw(gameTime, spriteBatch);
            }
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            MouseState mouse = Mouse.GetState();
            Rectangle mouseRectangle = new Rectangle(mouse.X, mouse.Y, 1, 1);
            _healthRectangle = new Rectangle((int)Position.X, (int)Position.Y - 30, _health, 20);

            if(mouseRectangle.Intersects(this.Rectangle)&&(mouse.LeftButton == ButtonState.Pressed && pastMouse.LeftButton == ButtonState.Released)){
                _health -= 10;
            }

            base.Update(gameTime, sprites);
            pastMouse = mouse;
        }
    }
}
