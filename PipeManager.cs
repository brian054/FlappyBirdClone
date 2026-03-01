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
        private readonly List<Pipe> Pipes = []; // either 2 or 3 at a time, not sure yet
        private readonly Random rng = new();

        private int HorizontalSpacing = 250;
        private int GapHeight = 150; // gap between top and bottom pipes

        public PipeManager() {
            // create two pipe objects, store in Pipes, 

        }

        public void Update(GameTime gameTime, int score)
        {
            // UpdateGapHeight(score)

            // this is where you call pipe.update, not in Game.1

            // if the pipe goes off screen, move it accordingly
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // draw all Pipes[], foreach var p in Pipes, p.Draw()
        }

        private int GapLevel = 0; // as you go up in GapLevel, the gap shrinks
        private void UpdateGapHeight(int score)
        {
            int level = score / 15; // 15 points = level 1, 30 = level 2, etc.
            if (level > GapLevel)
            {
                GapLevel = level;
                GapHeight = Math.Max(90, GapHeight - 20); // adjust these
            }
        }
    }
}
