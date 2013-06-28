using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MLPTheMasterQuest.Engine.TileEngine
{
    public class TileEngine
    {
        static int tileWidth;
        static int tileHeight;

        public static int TileWidth
        {
            get { return tileWidth; }
        }

        public static int TileHeight
        {
            get { return tileHeight; }
        }

        public TileEngine(int tileWidth, int tileHeight)
        {
            TileEngine.tileWidth = tileWidth;
            TileEngine.tileHeight = tileHeight;
        }

        public static Point VectorToCell(Vector2 position)
        {
            return new Point((int)position.X / tileWidth, (int)position.Y / tileHeight);
        }
    }
}
