using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ADarkAlley.Shared
{

    // TODO add a progress bar :pog:
    public class LoadingScreen
    {
        private SpriteFont _text;
        private int _percentage;
        private string _loadingItem;
        private SpriteFont _font;
        public LoadingScreen(SpriteFont font)
        {
            _font = font;
        }

        public void updatePercentage(int percentage)
        {
            if (percentage > 100)
            {
                Console.WriteLine("illigal percentage provided (>100)");
            }
            else
            {
                _percentage = percentage;
            }
        }

        public void updateLoadingItem(string item)
        {
            _loadingItem = item;

        }

        public void Update()
        {
            // stub
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(_font, $"Loading... ({_loadingItem})", new Vector2(10, 675), Color.White);
        }
    }
}