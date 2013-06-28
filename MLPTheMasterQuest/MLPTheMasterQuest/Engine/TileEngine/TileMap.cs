using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MLPTheMasterQuest.Engine.TileEngine
{
    public class TileMap
    {
        List<Tileset> tilesets;
        List<MapLayer> mapLayers;

        static int mapWidth;
        static int mapHeight;

        public static int WidthInPixels
        {
            get { return mapWidth * TileEngine.TileWidth; }
        }

        public static int HeightInPixels
        {
            get { return mapHeight * TileEngine.TileHeight; }
        }

        public TileMap(List<Tileset> tilesets, List<MapLayer> layers)
        {
            this.tilesets = tilesets;
            this.mapLayers = layers;

            mapWidth = mapLayers[0].Width;
            mapHeight = mapLayers[0].Height;

            for (int i = 1; i < layers.Count; i++)
            {
                if (mapWidth != mapLayers[i].Width || mapHeight != mapLayers[i].Height)
                    throw new Exception("Map layer size exception");
            }
        }

        public TileMap(Tileset tileset, MapLayer layer)
        {
            tilesets = new List<Tileset>();
            tilesets.Add(tileset);

            mapLayers = new List<MapLayer>();
            mapLayers.Add(layer);

            mapWidth = mapLayers[0].Width;
            mapHeight = mapLayers[0].Height;
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            Rectangle destination = new Rectangle(0, 0, TileEngine.TileWidth, TileEngine.TileHeight);
            Tile tile;

            foreach (MapLayer layer in mapLayers)
            {
                for (int y = 0; y < layer.Height; y++)
                {
                    destination.Y = y * TileEngine.TileHeight - (int)camera.Position.Y;

                    for (int x = 0; x < layer.Width; x++)
                    {
                        tile = layer.GetTile(x, y);

                        if (tile.TileIndex == -1 || tile.Tileset == -1)
                            continue;

                        destination.X = x * TileEngine.TileWidth - (int)camera.Position.X;

                        spriteBatch.Draw(
                            tilesets[tile.Tileset].Texture,
                            destination,
                            tilesets[tile.Tileset].SourceRectangles[tile.TileIndex],
                            Color.White);
                    }
                }
            }
        }

        public void AddLayer(MapLayer layer)
        {
            if (layer.Width != mapWidth || layer.Height != mapHeight)
                throw new Exception("Map layer size exception");

            mapLayers.Add(layer);
        }
    }
}
