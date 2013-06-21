using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MLPTheMasterQuest.Engine
{
    /// <summary>
    /// Classe básica para as cenas, cada cena deve herdar de Scene.
    /// Scenes são carregadas pelo jogo e executadas na classe Game1.
    /// </summary>
    public abstract class Scene
    {
        protected Game1 game;

        public Scene(Game1 game)
        {
            this.game = game;
        }

        /// <summary>
        /// Carrega texturas para a cena, pixel shaders, etc.
        /// ContentManager: objeto que carrega conteúdo. Ex: Texture2D mapTexture = cm.Load<Texture2D>("textures/pixel");
        /// </summary>
        public abstract void LoadContent();

        /// <summary>
        /// Descarrega texturas, pixel shaders, etc.
        /// Ex: mapTexture.Dispose();
        /// </summary>
        public abstract void UnloadContent();

        /// <summary>
        /// Atualiza lógica do jogo
        /// </summary>
        /// <param name="gameTime"></param>
        public abstract void Update(GameTime gameTime);

        /// <summary>
        /// Atualiza os sprites na tela
        /// </summary>
        /// <param name="gameTime"></param>
        public abstract void Draw(GameTime gameTime);
    }
}
