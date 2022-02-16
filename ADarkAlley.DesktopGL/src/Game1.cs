using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using ADarkAlley.Data;
using ADarkAlley.Shared;

namespace ADarkAlley.DesktopGL
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Dictionary<string, Level> _levels;
        private Dictionary<string, SpriteFont> _fonts;
        private MainMenu _mainMenu;
        private LoadingScreen _loadingScreen;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _levels = new Dictionary<string, Level>();
            _fonts = new Dictionary<string, SpriteFont>();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.PreferredBackBufferWidth  = 1280;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _fonts.Add("Inconsolata-Light", Content.Load<SpriteFont>("Fonts/Inconsolata-Light"));
            _loadingScreen = new LoadingScreen(_fonts["Inconsolata-Light"]);

            Task.Run(() => {
                // load the rest here
                _loadingScreen.updateLoadingItem("Inconsolata Regular");
                _fonts.Add("Inconsolata-Regular", Content.Load<SpriteFont>("Fonts/Inconsolata-Regular"));
            });

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            _loadingScreen.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
