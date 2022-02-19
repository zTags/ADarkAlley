using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using ADarkAlley.Data;
using ADarkAlley.Shared;

namespace ADarkAlley.DesktopGL
{
    public class ADarkAlley : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Dictionary<string, Level> _levels;
        private Dictionary<string, SpriteFont> _fonts;
        private Dictionary<string, Texture2D> _textures;
        private MainMenu _mainMenu;
        private LoadingScreen _loadingScreen;
        /// <summary> 
        /// 0 - loading <br/>
        /// 1 - main menu <br />
        /// 2 - in game 
        /// </summary>
        private int _gameState;

        public ADarkAlley()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _levels = new Dictionary<string, Level>();
            _fonts = new Dictionary<string, SpriteFont>();
            _textures = new Dictionary<string, Texture2D>();
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.ApplyChanges();
            Window.Title = "A Dark Alley";
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _fonts.Add("Inconsolata-Light", Content.Load<SpriteFont>("Fonts/Inconsolata-Light"));
            _loadingScreen = new LoadingScreen(_fonts["Inconsolata-Light"]);

            Task.Run(() =>
            {
                // load the rest here
                _loadingScreen.updateLoadingItem("Fonts/Inconsolata-Regular.ttf");
                _fonts.Add("Inconsolata-Regular", Content.Load<SpriteFont>("Fonts/Inconsolata-Regular"));

                _loadingScreen.updateLoadingItem("Fonts/Inconsolata-Bold.ttf");
                _fonts.Add("Inconsolata-Bold", Content.Load<SpriteFont>("Fonts/Inconsolata-Bold"));

                _loadingScreen.updateLoadingItem("Backgrounds/mainmenu.png");
                _textures.Add("mainmenu", Content.Load<Texture2D>("Backgrounds/mainmenu"));


                _loadingScreen.updateLoadingItem("mainmenu instance");
                _mainMenu = new MainMenu(_fonts["Inconsolata-Bold"], _fonts["Inconsolata-Light"], _textures["mainmenu"]);
                // switch to main menu
                _gameState = 1;
            });
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            var mouseState = Mouse.GetState();
            switch (_gameState)
            {
                case 1:
                    _mainMenu.Update(Mouse.GetState());
                    break;
            }

            if (_gameState > 0) // loading done
            {
                _gameState = _mainMenu.getState();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin(SpriteSortMode.Deferred,
                BlendState.AlphaBlend,
                SamplerState.PointClamp,
                null, null, null, null); // disable antialiasing cuz pixel art moment 

            switch (_gameState)
            {
                case 0:
                    _loadingScreen.Draw(_spriteBatch);
                    break;
                case 1:
                    _mainMenu.Draw(_spriteBatch);
                    break;
                case 2:
                    // TODO
                    break;
                default:
                    Console.WriteLine("illigal gamestate");
                    Environment.Exit(1);
                    break;
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
