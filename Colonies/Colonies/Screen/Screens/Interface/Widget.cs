// Title: Widget.cs
// Author: Joe Maley
// Date: 6-9-2013

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Colonies.Input;

namespace Colonies.Screen.Interface
{
    /// <summary>
    /// Widgets are used to make up a user interface.
    /// </summary>
    abstract class Widget
    {
        protected Texture2D background = null;
        protected int baseX;
        protected int baseY;

        protected InputManager inputManager;

        /// <summary>
        /// Creates a new widget with desired background texture.
        /// </summary>
        public Widget(Texture2D background, int startX, int startY)
        {
            this.background = background;   
            this.baseX = startX;
            this.baseY = startY;

            inputManager = InputManager.GetInstance();
        }

        /// <summary>
        /// Handles widget input.
        /// </summary>
        /// <returns>True if clicked.</returns>
        public bool HandleInput()
        {
            if (Clicked() == true)
            {
                HandleWidgetInput();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Draws the widget.
        /// </summary>
        public void Draw(SpriteBatch sb)
        {
            // draw the widget background here
            DrawWidget(sb);
        }

        /// <summary>
        /// Handles widget input (child implementation).
        /// </summary>
        protected abstract void HandleWidgetInput();

        /// <summary>
        /// Draws the widget (child implementation).
        /// </summary>
        protected abstract void DrawWidget(SpriteBatch sb);

        /// <summary>
        /// Checks if the widget has been clicked.
        /// </summary>
        /// <returns>True if clicked, otherwise false.</returns>
        private bool Clicked()
        {
            // TO-DO: Use the input manager to see if the mouse has clicked on this widget.
            
            int x = inputManager.GetMouseX();
            int y = inputManager.GetMouseY();
            if (x > baseX && x <= baseX + background.Width &&
                y > baseY && y <= baseY + background.Height)
                return true;

            return false;
        }
    }
}
