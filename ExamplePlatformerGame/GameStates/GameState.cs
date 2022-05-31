using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using CustomProject.Managers;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using CustomProject.Entities;

namespace CustomProject.GameStates
{
    public abstract class GameState
    {
        #region Fields

        protected GraphicsDevice _graphicsDevice;

        protected List<Sprite> _sprites;

        protected Texture2D _texture;

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="graphicsDevice"></param>
        public GameState(GraphicsDevice graphicsDevice)
        {
            _graphicsDevice = graphicsDevice;
        }

        #region Method

        public abstract void Initialize();

        public abstract void LoadContent(ContentManager content);

        public abstract void UnloadContent();

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);

        #endregion
    }
}
