using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;

namespace FlappyBirdClone
{
    // Represents one pair of rectangles that Flappy fly's through
    public class Pipe
    {
        private int[] PipeHeights;

        // floor height = 575???? draw a line and find out where it is
       


            
        private Vector2 TopPosition; 
        private Vector2 BottomPosition;

        private float Speed = 120f; 

        private Vector2 TopSize { get; set; } // where X = width, Y = height
        private int PipeWidth = 50;
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
            TopSize = new Vector2(PipeWidth, 150); 
            BottomPosition = new Vector2(200, TopSize.Y + 150);
            BottomSize = new Vector2(PipeWidth, 100);

        }

        public void Update(GameTime gameTime)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds; // the amount of time that has passed since last frame, in seconds.
            float dx = Speed * dt;

            
            // remove this later, PipeManager will handle this type of thing
            if (TopPosition.X < -50)
            {
                TopPosition.X = 300;
                BottomPosition.X = 300;
            }

            TopPosition.X -= dx;
            BottomPosition.X -= dx;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Globals.dummyTexture, TopPosition, TopRect, Color.Red);
            spriteBatch.Draw(Globals.dummyTexture, BottomPosition, BottomRect, Color.Red);
            //spriteBatch.Draw(Globals.dummyTexture, BottomPosition, BottomRect, Color.Red); draw line to find floor height
        }

        public void SetGap()
        {

        }
    }
}
