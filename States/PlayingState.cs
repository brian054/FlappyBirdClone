using FlappyBirdClone.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBirdClone.States
{
    internal class PlayingState : IGameState
    {
        private readonly StateManager stateManager;
        private Texture2D backgroundTexture;
        private Flappy flappy;

        private PipeManager pipeManager;

        private ScoreManager scoreBoard;

        private bool gameOverTriggered = false;
        private bool gameOverMenuShown = false; // so we don't push the GameOverState every frame while flappy is on the ground, do only once!
        private float gameOverDelayTimer = 0f;
        private const float GameOverDelay = 0.5f;

        public PlayingState(StateManager sm)
        {
            stateManager = sm; 
            backgroundTexture = Globals.backgroundTexture;

            flappy = new();
            pipeManager = new PipeManager();
            scoreBoard = new ScoreManager();
        }

        public void Update(GameTime gameTime)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            flappy.Update(gameTime);
            if (!flappy.IsDead)
            {
                pipeManager.Update(gameTime, 2, flappy.IsDead); // draw score on screen asap (ScoreManager)

                if (pipeManager.CheckCollision(flappy))
                {
                    flappy.Die();
                    gameOverTriggered = true;
                }

                if (pipeManager.DidFlappyPassThroughPipe(flappy))
                {
                    scoreBoard.IncreaseScore(1);
                }
            } else
            {
                // if flappy hits the ground make sure we trigger gameOver.
                gameOverTriggered = true;
            }

            if (gameOverTriggered && flappy.HasHitGround && !gameOverMenuShown)
            {
                gameOverDelayTimer += dt;

                if (gameOverDelayTimer >= GameOverDelay)
                {
                    gameOverMenuShown = true;
                    stateManager.PushState(new GameOverState(stateManager));
                }
            }


            if (KeyboardManager.WasKeyPressed(Keys.Escape)) {
                stateManager.PushState(new PauseState(stateManager));
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgroundTexture, new Rectangle(0, 0, Globals.PreferredBackBufferWidth, Globals.PreferredBackBufferHeight),
                                                  new Rectangle(0, 0, Globals.PreferredBackBufferWidth, backgroundTexture.Height), Color.White);
            flappy.Draw(spriteBatch);
            pipeManager.Draw(spriteBatch);
            scoreBoard.Draw(spriteBatch);
        }
    }
}
