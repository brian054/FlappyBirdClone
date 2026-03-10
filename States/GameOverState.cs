using FlappyBirdClone.Managers;
using FlappyBirdClone.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace FlappyBirdClone.States
{
    internal class GameOverState : IGameState
    {
        private readonly StateManager stateManager;

        public Button RestartButton { get; private set; }
        public Button QuitButton { get; private set; }

        private Rectangle gameOverPanel;

        // placeholder for now
        private int highScore = 10;

        private float panelY;
        private float targetPanelY;
        private float slideSpeed = 500f;

        private int panelWidth = 260;
        private int panelHeight = 180;

        public GameOverState(StateManager sm)
        {
            stateManager = sm;
            //highScore = score;

            int panelX = Globals.PreferredBackBufferWidth / 2 - panelWidth / 2;

            // start off-screen at bottom
            panelY = Globals.PreferredBackBufferHeight;
            targetPanelY = 140;

            gameOverPanel = new Rectangle(panelX, (int)panelY, panelWidth, panelHeight);

            int buttonWidth = 240; //140;
            int buttonX = Globals.PreferredBackBufferWidth / 2 - buttonWidth / 2;

            RestartButton = new Button(
                "Restart",
                new Vector2(buttonX, panelY + 95),
                buttonWidth,
                Color.Orange
            );

            QuitButton = new Button(
                "Quit",
                new Vector2(buttonX, panelY + 145),
                buttonWidth,
                Color.BlueViolet
            );
        }

        public void Update(GameTime gameTime)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            // slide panel upward
            if (panelY > targetPanelY)
            {
                panelY -= slideSpeed * dt;

                if (panelY <= targetPanelY)
                    panelY = targetPanelY;
            }

            gameOverPanel.Y = (int)panelY;

            // keep buttons attached to panel while it moves
            RestartButton.Position = new Vector2(
                Globals.PreferredBackBufferWidth / 2 - RestartButton.ButtonRect.Width / 2,
                panelY + 95
            );

            QuitButton.Position = new Vector2(
                Globals.PreferredBackBufferWidth / 2 - QuitButton.ButtonRect.Width / 2,
                panelY + 145
            );

            // only allow clicking after panel finishes moving
            if (panelY <= targetPanelY)
            {
                Debug.WriteLine("Update should be running....");

                RestartButton.Update();
                QuitButton.Update();

                if (RestartButton.IsMouseHovering && MouseManager.LeftClicked())
                {
                    stateManager.ChangeState(new PlayingState(stateManager));
                }
                else if (QuitButton.IsMouseHovering && MouseManager.LeftClicked())
                {
                    stateManager.ChangeState(new MainMenuState(stateManager));
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Globals.dummyTexture, gameOverPanel, Color.Black * 0.85f);

            spriteBatch.DrawString(
                Globals.DefaultFont,
                "GAME OVER",
                new Vector2(gameOverPanel.X + 15, gameOverPanel.Y + 20),
                Color.White
            );

            spriteBatch.DrawString(
                Globals.DefaultFont,
                $"High Score: {highScore}",
                new Vector2(gameOverPanel.X + 15, gameOverPanel.Y + 55),
                Color.Gold
            );

            RestartButton.Draw(spriteBatch);
            QuitButton.Draw(spriteBatch);
        }
    }
}
