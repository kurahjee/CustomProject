using CustomProject.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomProject.Managers
{
    public sealed class MovableSpriteManager
    {
        private static MovableSpriteManager _instance;
        private static readonly object _lock = new object();
        private List<MovableSprite> movableSprite = new List<MovableSprite>();

        public static MovableSpriteManager Instance
        {
            get
            {
                lock (_lock)
                {
                    if(_instance == null)
                    {
                        _instance = new MovableSpriteManager();
                    }
                    return _instance;
                }
            }
        }

        public List<MovableSprite> MovableSprites
        {
            get => movableSprite;
            set => movableSprite = value;
        }

        private MovableSpriteManager() { }
    }
}
