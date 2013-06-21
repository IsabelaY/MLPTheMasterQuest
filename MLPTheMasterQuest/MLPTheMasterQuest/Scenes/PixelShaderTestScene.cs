using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace MLPTheMasterQuest.Scenes
{
    public class PixelShaderTestScene : MLPTheMasterQuest.Engine.Scene
    {
        Texture2D grid;
        EffectParameter waveParam, distortionParam, centerCoordParam;
        RenderTarget2D ShaderRenderTarget;
        Texture2D ShaderTexture;
        Effect ripple;

        public PixelShaderTestScene(Game1 game) : base(game)
        {
        }

        public override void LoadContent()
        {
            ContentManager cm = game.Content;
            GraphicsDeviceManager graphics = game.graphics;

            ripple = cm.Load<Effect>("Effects/ripple");
            grid = cm.Load<Texture2D>("Textures/obsolete");
            waveParam = ripple.Parameters["wave"];
            distortionParam = ripple.Parameters["distortion"];
            centerCoordParam = ripple.Parameters["centerCoord"];

            ShaderRenderTarget = new RenderTarget2D(graphics.GraphicsDevice, graphics.GraphicsDevice.PresentationParameters.BackBufferWidth, graphics.GraphicsDevice.PresentationParameters.BackBufferHeight,
                true, graphics.GraphicsDevice.PresentationParameters.BackBufferFormat, DepthFormat.None, graphics.GraphicsDevice.PresentationParameters.MultiSampleCount, RenderTargetUsage.PreserveContents);
            Reset();

            ShaderTexture = new Texture2D(graphics.GraphicsDevice, ShaderRenderTarget.Width, ShaderRenderTarget.Height,
                true, graphics.GraphicsDevice.PresentationParameters.BackBufferFormat);
        }

        Vector2 centerCoord = new Vector2(0.5f);
        float distortion = 1.0f;
        float divisor = 0.75f;
        float wave = MathHelper.Pi;
        float dist_speed = 0.1f;
        private void Reset()
        {
            centerCoord = new Vector2(0.5f);
            distortion = 1.0f;
            divisor = 0.75f;
            wave = MathHelper.Pi / divisor;
        }

        public override void UnloadContent()
        {
            grid.Dispose();
            ripple.Dispose();
        }

        public override void Update(GameTime gameTime)
        {
            // Allows the default game to exit on Xbox 360 and Windows.
            GamePadState state = GamePad.GetState(PlayerIndex.One);

            // Reset.
            if (state.Buttons.Start == ButtonState.Pressed)
            {
                Reset();
            }

            float seconds = (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Move the center.
            centerCoord.X = MathHelper.Clamp(centerCoord.X +
                (state.ThumbSticks.Right.X * seconds * 0.5f),
                0, 1);
            centerCoord.Y = MathHelper.Clamp(centerCoord.Y -
                (state.ThumbSticks.Right.Y * seconds * 0.5f),
                0, 1);

            // Change the distortion.
            distortion += state.ThumbSticks.Left.X * seconds * 0.5f;

            // Change the period.
            divisor += dist_speed * seconds * 0.5f;

            if (divisor >= 1 || divisor <= -1)
                dist_speed *= -1;

            //wave = MathHelper.Pi / divisor;
            wave = MathHelper.Pi / divisor;
            waveParam.SetValue(wave);
            distortionParam.SetValue(distortion);
            centerCoordParam.SetValue(centerCoord);
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDeviceManager graphics = game.graphics;
            SpriteBatch sb = game.spriteBatch;

            graphics.GraphicsDevice.SetRenderTarget(ShaderRenderTarget);

            graphics.GraphicsDevice.Clear(Color.Black);
            // Render a simple scene.
            sb.Begin();
            TileSprite(sb, grid, graphics);
            sb.End();

            // Change back to the back buffer, and get our scene
            // as a texture.
            ShaderTexture = (Texture2D)ShaderRenderTarget;
            graphics.GraphicsDevice.SetRenderTarget(null);

            // Use Immediate mode and our effect to draw the scene
            // again, using our pixel shader.
            sb.Begin(SpriteSortMode.Immediate, BlendState.Opaque);
            ripple.CurrentTechnique.Passes[0].Apply();
            sb.Draw(ShaderTexture, Vector2.Zero, Color.White);
            //ripple.CurrentTechnique.Passes[0].Apply();
            sb.End();
        }

        private void TileSprite(SpriteBatch batch, Texture2D texture, GraphicsDeviceManager graphics)
        {
            Vector2 pos = Vector2.Zero;
            for (int i = 0; i < graphics.GraphicsDevice.Viewport.Height; i += texture.Height)
            {
                for (int j = 0; j < graphics.GraphicsDevice.Viewport.Width; j += texture.Width)
                {
                    pos.X = j; pos.Y = i;
                    batch.Draw(texture, pos, Color.White);
                }
            }
        }
    }
}
