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
            flappy.Update(gameTime);
            if (!flappy.IsDead)
            {
                pipeManager.Update(gameTime, 2, flappy.IsDead); // draw score on screen asap (ScoreManager)
            }

            if (!flappy.IsDead && pipeManager.CheckCollision(flappy))
            {
                // game state = game over, 
                flappy.Die();
                System.Diagnostics.Debug.WriteLine("COLLISION!");
            }

            if (pipeManager.DidFlappyPassThroughPipe(flappy))
            {
                scoreBoard.IncreaseScore(1);
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
