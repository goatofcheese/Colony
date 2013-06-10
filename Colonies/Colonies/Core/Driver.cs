// Title: Driver.cs
// Author: Joe Maley
// Date: 6-8-2013

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
using Colonies.Screen;
using Colonies.Screen.Screens;
using Colonies.Input;

namespace Colonies.Core
{
    /// <summary>
    /// Handles initialization, content, and game loops.
    /// </summary>
    public sealed class Driver : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphicsDeviceManager;

        ScreenManager screenManager;
        InputManager inputManager;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            // initializes and launches game loops
            new Driver().Run();
        }

        /// <summary>
        /// Constructs a new driver.
        /// </summary>
        public Driver()
        {
            // the GraphicsDeviceManager must be initialized here, not in Initialize();
            graphicsDeviceManager = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world, checking for collisions,
        /// gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            inputManager.Update();
            screenManager.Update();

            base.Update(gameTime);
        }

        /// <summary>
        /// Initialization. 
        /// </summary>
        protected override void Initialize()
        {
            screenManager = ScreenManager.GetInstance();
            inputManager = InputManager.GetInstance();

            screenManager.SetScreen(new MainScreen(graphicsDeviceManager, Content));

            base.Initialize();
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            screenManager.Draw();

            base.Draw(gameTime);

        }
    }
}
