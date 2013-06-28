using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLPTheMasterQuest.Engine.TileEngine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MLPTheMasterQuest.Engine.Components
{
    public class Player
    {
        Camera camera;
        Game1 gameRef;

        public Camera Camera
        {
            get { return camera; }
            set { camera = value; }
        }

        public Player(Game1 game)
        {
            gameRef = game;
            camera = new Camera(gameRef.ScreenRectangle);
        }

        public void Update(GameTime gameTime)
        {
            camera.Update(gameTime);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
        }
    }
}
