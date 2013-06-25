using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MLPTheMasterQuest.Engine
{
    static class Tile
    {
        static public Texture2D TileSetTexture;

        static public Rectangle GetSourceRectangle(int tileIndex)
        {
            int nX, nY;
            nX = TileSetTexture.Width / 32;
            nY = TileSetTexture.Height / 32;

            return new Rectangle((tileIndex % nX) * 32, (tileIndex / nX) * 32, 32, 32);
        }
    }
}
