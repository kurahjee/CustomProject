using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomProject.Models
{
    public class Animation
    {
        private Texture2D _texture;

        private int _currentFrame;

        private int _frameCount;

        private readonly int _frameHeight;

        private readonly int _frameWidth;

        private float _frameSpeed;

        private bool _isLooping;

        private Vector2 _position;

        public int CurrentFrame
        {
            get => _currentFrame;
            set => _currentFrame = value;
        }

        public int FrameCount
        {
            get => _frameCount;
        }

        public int FrameHeight { get { return _frameHeight; } }

        public int FrameWidth { get { return _frameWidth; } }

        public float FrameSpeed
        {
            get { return _frameSpeed; }
            set { _frameSpeed = value; }
        }

        public bool IsLooping
        {
            get => _isLooping;
            set => _isLooping = value;
        }

        public Vector2 Position
        {
            get => _position;
            set => _position = value;
        }

        public Texture2D Texture
        {
            get => _texture;
        }

        public Animation(Texture2D texture, int frameCount)
        {
            _texture = texture;

            _frameCount = frameCount;

            IsLooping = true;

            FrameSpeed = 0.2f;

            _frameHeight = _texture.Height;

            _frameWidth = _texture.Width / _frameCount;
        }
    }
}
