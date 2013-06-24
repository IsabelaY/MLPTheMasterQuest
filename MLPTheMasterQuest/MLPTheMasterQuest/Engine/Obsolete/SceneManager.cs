using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

using MLPTheMasterQuest.Scenes;
using Microsoft.Xna.Framework.Graphics;

namespace MLPTheMasterQuest.Engine
{
    /// <summary>
    /// Mantém uma lista de Scenes e atualiza de acordo com o necessário.
    /// 
    /// AVISO!!! DEPRECATED! FAVOR USAR GAMESTATE NO LUGAR!
    /// </summary>
    [Obsolete("Utilize GameStateManager", false)]
    public class SceneManager
    {
        private Dictionary<String, Scene> scenes = new Dictionary<string, Scene>();
        private HashSet<String> drawableScenes = new HashSet<String>();
        private HashSet<String> updatableScenes = new HashSet<String>();

        private Game1 game;

        public SceneManager(Game game)
        {
            this.game = (Game1)game;
        }

        public void LoadContentScene(String sceneName)
        {
            Scene s;
            if (scenes.TryGetValue(sceneName, out s))
            {
                s.LoadContent();
            }
        }

        public void LoadAllContent()
        {
            foreach (KeyValuePair<string, Scene> s in scenes)
            {
                s.Value.LoadContent();
            }
        }

        public void UnloadAllContent()
        {
            foreach (KeyValuePair<string, Scene> s in scenes)
            {
                s.Value.UnloadContent();
            }
        }

        public void UpdateActive(GameTime gameTime)
        {
            foreach (string s in updatableScenes)
            {
                scenes[s].Update(gameTime);
            }
        }

        public void DrawActive(GameTime gameTime)
        {
            foreach (string s in drawableScenes)
            {
                scenes[s].Draw(gameTime);
            }
        }

        public void AddScene(string name, Scene scene)
        {
            scenes[name] = scene;
            drawableScenes.Add(name);
            updatableScenes.Add(name);
        }

        public void AddAndLoadScene(string name, Scene scene)
        {
            scenes[name] = scene;
            scene.LoadContent();
            drawableScenes.Add(name);
            updatableScenes.Add(name);
        }

        public void DeactivateUpdatableScene(string name)
        {
            updatableScenes.Remove(name);
        }

        public void DeactivateDrawableScene(string name)
        {
            drawableScenes.Remove(name);
        }

        public void ActivateUpdatableScene(string name)
        {
            if (scenes.ContainsKey(name))
            {
                updatableScenes.Add(name);
            }
        }

        public void ActivateDrawableScene(string name)
        {
            if (scenes.ContainsKey(name))
            {
                drawableScenes.Add(name);
            }
        }

        public void RemoveScene(string name)
        {
            scenes.Remove(name);
            drawableScenes.Remove(name);
            updatableScenes.Remove(name);
        }
    }
}
