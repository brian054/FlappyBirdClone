using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;

namespace FlappyBirdClone
{
    // Represents one pair of rectangles that Flappy fly's through
    public class Pipe
    {
        private int pipeWidth; // 80
        private int[] pipeHeights;

        // floor height = 575???? not sure with ours

        // need a gapsize and minimum gap size too
        private Vector2 TopPosition; 
        private Vector2 BottomPosition;

        private float Speed = 120f; // why does the monitor with higher hz make it all jittery??? investigate

        private Vector2 TopSize { get; set; } // where X = width, X = height
        private Vector2 BottomSize { get; set; }

        public Rectangle TopRect =>
            new Rectangle(
                (int)MathF.Round(TopPosition.X),
                (int)MathF.Round(TopPosition.Y),
                (int)MathF.Round(TopSize.X),
                (int)MathF.Round(TopSize.Y)
            );
        public Rectangle BottomRect =>
           new Rectangle(
               (int)MathF.Round(BottomPosition.X),
               (int)MathF.Round(BottomPosition.Y),
               (int)MathF.Round(BottomSize.X),
               (int)MathF.Round(BottomSize.Y)
           );

        public Pipe()
        {
            TopPosition = new Vector2(200, 0);
            BottomPosition = new Vector2(200, 300);
            TopSize = new Vector2(50, 150); 
            BottomSize = new Vector2(50, 100);

        }

        public void Update(GameTime gameTime)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds; // the amount of time that has passed since last frame, in seconds.
            float dx = Speed * dt;

            // is it integer related idfk 

            if (TopPosition.X < -50)
            {
                TopPosition.X = 200;
                BottomPosition.X = 200;
            }

            TopPosition.X -= dx;
            BottomPosition.X -= dx;

            //TopPosition.X -= Speed * dt;
            //BottomPosition.X -= Speed * dt;

            //TopRect.X -= Speed * dt;
            //BottomRect.X -= Speed * dt;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Globals.dummyTexture, TopPosition, TopRect, Color.Red);
            spriteBatch.Draw(Globals.dummyTexture, BottomPosition, BottomRect, Color.Red);
        }
    }
}
