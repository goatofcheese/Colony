// Title: Screen.cs
// Author: Joe Maley
// Date: 6-9-2013

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Colonies.Screen.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Colonies.Screen
{
    /// <summary>
    /// Provides a basic template for a game screen.
    /// </summary>
    abstract class Screen
    {
        protected List<Widget> widgets = new List<Widget>();

        protected GraphicsDeviceManager graphicsDeviceManager;
        protected SpriteBatch spriteBatch;

        /// <summary>
        /// Create a game screen.
        /// </summary>
        public Screen(GraphicsDeviceManager graphicsDeviceManager)
        {
            this.graphicsDeviceManager = graphicsDeviceManager;
            spriteBatch = new SpriteBatch(graphicsDeviceManager.GraphicsDevice);
        }

        /// <summary>
        /// Handles input to the screen.
        /// </summary>
        public void HandleInput()
        {
            foreach (Widget widget in widgets)
                if (widget.HandleInput() == true)
                    return;

            HandleScreenInput();
        }

        /// <summary>
        /// Updates the screen. Game logic, A.I., physics, etc should go here.
        /// </summary>
        public void Update()
        {
            UpdateScreen();
        }

        /// <summary>
        /// Draws the screen.
        /// </summary>
        public void Draw()
        {
            graphicsDeviceManager.GraphicsDevice.Clear(Color.Black);

            DrawScreen();

            foreach (Widget widget in widgets)
                widget.Draw();
        }

        /// <summary>
        /// Handles input to the screen (child implementation).
        /// </summary>
        protected abstract void HandleScreenInput();

        /// <summary>
        /// Updates the screen. Game logic, A.I., physics, etc should go here (child implementation).
        /// </summary>
        protected abstract void UpdateScreen();

        /// <summary>
        /// Draws the screen (child implementation).
        /// </summary>
        protected abstract void DrawScreen();
    }
}
