using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MLPTheMasterQuest.Engine;
using MLPTheMasterQuest.Engine.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MLPTheMasterQuest.GameScreens
{
    public abstract partial class BaseGameState : GameState
    {
        protected Game1 GameRef;

        protected ControlManager ControlManager;

        protected PlayerIndex playerIndexInControl;

        public BaseGameState(Game1 game, GameStateManager manager)
            : base(game, manager)
        {
            GameRef = game;

            playerIndexInControl = PlayerIndex.One;
        }

        protected override void LoadContent()
        {
            ContentManager Content = Game.Content;

            SpriteFont menuFont = Content.Load<SpriteFont>(@"Fonts\ControlFont");
            ControlManager = new ControlManager(menuFont);

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
