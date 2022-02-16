using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ADarkAlley.Shared
{
    public class MainMenu
    {
        //private List<Car> _cars;
        private SpriteFont _bigFont;
        private SpriteFont _smallFont;
        private Texture2D _background;

        public MainMenu(SpriteFont bigFont, SpriteFont smallFont, Texture2D background)
        {
            _bigFont = bigFont;
            _smallFont = smallFont;
            _background = background;
        }

        public void Update()
        {
            // TODO lmao yeah
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_background, new Vector2(0, 0), Color.White);
        }
    }
}