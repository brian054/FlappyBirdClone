using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBirdClone
{
    public class PipeManager
    {
        private readonly List<Pipe> Pipes = []; // either 2 or 3 at a time, not sure yet, lets do 3
        private readonly Random rng = new();

        private float HorizontalSpacing = 180f;
        private int GapSize = 150; // gap between top and bottom pipes
        private int MinimumGapSize = 50; 

        public PipeManager() {
            // Create 3 pipes, spaced evenly
            var initialStartX = 400;
            for (int i = 0; i < 3; i++)
            {
                float startX = initialStartX + (i * HorizontalSpacing);
                Pipes.Add(new Pipe(startX, GapSize));
            }
        }

        public void Update(GameTime gameTime, int score)
        {
            // UpdateGapHeight(score)

            // this is where you call pipe.update, not in Game.1
            foreach (Pipe pipe in Pipes)
            {
                pipe.Update(gameTime);
            }

            // if the leftmost pipe goes off screen, move it accordingly
            if (Pipes[0].RightEdge < 0)
            {
                var leftmostPipe = Pipes[0]; // copying the reference here, not cloning the object, so when you modify this it changes the same Pipe obj.
                var rightmostPipe = Pipes[2];

                // calc new X position
                float newXPos = rightmostPipe.XPos + HorizontalSpacing;
                leftmostPipe.RecycleXPos(newXPos);

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
            int level = score / 15; // 15 points = level 1, 30 = level 2, etc.
            if (level > GapLevel)
            {
                GapLevel = level;
                GapSize = Math.Max(90, GapSize - 20); // adjust these
            }
        }
    }
}
