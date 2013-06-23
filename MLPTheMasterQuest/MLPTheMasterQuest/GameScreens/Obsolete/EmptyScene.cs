using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MLPTheMasterQuest.Scenes
{
    [Obsolete("Não mais usado", false)]
    public class EmptyScene : MLPTheMasterQuest.Engine.Scene
    {

        public EmptyScene(Game1 game) : base(game)
        {
        }

        public override void LoadContent()
        {
        }

        public override void UnloadContent()
        {
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
        }
    }
}
