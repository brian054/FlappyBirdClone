using FlappyBirdClone.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBirdClone.States
{
    internal class MainMenuState
    {
        private SpriteFont MainMenuFont;
        private Vector2 TitlePos;
        public Button PlayButton { get; private set; }
        public Button OptionsButton { get; private set; }
        public Button ExitButton { get; private set; }

        public MainMenuState()
        {
            int buttonWidth = 240;
            int centerX = Globals.PreferredBackBufferWidth / 2 - buttonWidth / 2;

            TitlePos = new Vector2(centerX + 50, 100);

            int buttonGroupCenterY = 200;

            PlayButton = new Button("Start", new Vector2(centerX, buttonGroupCenterY), buttonWidth, Color.RoyalBlue);
            OptionsButton = new Button("Options", new Vector2(centerX, buttonGroupCenterY + 100), buttonWidth, Color.MonoGameOrange);
            ExitButton = new Button("Quit", new Vector2(centerX, buttonGroupCenterY + 200), buttonWidth, Color.BlueViolet);
        }

        public void Update(GameTime gameTime) // gametime variable orrr??? I mean nothing here is time dependent soooo...TODO...look it up
        {
            PlayButton.Update();
            OptionsButton.Update();
            ExitButton.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(Globals.DefaultFont, "Flappy!", TitlePos, Color.White);

            PlayButton.Draw(spriteBatch);
            OptionsButton.Draw(spriteBatch);
            ExitButton.Draw(spriteBatch);
        }

    }
}
