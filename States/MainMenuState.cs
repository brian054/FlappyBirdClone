using FlappyBirdClone.Managers;
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
    internal class MainMenuState : IGameState
    {
        private readonly StateManager stateManager;
        private Texture2D backgroundTexture;
        private SpriteFont MainMenuFont;
        private Vector2 TitlePos;
        public Button PlayButton { get; private set; }
        public Button OptionsButton { get; private set; }
        public Button ExitButton { get; private set; }

        public MainMenuState(StateManager sm)
        {
            stateManager = sm;

            backgroundTexture = Globals.backgroundTexture;

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

            if (PlayButton.IsMouseHovering && MouseManager.LeftClicked())
            {
                stateManager.ChangeState(new PlayingState(stateManager));
            }
            //else if (OptionsButton.IsMouseHovering && MouseManager.LeftClicked())
            //{
            //    stateManager.ChangeState(new OptionsMenuState(stateManager));
            //}
            else if (ExitButton.IsMouseHovering && MouseManager.LeftClicked())
            {
                Environment.Exit(0);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgroundTexture, new Rectangle(0, 0, Globals.PreferredBackBufferWidth, Globals.PreferredBackBufferHeight),
                                                  new Rectangle(0, 0, Globals.PreferredBackBufferWidth, backgroundTexture.Height), Color.White);

            spriteBatch.DrawString(Globals.DefaultFont, "Flappy \n Bird!", TitlePos, Color.White);

            PlayButton.Draw(spriteBatch);
            OptionsButton.Draw(spriteBatch);
            ExitButton.Draw(spriteBatch);
        }

    }
}
