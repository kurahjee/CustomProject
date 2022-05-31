using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using CustomProject.GameStates;
using CustomProject.Entities;
using Microsoft.Xna.Framework.Audio;

namespace CustomProject.Entities
{
    public class Button : Sprite
    {
        #region Fields
        private MouseState _currentMouse;

        private SpriteFont _font;

        private SoundEffect _mouseOverSound;

        private SoundEffect _clickConfirmSound;

        private bool _isHovering;

        private MouseState _previousMouse;

        private Texture2D _texture;


        #endregion

        #region Properties

        public event EventHandler Click;

        public bool Clicked { get; private set; }

        public Color PenColor { get; set; }

        public SpriteFont Font { get; set; }

        public SoundEffect MouseOverSound
        {
            get => _mouseOverSound;
            set => _mouseOverSound = value;
        }

        public SoundEffect ClickConfirmSound
        {
            get => _clickConfirmSound;
            set => _clickConfirmSound = value;
        }

        public string Text { get; set; }

        #endregion

        #region Methods

        public Button(Texture2D texture, SpriteFont font)
            : base(texture)
        {
            _texture = texture;
            _font = font;
            PenColor = Color.White;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var colour = Color.White;



            if (_isHovering)
            {
                colour = Color.Gray;
            }

            spriteBatch.Draw(_texture, Rectangle, colour);

            if (!string.IsNullOrEmpty(Text))
            {
                var x = (Rectangle.X + (Rectangle.Width / 2)) - (_font.MeasureString(Text).X / 2);
                var y = (Rectangle.Y + (Rectangle.Height / 2)) - (_font.MeasureString(Text).Y / 2);

                spriteBatch.DrawString(_font, Text, new Vector2(x, y), PenColor);
            }
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {

            _previousMouse = _currentMouse;

            _currentMouse = Mouse.GetState();

            var mouseRectangle = new Rectangle(_currentMouse.X, _currentMouse.Y, 1, 1);

            _isHovering = false;

            if (mouseRectangle.Intersects(this.Rectangle))
            {
                _isHovering = true;

                if (_currentMouse.LeftButton == ButtonState.Released && _previousMouse.LeftButton == ButtonState.Pressed)
                {
                    _clickConfirmSound.Play();
                    Click?.Invoke(this, new EventArgs());
                }
            }
        }

        #endregion
    }
}
