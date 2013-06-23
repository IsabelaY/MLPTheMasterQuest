using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MLPTheMasterQuest.Engine;
using Microsoft.Xna.Framework.Input;

namespace MLPTheMasterQuest.GameScreens
{
    public class MapOverviewScreen : BaseGameState
    {
        public int PixelPerHeight { get; set; }
        public Vector2 camera;
        TileMap map = new TileMap();

        public MapOverviewScreen(Game1 game, GameStateManager manager, int pixelPerHeigth)
            : this(game, manager, pixelPerHeigth, new Vector2(0))
        {
        }

        public MapOverviewScreen(Game1 game, GameStateManager manager, int pixelPerHeigth, Vector2 cameraPos)
            : base(game, manager)
        {
            PixelPerHeight = pixelPerHeigth;
            camera = cameraPos;
        }

        protected override void  LoadContent()
        {
            Tile.TileSetTexture = GameRef.Content.Load<Texture2D>("Textures/Map/ff_sample_tileset");

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Left))
            {
                camera.X = MathHelper.Clamp(camera.X - 2, 0, (map.MapWidth - 20) * 32);
            }

            if (ks.IsKeyDown(Keys.Right))
            {
                camera.X = MathHelper.Clamp(camera.X + 2, 0, (map.MapWidth - 20) * 32);
            }

            if (ks.IsKeyDown(Keys.Up))
            {
                camera.Y = MathHelper.Clamp(camera.Y - 2, 0, (map.MapHeight - 20) * 32);
            }

            if (ks.IsKeyDown(Keys.Down))
            {
                camera.Y = MathHelper.Clamp(camera.Y + 2, 0, (map.MapHeight - 20) * 32);
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch spriteBatch = GameRef.spriteBatch;

            spriteBatch.Begin();

            Vector2 firstSquare = new Vector2(camera.X / 32, camera.Y / 32);
            int firstX = (int)firstSquare.X;
            int firstY = (int)firstSquare.Y;

            Vector2 squareOffset = new Vector2(camera.X % 32, camera.Y % 32);
            int offsetX = (int)squareOffset.X;
            int offsetY = (int)squareOffset.Y;

            for (int y = 0; y < 20; y++)
            {
                for (int x = 0; x < 20; x++)
                {
                    spriteBatch.Draw(
                        Tile.TileSetTexture,
                        new Rectangle((x * 32) - offsetX, (y * 32) - offsetY, 32, 32),
                        Tile.GetSourceRectangle(map.Rows[y + firstY].Columns[x + firstX].TileID),
                        Color.White);
                }
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}