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
        private Texture2D background = null;

        private InputManager inputManager;

        /// <summary>
        /// Creates a new widget with desired background texture.
        /// </summary>
        public Widget(Texture2D background)
        {
            this.background = background;

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
        public void Draw()
        {
            // draw the widget background here
            DrawWidget();
        }

        /// <summary>
        /// Handles widget input (child implementation).
        /// </summary>
        protected abstract void HandleWidgetInput();

        /// <summary>
        /// Draws the widget (child implementation).
        /// </summary>
        protected abstract void DrawWidget();

        /// <summary>
        /// Checks if the widget has been clicked.
        /// </summary>
        /// <returns>True if clicked, otherwise false.</returns>
        private bool Clicked()
        {
            // TO-DO: Use the input manager to see if the mouse has clicked on this widget.
            return false;
        }
    }
}
