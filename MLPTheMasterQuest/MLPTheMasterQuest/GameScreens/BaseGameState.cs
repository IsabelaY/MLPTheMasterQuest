using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MLPTheMasterQuest.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace MLPTheMasterQuest.GameScreens
{
    public abstract partial class BaseGameState : GameState
    {
        protected Game1 GameRef;

        public BaseGameState(Game1 game, GameStateManager manager)
            : base(game, manager)
        {
            GameRef = game;
        }
    }
}
