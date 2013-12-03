using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.IO;

namespace C_SHARK
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Creates the a background object.
        Background Background;

        //Creates a random object
        Random Rand;

        //creates the temp camera replace with amidays camera
        TempCam myCamera;
        Vector2 pos = new Vector2();

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


            Background = new Background();
            Background.LoadContent(Content);

            Rand = new Random();

            string[] mapData = File.ReadAllLines("Content/map1.txt");

            int width = mapData[0].Length;
            int height = mapData.Length;

            char[,] tileData = new char[height, width];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {

                    tileData[y, x] =  char.Parse(mapData[y][x].ToString());

                }
            }


            Background.SetCurrentMap(tileData);

            pos.X = 500;
            pos.Y = 300;
            myCamera = new TempCam(GraphicsDevice.Viewport);
            myCamera.OuterBounds = new Rectangle(0, 0, 3200, 600);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            KeyboardState keyState = Keyboard.GetState();


                if (keyState.IsKeyDown(Keys.Right))
                {
                    pos.X += 5;
                }

                if (keyState.IsKeyDown(Keys.Left))
                {
                    pos.X -= 5;
                }
            

            myCamera.lookAt(pos);
            myCamera.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.Immediate,
                              null,
                              SamplerState.PointClamp,
                              null,
                              null,
                              null,
                              myCamera.ViewMatrix);


            Background.Draw(spriteBatch, gameTime);
            
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
