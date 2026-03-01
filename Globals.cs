using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBirdClone
{
    public static class Globals
    {
        public const int PreferredBackBufferWidth = 288;
        public const int PreferredBackBufferHeight = 512;

        public static Texture2D dummyTexture;

        public static readonly Random Random = new Random();

        public static SpriteFont DefaultFont;

        public const int FloorHeight = 400; // the yPos of the ground

    }
}
