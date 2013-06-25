using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MLPTheMasterQuest.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MLPTheMasterQuest.GameScreens
{
    public class StartMenuScreen : BaseGameState
    {
        public StartMenuScreen(Game1 game, GameStateManager manager)
            : base(game, manager)
        {
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            if (InputHandler.KeyReleased(Keys.Escape))
            {
                Game.Exit();
            }

            base.Update(gameTime);
        }
    }
}
