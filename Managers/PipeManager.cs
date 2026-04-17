using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace FlappyBirdClone.Managers
{
    public class PipeManager
    {
        private readonly List<Pipe> Pipes = []; // either 2 or 3 at a time, not sure yet, lets do 3
        private readonly Random rng = new();

        private float HorizontalSpacing = 180f;
        private int CurrentGapSize = 150; // gap between top and bottom pipes.....wait is this actually doing anything tho hold on
        private int MinimumGapSize = 50;

        public PipeManager() {

            // Create 3 pipes, spaced evenly
            var initialStartX = 400;
            for (int i = 0; i < 3; i++)
            {
                float startX = initialStartX + i * HorizontalSpacing;
                Pipes.Add(new Pipe(startX, CurrentGapSize));
            }
        }

        public void Update(GameTime gameTime, int score, bool IsDead)
        {
            UpdateGapHeight(score);

            Debug.WriteLine("CurrentGapSize: " + CurrentGapSize); // TODO: remove or comment out

            if (!IsDead)
            {
                foreach (Pipe pipe in Pipes)
                {
                    pipe.Update(gameTime);
                }
            }

            // if the leftmost pipe goes off screen, move it accordingly
            if (Pipes[0].RightEdge < 0)
            {
                // copying the reference here, not cloning the object, so when you modify this it changes the same Pipe obj.
                // do we just assume this, or should I add a check here to make sure? 
                // I guess I'm always removing at index 0, which should always be leftmost pipe, and add() adds to end so it'll always be 'right-most'
                var rightmostPipe = Pipes[2]; 

                float newXPos = rightmostPipe.XPos + HorizontalSpacing;
                var leftmostPipe = new Pipe(newXPos, CurrentGapSize);

                // rotate pipes
                Pipes.RemoveAt(0);
                Pipes.Add(leftmostPipe); 
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Pipe pipe in Pipes)
            {
                pipe.Draw(spriteBatch);
            }
        }

        private int GapLevel = 0; // as you go up in GapLevel, the gap shrinks
        private void UpdateGapHeight(int score)
        {
            int level = score / 2; // 15 points = level 1, 30 = level 2, etc.
            if (level > GapLevel)
            {
                GapLevel = level;
                CurrentGapSize = Math.Max(70, CurrentGapSize - 20); // adjust these
            }
        }

        public bool CheckCollision(Flappy theBird) { // just pass the rectangle instead......
            foreach (var pipe in Pipes)
            {
                if (pipe.TopRect.Intersects(theBird.FlappyRectangle) ||
                    pipe.BottomRect.Intersects(theBird.FlappyRectangle))
                {
                    return true;
                }
            }

            return false;
        }

        public bool DidFlappyPassThroughPipe(Flappy theBird)
        {
            foreach (Pipe pipe in Pipes)
            {
                if (!pipe.HasBeenPassedThrough && theBird.FlappyRectangle.Center.X > pipe.CenterX)
                {
                    pipe.HasBeenPassedThrough = true;
                    return true;
                }
            }
            return false;
        }
    }
}
