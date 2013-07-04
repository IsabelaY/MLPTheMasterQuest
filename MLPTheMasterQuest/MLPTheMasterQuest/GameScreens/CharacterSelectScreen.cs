using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLPTheMasterQuest.Engine.Controls;
using MLPTheMasterQuest.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MLPTheMasterQuest.GameScreens
{
    public class CharacterSelectScreen : BaseGameState
    {
        LeftRightSelector characterSelector;
        PictureBox backgroundImage;
        PictureBox characterImage;
        Texture2D[] characterImages;

        string[] characterItems = { "Rarity", "Carrot Top", "Cloudkicker" };

        public string SelectedCharacter
        {
            get { return characterSelector.SelectedItem; }
        }

        public CharacterSelectScreen(Game1 game, GameStateManager stateManager)
            : base(game, stateManager)
        {
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            LoadImages();
            CreateControls();
        }

        public override void Update(GameTime gameTime)
        {
            ControlManager.Update(gameTime, PlayerIndex.One);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GameRef.spriteBatch.Begin(
                SpriteSortMode.Immediate,
                BlendState.AlphaBlend,
                SamplerState.PointClamp,
                null,
                null,
                null,
                Matrix.Identity);

            base.Draw(gameTime);

            ControlManager.Draw(GameRef.spriteBatch);

            GameRef.spriteBatch.End();
        }

        private void CreateControls()
        {
            Texture2D leftTexture = Game.Content.Load<Texture2D>(@"Textures\Interface\left_arrow");
            Texture2D rightTexture = Game.Content.Load<Texture2D>(@"Textures\Interface\right_arrow");
            Texture2D stopTexture = Game.Content.Load<Texture2D>(@"Textures\Interface\stop_bar");

            backgroundImage = new PictureBox(
                Game.Content.Load<Texture2D>(@"Textures\Backgrounds\title_background"),
                GameRef.ScreenRectangle);
            ControlManager.Add(backgroundImage);

            Label label1 = new Label();
            label1.Text = "Select your character";
            label1.Size = label1.SpriteFont.MeasureString(label1.Text);
            label1.Position = new Vector2((GameRef.Window.ClientBounds.Width - label1.Size.X) / 2, 270);

            ControlManager.Add(label1);

            characterSelector = new LeftRightSelector(leftTexture, rightTexture, stopTexture);
            characterSelector.SetItems(characterItems, 250);
            characterSelector.Position = new Vector2(label1.Position.X, 320);
            characterSelector.SelectionChanged += new EventHandler(selection_Changed);

            ControlManager.Add(characterSelector);

            LinkLabel linkLabel1 = new LinkLabel();
            linkLabel1.Text = "Start.";
            linkLabel1.Position = new Vector2(label1.Position.X, 370);
            linkLabel1.Selected += new EventHandler(linkLabel1_Selected);

            ControlManager.Add(linkLabel1);

            characterImage = new PictureBox(
                characterImages[0],
                new Rectangle(50, 300, 80, 80),
                new Rectangle(0, 0, 40, 40));
            ControlManager.Add(characterImage);

            ControlManager.NextControl();
        }

        private void LoadImages()
        {
            characterImages = new Texture2D[characterItems.Length];

            for (int i = 0; i < characterItems.Length; i++)
            {
                characterImages[i] = Game.Content.Load<Texture2D>(@"Textures\Characters\Overworld\"+characterItems[i].Replace(" ", String.Empty).ToLower()+"_40x40_8");
            }
        }

        void linkLabel1_Selected(object sender, EventArgs e)
        {
            InputHandler.Flush();

            StateManager.PopState();
            StateManager.PushState(GameRef.GamePlayScreen);
        }

        void selection_Changed(object sender, EventArgs e)
        {
            characterImage.Image = characterImages[characterSelector.SelectedIndex];
        }
    }
}
