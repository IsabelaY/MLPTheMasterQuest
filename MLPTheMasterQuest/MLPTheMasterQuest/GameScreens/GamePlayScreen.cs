using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLPTheMasterQuest.Engine;
using Microsoft.Xna.Framework;

using MLPTheMasterQuest.Engine.TileEngine;
using Microsoft.Xna.Framework.Graphics;
using MLPTheMasterQuest.Engine.Components;

namespace MLPTheMasterQuest.GameScreens
{
    public class GamePlayScreen : BaseGameState
    {

        TileEngine engine = new TileEngine(32, 32);
        Tileset tileset;
        TileMap map;
        Player player;

        public GamePlayScreen(Game1 game, GameStateManager manager)
            : base(game, manager)
        {
            player = new Player(game);
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            Texture2D tilesetTexture = Game.Content.Load<Texture2D>(@"Textures\Tilesets\ponyville_tileset");
            tileset = new Tileset(tilesetTexture, 11, 8, 32, 32);

            tilesetTexture = Game.Content.Load<Texture2D>(@"Textures\Tilesets\example_tileset1");
            Tileset tileset1 = new Tileset(tilesetTexture, 8, 8, 32, 32);

            tilesetTexture = Game.Content.Load<Texture2D>(@"Textures\Tilesets\example_tileset2");
            Tileset tileset2 = new Tileset(tilesetTexture, 8, 8, 32, 32);

            List<Tileset> tilesets = new List<Tileset>();
            tilesets.Add(tileset1);
            tilesets.Add(tileset2);

            MapLayer layer = new MapLayer(40, 40);

            for (int y = 0; y < layer.Height; y++)
            {
                for (int x = 0; x < layer.Width; x++)
                {
                    Tile tile = new Tile(0, 0);

                    layer.SetTile(x, y, tile);
                }
            }

            MapLayer splatter = new MapLayer(40, 40);

            Random random = new Random();

            for (int i = 0; i < 80; i++)
            {
                int x = random.Next(0, 40);
                int y = random.Next(0, 40);
                int index = random.Next(2, 14);

                Tile tile = new Tile(index, 0);
                splatter.SetTile(x, y, tile);
            }

            splatter.SetTile(1, 0, new Tile(0, 1));
            splatter.SetTile(2, 0, new Tile(2, 1));
            splatter.SetTile(3, 0, new Tile(0, 1));

            List<MapLayer> mapLayers = new List<MapLayer>();
            mapLayers.Add(layer);
            mapLayers.Add(splatter);

            map = new TileMap(tilesets, mapLayers);

            map.AddLayer(splatter);

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            player.Update(gameTime);

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GameRef.spriteBatch.Begin(
                SpriteSortMode.Immediate,
                BlendState.AlphaBlend,
                SamplerState.PointClamp,
                null,
                null,
                null,
                Matrix.Identity);

            map.Draw(GameRef.spriteBatch, player.Camera);

            base.Draw(gameTime);
            GameRef.spriteBatch.End();
        }
    }
}
