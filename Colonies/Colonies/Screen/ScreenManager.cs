// Title: ScreenManager.cs
// Author: Joe Maley
// Date: 6-9-2013

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Colonies.Screen
{
    /// <summary>
    /// Maintains current screen state, and hooks with game loops.
    /// </summary>
    class ScreenManager
    {
        private static ScreenManager instance = null;

        private Screen screen = null;

        /// <summary>
        /// Private constructor exists only to defeat instantiation.
        /// </summary>
        private ScreenManager() { }

        /// <summary>
        /// Returns the singleton instance of the ScreenManager.
        /// </summary>
        /// <returns>An instance of the ScreenManager.</returns>
        public static ScreenManager GetInstance() 
        {
            return instance == null ? instance = new ScreenManager() : instance;
        }

        /// <summary>
        /// Sets the currently displayed screen.
        /// </summary>
        /// <param name="screen">The screen to go to.</param>
        public void SetScreen(Screen screen)
        {
            this.screen = screen;
        }

        /// <summary>
        /// Uppdates the current screen.
        /// </summary>
        public void Update()
        {
            if (screen != null)
            {
                screen.HandleInput();
                screen.Update();
            }
        }

        /// <summary>
        /// Draws the current screen.
        /// </summary>
        public void Draw()
        {
            if (screen != null)
                screen.Draw();
        }
    }
}
