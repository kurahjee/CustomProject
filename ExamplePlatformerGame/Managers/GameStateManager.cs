using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using CustomProject.GameStates;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CustomProject.Managers
{
    public sealed class GameStateManager
    {
        #region Fields

        private static GameStateManager _instance;

        private static readonly object _padlock = new object();

        private ContentManager _content;

        private Stack<GameState> _gameStates = new Stack<GameState>();

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        private GameStateManager() { }

        #region Create Instance
        public static GameStateManager Instance
        {
            get
            {
                lock (_padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new GameStateManager();
                    }
                    return _instance;
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Set content for the game of each state
        /// </summary>
        /// <param name="content"></param>
        public void LoadContent(ContentManager content)
        {
            _content = content;
        }



        public void AddState(GameState gameState)
        {
            try
            {
                _gameStates.Push(gameState);
                _gameStates.Peek().Initialize();
                if (_content != null)
                {
                    _gameStates.Peek().LoadContent(_content);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex} Exexption caught.");
            }
        }

        public void RemoveGameState()
        {
            try
            {
                if (_gameStates.Count > 0)
                {
                    var gameState = _gameStates.Peek();
                    _gameStates.Pop();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex} Exeption caught.");
            }
        }

        public void ClearState()
        {
            while (_gameStates.Count > 0)
            {
                _gameStates.Pop();
            }
        }

        public void ChangeState(GameState gameState)
        {
            try
            {
                RemoveGameState();
                AddState(gameState);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex} Exeption caught.");
            }
        }

        public void Update(GameTime gameTime)
        {
            try
            {
                if (_gameStates.Count > 0)
                {
                    _gameStates.Peek().Update(gameTime);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex} Exeption caught.");
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            try
            {
                if (_gameStates.Count > 0)
                {
                    _gameStates.Peek().Draw(gameTime, spriteBatch);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex} Exeption caught.");
            }
        }

        public void UnloadContent()
        {
            /*
            foreach(GameState state in _gameStates)
            {
                state.UnloadContent();
            }
            */

            _gameStates.Peek().UnloadContent();
        }

        #endregion
    }
}
