using FlappyBirdClone.Managers;
using FlappyBirdClone.States;
using FlappyBirdClone.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using static FlappyBirdClone.Globals;

namespace FlappyBirdClone
{
    /*
     * TODO:
     * - Replace rects with textures (last thing)
     * - Add game over pop up, quit to menu option, or restart
     * - Add high score to game over pop up, persist it somehow
     * - Upgrade Menu Screen after adding textures
     * - reduce gapSize based on score
     *
     */

    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        //private Flappy flappy;

        private StateManager stateManager;

        //private PipeManager pipeManager;

        //private ScoreManager scoreBoard;

        //private MainMenuState mainMenu;

        MouseState currMouse;
        MouseState prevMouse; // move out to state manager?
        bool playButtonClicked = false;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = Globals.PreferredBackBufferWidth;
            graphics.PreferredBackBufferHeight = Globals.PreferredBackBufferHeight;
            graphics.SynchronizeWithVerticalRetrace = true;
            graphics.ApplyChanges();

            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            Window.Title = "Flappy Bird Clone!";
            Window.AllowUserResizing = false;

            this.IsFixedTimeStep = true; // TODO: confirm if true by default
            this.TargetElapsedTime = TimeSpan.FromSeconds(1.0 / 60.0); // 60 updates per second
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Globals.dummyTexture = new Texture2D(GraphicsDevice, 1, 1);
            Globals.dummyTexture.SetData(new[] { Color.White });
            Globals.DefaultFont = Content.Load<SpriteFont>("ScoreBoardFont");

            Globals.backgroundTexture = Content.Load<Texture2D>("background");

            stateManager = new();
            stateManager.ChangeState(new MainMenuState(stateManager));
        }

        protected override void Update(GameTime gameTime)
        {
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //    Exit();

            KeyboardManager.Update();
            MouseManager.Update();

            stateManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
           // GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            //switch (CurrentGameState)
            //{
            //    case Globals.GameState.MainMenu:
            //        // do 
            //        mainMenu.Draw(spriteBatch);
            //        break;
            //    case Globals.GameState.Playing:
            //        DrawPlaying(spriteBatch);
            //        break;
            //}

            stateManager.Draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }

        //private void UpdatePlaying(GameTime gameTime)
        //{
        //    // Playing Game State
        //    flappy.Update(gameTime);
        //    if (!flappy.IsDead)
        //    {
        //        pipeManager.Update(gameTime, 2, flappy.IsDead); // draw score on screen asap (ScoreManager)
        //    }

        //    if (!flappy.IsDead && pipeManager.CheckCollision(flappy))
        //    {
        //        // game state = game over, 
        //        flappy.Die();
        //        System.Diagnostics.Debug.WriteLine("COLLISION!");
        //    }

        //    if (pipeManager.DidFlappyPassThroughPipe(flappy))
        //    {
        //        scoreBoard.IncreaseScore(1);
        //    }

        //    // ------------------------------
        //}

        //private void DrawPlaying(SpriteBatch spriteBatch)
        //{
        //    spriteBatch.Draw(backgroundTexture, new Rectangle(0, 0, Globals.PreferredBackBufferWidth, Globals.PreferredBackBufferHeight),
        //                                          new Rectangle(0, 0, Globals.PreferredBackBufferWidth, backgroundTexture.Height), Color.White);
        //    flappy.Draw(spriteBatch);
        //    pipeManager.Draw(spriteBatch);
        //    scoreBoard.Draw(spriteBatch);
        //}

        //private void DrawGameOver(SpriteBatch spriteBatch)
        //{

        //}

        //private bool IsButtonClicked()
        //{
        //    return (currMouse.LeftButton == ButtonState.Pressed && prevMouse.LeftButton == ButtonState.Released);
        //}
    }
}
