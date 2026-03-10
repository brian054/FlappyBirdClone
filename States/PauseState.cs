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
    internal class PauseState : IGameState
    {
        private readonly StateManager stateManager;
        public Button RestartButton { get; private set; }
        public Button ResumeButton { get; private set; }
        public Button ExitButton { get; private set; }

        public PauseState(StateManager sm)
        {
            stateManager = sm;

            int buttonWidth = 240;
            int centerX = Globals.PreferredBackBufferWidth / 2 - buttonWidth / 2;

            int buttonGroupCenterY = 200;

            ResumeButton = new Button("Resume", new Vector2(centerX, buttonGroupCenterY), buttonWidth, Color.Orange);
            RestartButton = new Button("Restart", new Vector2(centerX, buttonGroupCenterY + 100), buttonWidth, Color.RoyalBlue);
            ExitButton = new Button("Quit", new Vector2(centerX, buttonGroupCenterY + 200), buttonWidth, Color.BlueViolet);
        }

        public void Update(GameTime gameTime) 
        {
            RestartButton.Update();
            ExitButton.Update();

            if (ResumeButton.IsMouseHovering && MouseManager.LeftClicked())
            {
                stateManager.PopState();
            }
            else if (RestartButton.IsMouseHovering && MouseManager.LeftClicked())
            {
                stateManager.ChangeState(new PlayingState(stateManager));
            } 
            else if (ExitButton.IsMouseHovering && MouseManager.LeftClicked())
            {
                stateManager.ChangeState(new MainMenuState(stateManager));
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            RestartButton.Draw(spriteBatch);
            ExitButton.Draw(spriteBatch);
        }

    }
}
