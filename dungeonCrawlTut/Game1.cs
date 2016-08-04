using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace dungeonCrawlTut
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D personImage;
        Vector2 pIPosition;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            //Set the start position
            pIPosition = new Vector2(0.0f, 0.0f); // can be pIPosition = Vector.Zero

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            personImage = Content.Load<Texture2D>("tesst"); //load Image
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // gather input and update position

            float time = (float)gameTime.ElapsedGameTime.TotalSeconds;
            float speed = 250.0f;
            float moveAmount = speed * time;

            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Down)||state.IsKeyDown(Keys.S))
            {
                pIPosition.Y += moveAmount;
            }
            if (state.IsKeyDown(Keys.Up)||state.IsKeyDown(Keys.W))
            {
                pIPosition.Y -= moveAmount;
            }
            if (state.IsKeyDown(Keys.Left)|| state.IsKeyDown(Keys.A))
            {
                pIPosition.X -= moveAmount;
            }
            if (state.IsKeyDown(Keys.Right)|| state.IsKeyDown(Keys.D))
            {
                pIPosition.X += moveAmount;
            }


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Indigo);

            // Draw sprite
            spriteBatch.Begin();

            spriteBatch.Draw(personImage, pIPosition, Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
