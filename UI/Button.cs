using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBirdClone.UI
{
    // TODO: make this more generic so we can use it in the future
    // How? do height and width, not a vector2, m
    internal class Button
    {
        private SpriteFont ButtonFont;

        private string ButtonText;

        public Point Size;
        public Vector2 Position;

        //public float Width => Size.X;
        //public float Height => Size.Y;

        MouseState mouse;
        public bool IsMouseHovering { get; private set; }

        private const float AspectRatio = 3f; // width : height

        private Color ButtonColor;

        private Vector2 textPosition;
        private Vector2 textSize;

        public Rectangle ButtonRect =>
            new Rectangle(
                (int)Position.X,
                (int)Position.Y,
                Size.X,
                Size.Y
            );

        public Button(string buttonText, Vector2 buttonPos, int buttonWidth, Color buttonColor)
        {
            ButtonText = buttonText;
            ButtonColor = buttonColor;
            Position = buttonPos;
            Size = new Point(buttonWidth, (int)(buttonWidth / AspectRatio));
            //ButtonWidth = buttonWidth;
            //ButtonHeight = (int)(ButtonWidth / AspectRatio);

            float centerX = Position.X + Size.X / 2f;
            float centerY = Position.Y + Size.Y / 2f;

            textPosition = new Vector2(centerX - textSize.X / 2f, centerY - textSize.Y / 2f);
            textSize = Globals.DefaultFont.MeasureString(ButtonText);

        }

        public void Update()
        {
            mouse = Mouse.GetState();

            Point mousePos = new Point(mouse.X, mouse.Y);

            if (ButtonRect.Contains(mousePos))
            {
                IsMouseHovering = true;
            }
            else
            {
                IsMouseHovering = false;
            }
            
            UpdateTextPosition();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Globals.dummyTexture, ButtonRect, ButtonColor);
            if (IsMouseHovering)
            {
                spriteBatch.Draw(Globals.dummyTexture, ButtonRect, Color.Black * 0.7f);
            }

            textPosition = new Vector2(
                ButtonRect.X + (ButtonRect.Width - textSize.X) / 2f,
                ButtonRect.Y + (ButtonRect.Height - textSize.Y) / 2f
            );

            spriteBatch.DrawString(Globals.DefaultFont, ButtonText, textPosition, Color.White);
        }

        // we're currently calling this every frame, kinda only wanna call it when the ButtonRect.Position value changes
        private void UpdateTextPosition()
        {
            textPosition = new Vector2(
                ButtonRect.X + (ButtonRect.Width - textSize.X) / 2f,
                ButtonRect.Y + (ButtonRect.Height - textSize.Y) / 2f
            );
        }
    }
}
