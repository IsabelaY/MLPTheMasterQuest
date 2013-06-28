using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLPTheMasterQuest.Engine.TileEngine
{
    public class Tile
    {
        int tileIndex;
        int tileset;

        public int TileIndex
        {
            get { return tileIndex; }
            private set { tileIndex = value; }
        }

        public int Tileset
        {
            get { return tileset; }
            private set { tileset = value; }
        }

        public Tile(int tileIndex, int tileset)
        {
            TileIndex = tileIndex;
            Tileset = tileset;
        }
    }
}
