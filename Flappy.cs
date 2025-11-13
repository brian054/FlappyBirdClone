using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Runtime.CompilerServices;
using System;

/*
 * I'll start linking the docs to stuff you can show in the tutorials:
 * Vector2: https://docs.monogame.net/api/Microsoft.Xna.Framework.Vector2.html
 * 
 * 
 */

namespace FlappyBirdClone
{
    public class Flappy
    {
        private Vector2 PreviousPosition { get; set; }
        private Vector2 Position; //{ get; set; } TODO: Look up field vs properties, using a field might be easier for teaching
        // since you wouldn't have to do Position = new Vector2(Position.X, calculation for Gravity Y position)
        // Performance wise it doesn't seem to really matter, I'd go with readability and simplicity over 'standard' especially for such a small game.
        // If this was your Player.cs class in Minicraft, then you'd wanna make this a property with a private set, public get.
        private Vector2 Size { get; set; } // where X = width, X = height

        // vertical velocity
        // maximum vertical velocity
        // bool isFlyingUp
        // const gravity

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
            Size = new Vector2(25, 24); // 34 x 24 pixels
            Position = new Vector2(Globals.PreferredBackBufferWidth / 2 - (Size.X / 2), Globals.PreferredBackBufferHeight / 3);
        }

        public void Update(GameTime gameTime)
        {
            // Add gravity
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds; // the amount of time that has passed since last frame, in seconds.
            PreviousPosition = Position;
            Position.Y += 250 * dt; // 250 pixels per second


            // If player clicked, move up a little
            // if input pressed to move bird, move the bird, maybe move gravity into else


            // end:

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Globals.dummyTexture, Position, FlappyRectangle, Color.Red);
        }

    }
}
