using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLPTheMasterQuest.Engine;
using Microsoft.Xna.Framework;

using MLPTheMasterQuest.Engine.TileEngine;
using Microsoft.Xna.Framework.Graphics;

namespace MLPTheMasterQuest.GameScreens
{
    public class GamePlayScreen : BaseGameState
    {

        TileEngine engine = new TileEngine(32, 32);

        Tileset tileset;

        int[,] map;

        public GamePlayScreen(Game1 game, GameStateManager manager)
            : base(game, manager)
        {
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            Texture2D tilesetTexture = Game.Content.Load<Texture2D>(@"Textures\Tilesets\ponyville_tileset");
            tileset = new Tileset(tilesetTexture, 11, 8, 32, 32);

            map = new int[50, 50];

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
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

            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    GameRef.spriteBatch.Draw(
                        tileset.Texture,
                        new Rectangle(
                            x * TileEngine.TileWidth,
                            y * TileEngine.TileHeight,
                            TileEngine.TileWidth,
                            TileEngine.TileHeight),
                        tileset.SourceRectangles[map[y, x]],
                        Color.White);
                }
            }

            base.Draw(gameTime);
            GameRef.spriteBatch.End();
        }
    }
}
