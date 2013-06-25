using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLPTheMasterQuest.Engine
{
    public class TileMap
    {
        public List<MapRow> Rows = new List<MapRow>();
        public int MapWidth;
        public int MapHeight;

        public TileMap(int width, int height)
        {
            MapWidth = width;
            MapHeight = height;

            for (int y = 0; y < MapHeight; y++)
            {
                MapRow thisRow = new MapRow();
                for (int x = 0; x < MapWidth; x++)
                {
                    thisRow.Columns.Add(new MapCell(0));
                }
                Rows.Add(thisRow);
            }
        }
    }
}
