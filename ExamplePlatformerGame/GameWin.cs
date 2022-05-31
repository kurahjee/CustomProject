using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CustomProject.Managers;
using CustomProject.GameStates;

namespace CustomProject
{
    public class GameWin : Game
    {
        #region Fields

        private bool _paused = false;

        private bool pauseKeyDown = false;

        private KeyboardState keyboardState;

        private GraphicsDeviceManager _graphics;

        private SpriteBatch _spriteBatch;

        #endregion

        public GameWin()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";



            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            _graphics.PreferredBackBufferWidth = GraphicsDevice.Adapter.CurrentDisplayMode.Width;
            _graphics.PreferredBackBufferHeight = GraphicsDevice.Adapter.CurrentDisplayMode.Height;

            _graphics.IsFullScreen = true;

            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            GameStateManager.Instance.LoadContent(Content);
            GameStateManager.Instance.AddState(new PlayState(GraphicsDevice));

        }

        protected override void UnloadContent()
        {
            GameStateManager.Instance.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            keyboardState = Keyboard.GetState();


            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            checkPauseKey();
            if (_paused == false)
            {
                GameStateManager.Instance.Update(gameTime);

                base.Update(gameTime);
            }
        }

        private void checkPauseKey()
        {
            if (keyboardState.IsKeyDown(Keys.P))
            {
                pauseKeyDown = true;
            }
            else if (pauseKeyDown)
            {
                pauseKeyDown = false;
                _paused = !_paused;
            }
        }

        protected override void Draw(GameTime gameTime)
        {

            // TODO: Add your drawing code here

            GameStateManager.Instance.Draw(gameTime, _spriteBatch);

            base.Draw(gameTime);
        }
    }
}
