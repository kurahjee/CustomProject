using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using CustomProject.Entities.TileMap;

namespace CustomProject.Models
{
    public class TileSet
    {
        #region Fields

        private int _tileWidthCount;

        private int _tileHeightCount;

        private GraphicsDevice _graphicsDevice;

        private List<Tile> _tiles = new List<Tile>();

        private List<Texture2D> _textureSet = new List<Texture2D>();

        #endregion

        #region Properties

        public int Width
        {
            get { return _tileWidthCount; }
            set { _tileWidthCount = value; }
        }

        public int Height
        {
            get { return _tileHeightCount; }
            set { _tileHeightCount = value; }
        }

        public int TileWidth
        {
            get { return Texture.Width / _tileWidthCount; }
        }

        public int TileHeight
        {
            get { return Texture.Height / _tileHeightCount; }
        }

        public Texture2D Texture { get; set; }

        public List<Tile> Tiles
        {
            get
            {

                _textureSet = LoadTileTextureFromTileSet();

                for (int i = 0; i < _textureSet.Count; i++)
                {
                    Tile newTile = new Tile(_textureSet[i]);
                    newTile.TileID = i + 1;
                    _tiles.Add(newTile);
                }

                return _tiles;
            }
        }

        public List<Texture2D> TileSetTexture
        {
            get
            {
                return LoadTileTextureFromTileSet();
            }
        }

        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>

        public TileSet(GraphicsDevice graphicsDevice, Texture2D texture, int size)
        {
            _tileWidthCount = size;
            _tileHeightCount = size;
            _graphicsDevice = graphicsDevice;
            Texture = texture;
        }

        private List<Texture2D> LoadTileTextureFromTileSet()
        {

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Rectangle defaultTileRectangle = new Rectangle(j * 128, i * 128, 128, 128);

                    Texture2D tileTexture = new Texture2D(_graphicsDevice, defaultTileRectangle.Width, defaultTileRectangle.Height);

                    Color[] data = new Color[defaultTileRectangle.Width * defaultTileRectangle.Height];

                    Texture.GetData(0, defaultTileRectangle, data, 0, data.Length);

                    tileTexture.SetData(data);

                    _textureSet.Add(tileTexture);
                }
            }

            return _textureSet;
        }

    }
}
