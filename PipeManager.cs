using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBirdClone
{
    public class PipeManager
    {
        private readonly List<Pipe> Pipes = []; 
        private readonly Random rng = new();

        // shorter names?
        private int HorizontalSpacing = 250;
        private int GapHeight = 150; // gap between top and bottom pipes

        public PipeManager() { }

        private void SetGapBetweenPipes(int score)
        {
            // set gap sizes based on score, do it at a fixed rate
            if (score % 15 == 0)
            {
                // pipes[0], pipes[1] .SetGapSize()
            }
        }
    }
}
