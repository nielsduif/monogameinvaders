﻿
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
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D background, scanlines;

        Player thePlayer;
        Bullet theBullet;
        Invader[] invaders = new Invader[16];

        //TODO: Add multiple invaders here

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
            //System.Diagnostics.Debug.WriteLine("hoihoi");
            Console.WriteLine("hallo");

            // Pass often referenced variables to Global
            Global.GraphicsDevice = GraphicsDevice;            
            Global.content = Content;

            // Create and Initialize game objects
            thePlayer = new Player();
            theBullet = new Bullet();

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Global.spriteBatch = spriteBatch;
            background = Content.Load<Texture2D>("spr_background");
            scanlines = Content.Load<Texture2D>("spr_scanlines");
            base.Initialize();

            for (int i = 0; i < invaders.Length; i++) {
                invaders[i] = new Invader();
            }
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            Debug.WriteLine("vet debug");

            // Pass keyboard state to Global so we can use it everywhere
            Global.keys = Keyboard.GetState();
            if (Global.keys.IsKeyDown(Keys.Space)) theBullet.Fire(thePlayer.position);
            // Update the game objects
            thePlayer.Update();
            theBullet.Update();

            base.Update(gameTime);

            for (int i = 0; i < invaders.Length; i++)
            {
                invaders[i].Update();
                if (overlaps(theBullet.position.X, theBullet.position.Y, theBullet.texture, invaders[i].position.X, invaders[i].position.Y, invaders[i].texture))
                {
                    theBullet.Reset();
                    invaders[i].Reset();
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
            thePlayer.Draw();
            theBullet.Draw();

            spriteBatch.Draw(scanlines, Global.screenRect, Color.White);

            for (int i = 0; i < invaders.Length; i++)
            {
                invaders[i].Draw();
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
        Boolean overlaps(float x0, float y0, Texture2D texture0, float x1, float y1, Texture2D texture1)
        {
            int w0 = texture0.Width,
              h0 = texture0.Height,
              w1 = texture1.Width,
              h1 = texture1.Height;

            if (x0 > x1 + w1 || x0 + w0 < x1 ||
              y0 > y1 + h1 || y0 + h0 < y1)
                return false;
            else
                return true;
        }
    }
}
