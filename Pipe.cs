using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;

namespace FlappyBirdClone
{
    // FIELD vs PROPERTY in C#
    //------------------------------------------------------------------------------------
    // A field is a private variable that stores the actual internal state of the class.
    // It is typically named with _camelCase (e.g., _bottomPosition).
    //
    // A property is a public-facing member that provides controlled access to data
    // through get/set accessors. Properties can expose a field, compute a value,
    // or enforce validation.
    //
    // In this class:
    // - Fields (_topPosition, _bottomPosition, etc.) store internal game state.
    // - Properties (TopRect, BottomRect) expose derived or read-only data safely.
    // ------------------------------------------------------------------------------------
    // Represents one pair of rectangles that Flappy fly's through
    public class Pipe
    {
        private int[] PipeHeights;

        // floor height = 575???? draw a line and find out where it is

        private readonly Random randomNum = new();

        public float XPos => _topPosition.X;
        private Vector2 _topPosition; // trying to follow the standard, _variable 

        private Vector2 _bottomPosition;

        private float Speed = 120f; 

        private Vector2 _topSize { get; set; } // where X = width, Y = height
        private const int _pipeWidth = 50;
        public Vector2 _bottomSize { get; private set; }

        // computed property - so every time you access RightEdge in PipeManager, C# calcualtes the value right there.
        public float RightEdge => _topPosition.X + _pipeWidth; // used to check if offscreen

        // Rects here are for drawing, collision. 
        // Not technically a public variable, it's a public property with only a getter, therefore outside of this
        // class you can read it (like in pipemanager for collision) but you cannot assign to it.
        public Rectangle TopRect =>
            new Rectangle(
                (int)MathF.Round(_topPosition.X),
                (int)MathF.Round(_topPosition.Y),
                (int)MathF.Round(_topSize.X),
                (int)MathF.Round(_topSize.Y)
            );
        public Rectangle BottomRect =>
           new Rectangle(
               (int)MathF.Round(_bottomPosition.X),
               (int)MathF.Round(_bottomPosition.Y),
               (int)MathF.Round(_bottomSize.X),
               (int)MathF.Round(_bottomSize.Y)
           );

        public Pipe(float startPosX, float gapSize)
        {
            _topPosition = new Vector2(startPosX, 0); // y is constant
            _topSize = new Vector2(_pipeWidth, randomNum.Next(90, 200)); 
            _bottomPosition = new Vector2(startPosX, _topSize.Y + gapSize);
            _bottomSize = new Vector2(_pipeWidth, Globals.FloorHeight - _topSize.Y - gapSize); 
        }

        public void Update(GameTime gameTime)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds; // the amount of time that has passed since last frame, in seconds.
            float dx = Speed * dt;

            _topPosition.X -= dx;
            _bottomPosition.X -= dx;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Globals.dummyTexture, TopRect, Color.Red);
            spriteBatch.Draw(Globals.dummyTexture, BottomRect, Color.Red);
        }

        // Scenario: Pipe goes off screen, this method repositions the pipes x position so we can recycle the pipe pair.
        public void RecycleXPos(float newXPos)
        {
            _topPosition.X = newXPos;
            _bottomPosition.X = newXPos;
        }

        //public void SetGap()
        //{

        //}
    }
}
