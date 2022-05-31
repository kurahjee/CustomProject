using CustomProject.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CustomProject.Models;
using CustomProject.Entities.Characters;

namespace CustomProject.Entities.TileMap
{
    public class Map : GameObject
    {
        private string _fileName;

        private List<List<int>> _fileContent = new List<List<int>>() { };

        private StreamReader _fileReader;

        private readonly List<Tile> _tiles = new List<Tile>();

        private List<Texture2D> _tileTextures;

        private TileSet _tileSet;

        private SpriteFont _font;

        public Player Player { get; set; }

        public List<Tile> Tiles
        {
            get { return _tiles; }
        }

        public Map(string mapFileName, TileSet tileSet, SpriteFont font)
        {
            _fileName = mapFileName;
            _tileSet = tileSet;
            _fileName = mapFileName;
            _font = font;
        }

        public void LoadMapFile()
        {
            _fileReader = new StreamReader("Maps/" + _fileName);
            for (int x = 0; x < 10; x++)
            {
                string line = _fileReader.ReadLine();
                List<string> idString = line.Split(',').ToList();
                List<int> idInt = idString.Select(int.Parse).ToList();
                _fileContent.Add(idInt);
            }
            _tileTextures = _tileSet.TileSetTexture;

            for (int j = 0; j < 10; j++)
            {
                for (int i = 0; i < 15; i++)
                {
                    if (_fileContent[j][i] != 0)
                    {
                        Tile newTile = new Tile(_tileTextures[_fileContent[j][i] - 1]);
                        newTile.Position = new Vector2(i * 128, j * 128);
                        _tiles.Add(newTile);
                    }
                }
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (Tile tile in _tiles)
            {
                tile.Draw(gameTime, spriteBatch);
            }
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {

        }
    }
}
