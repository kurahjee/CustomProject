using CustomProject.Interfaces;
using CustomProject.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace CustomProject.Entities.Characters
{
    public class Enemy : Character, IHaveHealth, IHaveWeapon
    {

        private MouseState mouse = Mouse.GetState();

        public bool IsDeath => throw new NotImplementedException();

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
            base.Update(gameTime, sprites);
        }

        protected override void MovementSetUp()
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

        public void ReduceHealth(string id)
        {
            throw new NotImplementedException();
        }

        public void IncreaseHealth()
        {
            throw new NotImplementedException();
        }

        public void Attack()
        {
            throw new NotImplementedException();
        }
    }
}
