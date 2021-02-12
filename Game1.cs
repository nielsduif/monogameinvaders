
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace MonoGameInvaders
{
    /// <summary>
    /// This is the main type for your game
    /// opdr 2
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D background, scanlines;

        int invaderAmount = 20;
        int shieldAmount = 4;
        List<GameObject> gameObjects = new List<GameObject>();


        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 800;
            graphics.ApplyChanges();

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
            // Pass often referenced variables to Global
            Global.GraphicsDevice = GraphicsDevice;
            Global.content = Content;

            // Create and Initialize game objects
            gameObjects.Add(new Player());
            gameObjects.Add(new Bullet());

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Global.spriteBatch = spriteBatch;
            background = Content.Load<Texture2D>("spr_background");
            scanlines = Content.Load<Texture2D>("spr_scanlines");
            base.Initialize();

            for (int i = 0; i < invaderAmount / 4; i++)
            {
                gameObjects.Add(new RedInvader());
                gameObjects.Add(new BlueInvader());
                gameObjects.Add(new YellowInvader());
                gameObjects.Add(new GreenInvader());
            }

            gameObjects.Add(new SpaceShip());

            for (int i = 0; i < shieldAmount; i++)
            {
                gameObjects.Add(new Shield());
            }
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Pass keyboard state to Global so we can use it everywhere
            Global.keys = Keyboard.GetState();

            // Update the game objects
            base.Update(gameTime);

            foreach (GameObject GO in gameObjects)
            {
                GO.Update();
            }


            for (int i = 0; i < gameObjects.Count; i++)
            {
                for (int x = 0; x < gameObjects.Count; x++)
                {
                    if (gameObjects[i] is Bullet)
                    {
                        Bullet B = gameObjects[i] as Bullet;
                        if (gameObjects[x] is Player)
                        {
                            Player P = gameObjects[x] as Player;
                            if (Global.keys.IsKeyDown(Keys.Space))
                            {
                                B.Fire(P.position);
                            }
                        }

                        else if (gameObjects[x] is Invader)
                        {
                            Invader I = gameObjects[x] as Invader;
                            if (B.overlaps(B.position.X, B.position.Y, B.texture, I.position.X, I.position.Y, I.texture))
                            {
                                B.Start();
                                I.Start();
                            }
                        }
                        
                        else if (gameObjects[x] is Shield)
                        {
                            Shield S = gameObjects[x] as Shield;
                            if (B.overlaps(B.position.X, B.position.Y, B.texture, S.position.X, S.position.Y, S.texture))
                            {
                                B.Start();
                                gameObjects.RemoveAt(x);
                            }
                        }

                        else if (gameObjects[x] is SpaceShip)
                        {
                            SpaceShip SS = gameObjects[x] as SpaceShip;
                            if (B.overlaps(B.position.X, B.position.Y, B.texture, SS.position.X, SS.position.Y, SS.texture))
                            {
                                B.Start();
                                SS.hits++;
                                if (SS.hits >= 2)
                                {
                                    gameObjects.RemoveAt(x);
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            // Draw the background (and clear the screen)
            spriteBatch.Draw(background, Global.screenRect, Color.White);

            // Draw the game objects
            foreach (GameObject GO in gameObjects)
            {
                GO.Draw();
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
