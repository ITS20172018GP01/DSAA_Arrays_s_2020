using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace DSAA_Arrays_s_2020
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont font;
        ArraySlot SingleSlot;
        public static int[] arrayValues = new int[] { 10, 20, 30, 40, 50, 60, 70 };
        public ArraySlot[] arraySlots = new ArraySlot[arrayValues.Length];
        
        // New Game class variables
        TimeSpan delay = new TimeSpan(0, 0, 3);
        TimeSpan countDown;
        int CurrentItem = 0;

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
            // TODO: Add your initialization logic here

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
            font = Content.Load<SpriteFont>("GameFont");
            //SingleSlot = new ArraySlot
            //{
            //    Bounds = new Rectangle(10, 10, 50, 50),
            //    texture = Content.Load<Texture2D>("ArraySlotImage"),
            //    value = 20,
            //    BackgroundColor = Color.Aquamarine
            //};

            // Setup Color Array Slots
            Point ScreenPosition = new Point(20, 20);
            Point ArraySlotSize = new Point(100, 100);
            Random r = new Random();
            for (int i = 0; i < arrayValues.Length; i++)
            {
                arraySlots[i] =
                new ArraySlot
                {
                    Bounds = new Rectangle(ScreenPosition, ArraySlotSize),
                    texture = Content.Load<Texture2D>("ArraySlotImage"),
                    value = arrayValues[i],
                    BackgroundColor = new Color(r.Next(255), r.Next(255), r.Next(255)),
                    Visible = false,
                };
                ScreenPosition += new Point(ArraySlotSize.X + 10, 0);
            }
            countDown = delay;
            // TODO: use this.Content to load your game content here

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

            // Game Update Code	added
            // Set current Slot item to true
            arraySlots[CurrentItem].Visible = true;
            // count down to 0
            countDown -= gameTime.ElapsedGameTime;

            if (countDown.Seconds <= 0)
            {
                // Make the current one invisible
                arraySlots[CurrentItem].Visible = false;
                if (CurrentItem < arraySlots.Length - 1)
                {
                    CurrentItem++;
                }
                else CurrentItem = 0;
                // Set to 2 seconds
                countDown = delay;
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            foreach (ArraySlot slot in arraySlots)
                slot.Draw(spriteBatch, font);
            spriteBatch.DrawString(
                font,
                    countDown.Seconds.ToString(),
                        new Vector2(10, 10), Color.White);
            //SingleSlot.Draw(spriteBatch, font);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
