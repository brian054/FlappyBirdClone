using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace FlappyBirdClone
{
    public class ScoreManager
    {
        private SpriteFont font = Globals.DefaultFont;
        private int score;

        // tweak these if you want it higher/lower
        private readonly int _topPadding = 42; // 24

        public int Score => Score;

        public ScoreManager() { }

        public void Reset()
        {
            score = 0;
        }

        public void IncreaseScore(int amount = 1)
        {
            if (amount <= 0) return;
            score += amount;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (font == null) return;

            string text = score.ToString();

            // measure so we can center it
            Vector2 size = font.MeasureString(text);

            Vector2 pos = new Vector2(
                (Globals.PreferredBackBufferWidth - size.X) / 2f,
                _topPadding
            );

            spriteBatch.DrawString(font, text, pos, Color.White);
        }
    }
}
