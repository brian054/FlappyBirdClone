using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Runtime.CompilerServices;
using System;

namespace FlappyBirdClone
{
    public class Flappy
    {
        public Vector2 Position { get; set; }
        public Vector2 Size { get; set; }
        public Rectangle FlappyRectangle =>
            new Rectangle(
                (int)MathF.Round(Position.X),
                (int)MathF.Round(Position.Y),
                (int)MathF.Round(Size.X),
                (int)MathF.Round(Size.Y)
            );

        public Flappy()
        {
            // Default positions: x = middle of screen, y = middle of screen, maybe 1/3 up screen
            Position = new Vector2(Globals.PreferredBackBufferWidth / 2, Globals.PreferredBackBufferHeight / 3);
            Size = new Vector2(25, 24); // 34 x 24 pixels
        }

        public void Update()
        {
            
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Globals.dummyTexture, Position, FlappyRectangle, Color.Red);
        }

    }
}
