using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using MLPTheMasterQuest.Engine.TileEngine;
using Microsoft.Xna.Framework.Graphics;

namespace MLPTheMasterQuest.Engine
{
    public static class TileMapLoader
    {
        public static MapLayer LoadTmx(string xmlFile)
        {
            XmlTextReader reader = new XmlTextReader(xmlFile);

            MapLayer map = null;

            while (reader.Read())
            {
                if (reader.Name.Equals("layer"))
                {
                    map = new MapLayer(Int32.Parse(reader.GetAttribute("width")), Int32.Parse(reader.GetAttribute("height")));
                    for (int i = 0; i < map.Height; i++)
                    {
                        for (int j = 0; j < map.Width; j++)
                        {
                            while (reader.Read())
                            {
                                if (reader.Name.Equals("tile"))
                                    break;
                            }
                            reader.MoveToContent();
                            map.SetTile(j, i, new Tile(Int32.Parse(reader.GetAttribute("gid")) - 1, 0));
                        }
                    }

                    break;
                }
            }

            reader.Close();

            return map;
        }
    }
}