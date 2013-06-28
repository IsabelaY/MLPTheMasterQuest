/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MLPTheMasterQuest.Engine
{
    [Obsolete("Não utilize esta classe", false)]
    public static class TileMapLoader
    {
        public static TileEngine LoadTmx(string xmlFile)
        {
            XmlTextReader reader = new XmlTextReader(xmlFile);
            TileMap map = new TileMap(50, 50);

            while (reader.Read())
            {
                if (reader.Name.Equals("layer"))
                {
                    map = new TileMap(Int32.Parse(reader.GetAttribute("width")), Int32.Parse(reader.GetAttribute("height")));
                    for (int i = 0; i < map.MapHeight; i++)
                    {
                        for (int j = 0; j < map.MapWidth; j++)
                        {
                            while (reader.Read())
                            {
                                if (reader.Name.Equals("tile"))
                                    break;
                            }
                            reader.MoveToContent();
                            map.Rows[i].Columns[j].TileID = Int32.Parse(reader.GetAttribute("gid")) - 1;
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
*/