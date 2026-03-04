using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace FlappyBirdClone
{
    public class ScoreManager
    {
        private SpriteFont _font = Globals.DefaultFont;
        private int _score;

        // tweak these if you want it higher/lower
        private readonly int _topPadding = 42; // 24

        public int Score => _score;

        public ScoreManager() { }

        public void Reset()
        {
            _score = 0;
        }

        public void IncreaseScore(int amount = 1)
        {
            if (amount <= 0) return;
            _score += amount;
        }

        /// <summary>
        /// Draws score near the top-center of the screen (288x512 by default).
        /// </summary>
        public void Draw(SpriteBatch spriteBatch)
        {
            if (_font == null) return;

            string text = _score.ToString();

            // measure so we can center it
            Vector2 size = _font.MeasureString(text);

            Vector2 pos = new Vector2(
                (Globals.PreferredBackBufferWidth - size.X) / 2f,
                _topPadding
            );

            spriteBatch.DrawString(_font, text, pos, Color.White);
        }
    }
}
