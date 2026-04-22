using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
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
        Rectangle tribbleBrownRec;
        Rectangle tribbleOrangeRec;
        Rectangle tribbleGreyRec;
        Rectangle tribbleCreamRec;
        SoundEffect tribbleCoo;
        Vector2 brownTribbleSpeed;
        Vector2 orangeTribbleSpeed;
        Vector2 greyTribbleSpeed;
        Vector2 creamTribbleSpeed;
        Color creamTribbleColor = Color.MediumAquamarine;


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

            tribbleBrownRec = new Rectangle(300, 10, 150, 150);
            tribbleOrangeRec = new Rectangle(350, 30, 150, 150);
            tribbleGreyRec = new Rectangle(250, 50, 150, 150);
            tribbleCreamRec = new Rectangle(5, 0, 150, 150);
            brownTribbleSpeed = new Vector2(4, 5); //bounce
            orangeTribbleSpeed = new Vector2(3, 3); //vertical
            greyTribbleSpeed = new Vector2(3, 4); //horizontal
            creamTribbleSpeed = new Vector2(-4/4, 4); //attempting diagonal


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            tribbleBTexture = Content.Load<Texture2D>("tribbleBrown");
            tribbleOTexture = Content.Load<Texture2D>("tribbleOrange");
            tribbleGTexture = Content.Load<Texture2D>("tribbleGrey");
            tribbleCTexture = Content.Load<Texture2D>("tribbleCream");
            tribbleCoo = Content.Load<SoundEffect>("tribble_coo");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

           tribbleBrownRec.X += (int) brownTribbleSpeed.X;
           if (tribbleBrownRec.Right > window.Width || tribbleBrownRec.Left < 0)
           {
                brownTribbleSpeed.X *= -1;
                tribbleCoo.Play();
                
           }

            if (tribbleBrownRec.Bottom > window.Height || tribbleBrownRec.Top < 0)
            {
                brownTribbleSpeed.Y *= -1;
                tribbleCoo.Play();
                
            }
           tribbleBrownRec.Y += (int) brownTribbleSpeed.Y;


            //tribbleOrangeRec.X += (int) orangeTribbleSpeed.X;
            //if (tribbleOrangeRec.Right > window.Width || tribbleOrangeRec.Left < 0)
            //{
            //    orangeTribbleSpeed.X *= -1;
            //    tribbleCoo.Play();
                
            //}

            if (tribbleOrangeRec.Bottom > window.Height || tribbleOrangeRec.Top < 0)
            {
                orangeTribbleSpeed.Y *= -1;
                tribbleCoo.Play();

            }
            tribbleOrangeRec.Y += (int)orangeTribbleSpeed.Y;


            tribbleGreyRec.X += (int)greyTribbleSpeed.X;
            if (tribbleGreyRec.Right > window.Width || tribbleGreyRec.Left < 0)
            {
                greyTribbleSpeed.X *= -1;
                tribbleCoo.Play();
            }

            //if (tribbleGreyRec.Bottom > window.Height || tribbleGreyRec.Top < 0)
            //{
            //    greyTribbleSpeed.Y *= -1;
            //    tribbleCoo.Play();
            //}
            //tribbleGreyRec.Y += (int)greyTribbleSpeed.Y;


            tribbleCreamRec.X += (int)creamTribbleSpeed.X*2;
            if (tribbleCreamRec.Right > window.Width || tribbleCreamRec.Left < 0)
            {
                creamTribbleSpeed.X *= -1;
                tribbleCoo.Play();
                creamTribbleColor = Color.White;
            }

            if (tribbleCreamRec.Bottom > window.Height || tribbleCreamRec.Top < 0)
            {
                creamTribbleSpeed.Y *= -1;
                tribbleCoo.Play();
                creamTribbleColor = Color.MediumAquamarine;
            }
            tribbleCreamRec.Y += (int)creamTribbleSpeed.Y*2;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkKhaki);
            _spriteBatch.Begin();

            _spriteBatch.Draw(tribbleBTexture, tribbleBrownRec, Color.BurlyWood);
            _spriteBatch.Draw(tribbleOTexture, tribbleOrangeRec, Color.Goldenrod);
            _spriteBatch.Draw(tribbleGTexture, tribbleGreyRec, Color.MonoGameOrange);
            _spriteBatch.Draw(tribbleCTexture, tribbleCreamRec, creamTribbleColor);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
