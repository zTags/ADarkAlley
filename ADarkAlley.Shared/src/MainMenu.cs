using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ADarkAlley.Shared
{
    public class MainMenu
    {
        //private List<Car> _cars;
        private SpriteFont _bigFont;
        private SpriteFont _smallFont;
        private Texture2D _background;
        private int _gamestate;
        private int _x1;
        private int _x2;
        /// <summary>
        /// 0 - no hovered <br />
        /// 1 - begin game button
        /// </summary>
        private int _hovered;

        public MainMenu(SpriteFont bigFont, SpriteFont smallFont, Texture2D background)
        {
            _bigFont = bigFont;
            _smallFont = smallFont;
            _background = background;
            _gamestate = 1;

            _x1 = 0;
            _x2 = 1280;
        }

        public void Update(MouseState mouseState)
        {
            _x1--;
            _x2--;

            // loop animation
            if (_x1 == -1280) _x1 = 1280;  // i genuinely dont know why this is -1300 

            if (_x2 == -1280) _x2 = 1280;

            // check for hover
            var x = 0;
            var y = 0;
            mouseState.Position.Deconstruct(out x, out y);
            if ((x > 50 && x < 211) && (y > 130 && y < 160))
            {
                _hovered = 1;
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    _gamestate = 2;
                }
            }
            else
            {
                _hovered = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // draw scrolling background
            spriteBatch.Draw(_background, new Vector2(_x1, 0), null, Color.White, 0f,
                Vector2.Zero, 2f, SpriteEffects.None, 0f);
            spriteBatch.Draw(_background, new Vector2(_x2, 0), null, Color.White, 0f,
                Vector2.Zero, 2f, SpriteEffects.None, 0f);

            // draw menu text
            spriteBatch.DrawString(_bigFont, "A Dark Alley", new Vector2(50, 50), Color.White);
            spriteBatch.DrawString(_smallFont, "Start Game", new Vector2(50, 125), _hovered == 0 ? Color.White : Color.Gray);
        }

        public int getState() => _gamestate;
    }
}