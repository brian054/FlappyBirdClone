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

        public const int FloorHeight = 420; // the yPos of the ground

        public enum GameState { MainMenu, Playing } // MainMenu - substates { Options menu }, Playing State - substates: Pause (transparent overlay), Game Over (Just a popup to reset or go to main menu)

        // since these are just UI popups I figured I'd separate.
        public enum OverlayState { None, Options, Pause, GameOver }
    }
}
