using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Topic_3_Animation
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Rectangle window;
        Texture2D tribbleBTexture;
        Texture2D tribbleOTexture;
        Texture2D tribbleGTexture;
        Texture2D tribbleCTexture;
        Rectangle tribbleBrown;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            window = new Rectangle(0, 0, 800, 600);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            tribbleBrown = new Rectangle(300, 10, 100, 100);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            tribbleBTexture = Content.Load<Texture2D>("tribbleBrown");
            tribbleOTexture = Content.Load<Texture2D>("tribbleOrange");
            tribbleGTexture = Content.Load<Texture2D>("tribbleGrey");
            tribbleCTexture = Content.Load<Texture2D>("tribbleCream");

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightSteelBlue);
            _spriteBatch.Begin();

            _spriteBatch.Draw(tribbleBTexture, tribbleBrown, Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
