using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLPTheMasterQuest.Engine;
using Microsoft.Xna.Framework;

using MLPTheMasterQuest.Engine.TileEngine;
using Microsoft.Xna.Framework.Graphics;
using MLPTheMasterQuest.Engine.Components;
using MLPTheMasterQuest.Engine.Sprites;
using Microsoft.Xna.Framework.Input;

namespace MLPTheMasterQuest.GameScreens
{
    public class GamePlayScreen : BaseGameState
    {

        TileEngine engine = new TileEngine(16, 16);
        Tileset tileset;
        TileMap map;
        Player player;
        AnimatedSprite sprite;

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
            Texture2D spriteSheet = Game.Content.Load<Texture2D>(@"Textures\Characters\Overworld\" + GameRef.CharacterSelectScreen.SelectedCharacter.Replace(" ", String.Empty).ToLower() + "_20x20_8");
            Dictionary<AnimationKey, Animation> animations = new Dictionary<AnimationKey, Animation>();

            Animation animation = new Animation(2, 20, 20, 0, 0);
            animations.Add(AnimationKey.Down, animation);

            animation = new Animation(2, 20, 20, 0, 20);
            animations.Add(AnimationKey.Left, animation);

            animation = new Animation(2, 20, 20, 0, 40);
            animations.Add(AnimationKey.Right, animation);

            animation = new Animation(2, 20, 20, 0, 60);
            animations.Add(AnimationKey.Up, animation);

            sprite = new AnimatedSprite(spriteSheet, animations);

            Texture2D tilesetTexture = Game.Content.Load<Texture2D>(@"Textures\Tilesets\ponyville_tileset");
            tileset = new Tileset(tilesetTexture, 11, 9, 16, 16);

            tilesetTexture = Game.Content.Load<Texture2D>(@"Textures\Tilesets\example_tileset1");
            Tileset tileset1 = new Tileset(tilesetTexture, 8, 8, 16, 16);

            tilesetTexture = Game.Content.Load<Texture2D>(@"Textures\Tilesets\example_tileset2");
            Tileset tileset2 = new Tileset(tilesetTexture, 8, 8, 16, 16);

            List<Tileset> tilesets = new List<Tileset>();
            tilesets.Add(tileset);
            tilesets.Add(tileset1);
            tilesets.Add(tileset2);

            MapLayer layer = TileMapLoader.LoadTmx(@"Content\Maps\ponyville.xml");

            List<MapLayer> mapLayers = new List<MapLayer>();
            mapLayers.Add(layer);

            map = new TileMap(tilesets, mapLayers);

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            player.Update(gameTime);
            sprite.Update(gameTime);

            Vector2 motion = new Vector2();

            if (InputHandler.KeyReleased(Keys.D1))
            {
                Dictionary<AnimationKey, Animation> animations = new Dictionary<AnimationKey, Animation>();
                Animation animation = new Animation(2, 20, 20, 0, 0);
                animations.Add(AnimationKey.Down, animation);

                animation = new Animation(2, 20, 20, 0, 20);
                animations.Add(AnimationKey.Left, animation);

                animation = new Animation(2, 20, 20, 0, 40);
                animations.Add(AnimationKey.Right, animation);

                animation = new Animation(2, 20, 20, 0, 60);
                animations.Add(AnimationKey.Up, animation);

                sprite = new AnimatedSprite(Game.Content.Load<Texture2D>(@"Textures\Characters\Overworld\rarity_20x20_8"), animations);
                player.Camera.LockToSprite(sprite);
            }
            if (InputHandler.KeyReleased(Keys.D2))
            {
                Dictionary<AnimationKey, Animation> animations = new Dictionary<AnimationKey, Animation>();
                Animation animation = new Animation(2, 20, 20, 0, 0);
                animations.Add(AnimationKey.Down, animation);

                animation = new Animation(2, 20, 20, 0, 20);
                animations.Add(AnimationKey.Left, animation);

                animation = new Animation(2, 20, 20, 0, 40);
                animations.Add(AnimationKey.Right, animation);

                animation = new Animation(2, 20, 20, 0, 60);
                animations.Add(AnimationKey.Up, animation);

                sprite = new AnimatedSprite(Game.Content.Load<Texture2D>(@"Textures\Characters\Overworld\cloudkicker_20x20_8"), animations);
                player.Camera.LockToSprite(sprite);
            }
            if (InputHandler.KeyReleased(Keys.D3))
            {
                Dictionary<AnimationKey, Animation> animations = new Dictionary<AnimationKey, Animation>();
                Animation animation = new Animation(2, 20, 20, 0, 0);
                animations.Add(AnimationKey.Down, animation);

                animation = new Animation(2, 20, 20, 0, 20);
                animations.Add(AnimationKey.Left, animation);

                animation = new Animation(2, 20, 20, 0, 40);
                animations.Add(AnimationKey.Right, animation);

                animation = new Animation(2, 20, 20, 0, 60);
                animations.Add(AnimationKey.Up, animation);

                sprite = new AnimatedSprite(Game.Content.Load<Texture2D>(@"Textures\Characters\Overworld\carrottop_20x20_8"), animations);
                player.Camera.LockToSprite(sprite);
            }

            if (InputHandler.KeyReleased(Keys.PageUp) ||
                InputHandler.ButtonReleased(Buttons.LeftShoulder, PlayerIndex.One))
                player.Camera.ZoomIn();
            else if (InputHandler.KeyReleased(Keys.PageDown) ||
                InputHandler.ButtonReleased(Buttons.RightShoulder, PlayerIndex.One))
                player.Camera.ZoomOut();

            if (InputHandler.KeyDown(Keys.W) ||
                InputHandler.ButtonDown(Buttons.LeftThumbstickUp, PlayerIndex.One))
            {
                sprite.CurrentAnimation = AnimationKey.Up;
                motion.Y = -1;
            }
            else if (InputHandler.KeyDown(Keys.S) ||
                InputHandler.ButtonDown(Buttons.LeftThumbstickDown, PlayerIndex.One))
            {
                sprite.CurrentAnimation = AnimationKey.Down;
                motion.Y = 1;
            }

            if (InputHandler.KeyDown(Keys.A) ||
                InputHandler.ButtonDown(Buttons.LeftThumbstickLeft, PlayerIndex.One))
            {
                sprite.CurrentAnimation = AnimationKey.Left;
                motion.X = -1;
            }
            else if (InputHandler.KeyDown(Keys.D) ||
                InputHandler.ButtonDown(Buttons.LeftThumbstickRight, PlayerIndex.One))
            {
                sprite.CurrentAnimation = AnimationKey.Right;
                motion.X = 1;
            }

            if (motion != Vector2.Zero)
            {
                sprite.IsAnimating = true;
                motion.Normalize();
                sprite.Position += motion * sprite.Speed;
                sprite.LockToMap();

                if (player.Camera.CameraMode == CameraMode.Follow)
                    player.Camera.LockToSprite(sprite);
            }
            else
            {
                sprite.IsAnimating = false;
            }

            if (InputHandler.KeyReleased(Keys.F) ||
                InputHandler.ButtonReleased(Buttons.RightStick, PlayerIndex.One))
            {
                player.Camera.ToggleCameraMode();
                if (player.Camera.CameraMode == CameraMode.Follow)
                    player.Camera.LockToSprite(sprite);
            }

            if (player.Camera.CameraMode != CameraMode.Follow)
            {
                if (InputHandler.KeyReleased(Keys.C) ||
                    InputHandler.ButtonReleased(Buttons.LeftStick, PlayerIndex.One))
                {
                    player.Camera.LockToSprite(sprite);
                }
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GameRef.spriteBatch.Begin(
                SpriteSortMode.Deferred,
                BlendState.AlphaBlend,
                SamplerState.PointClamp,
                null,
                null,
                null,
                player.Camera.Transformation * GameRef.SpriteScale);


            map.Draw(GameRef.spriteBatch, player.Camera);
            sprite.Draw(gameTime, GameRef.spriteBatch, player.Camera);

            base.Draw(gameTime);
            GameRef.spriteBatch.End();
        }
    }
}
