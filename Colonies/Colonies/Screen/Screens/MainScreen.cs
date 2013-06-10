// Title: MainScreen.cs
// Author: Joe Maley
// Date: 6-9-2013

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Colonies.Screen.Interface.Widgets;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Colonies.Screen.Screens.Interface.Widgets.Menu;

namespace Colonies.Screen.Screens
{
    /// <summary>
    /// The home screen with a menu widget for Play, Options and Exit
    /// </summary>
    sealed class MainScreen : Screen
    {
        private Texture2D background;
        private Texture2D widgetBackground;
        private SpriteFont menuFont;

        private MenuWidget mWidget;

        public MainScreen(GraphicsDeviceManager graphicsDeviceManager, ContentManager content) : base(graphicsDeviceManager)
        {
            background = content.Load<Texture2D>("Textures/fish");
            widgetBackground = content.Load<Texture2D>("Textures/water");
            menuFont = content.Load<SpriteFont>("Fonts/SpriteFont1");
            mWidget = new MenuWidget(widgetBackground, (graphicsDeviceManager.GraphicsDevice.Viewport.Width / 2) - (graphicsDeviceManager.GraphicsDevice.Viewport.Width / 3), 0, "Main Fish", menuFont);

            mWidget.AddMenuItem(new MenuItem("Play", removeWidget, menuFont));

            widgets.Add(mWidget);
            
        }

        /// <summary>
        /// TO-DO
        /// </summary>
        protected override void HandleScreenInput()
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// TO-DO
        /// </summary>
        protected override void DrawScreen(SpriteBatch sb)
        {
            Rectangle fullscreen = new Rectangle(0, 0, graphicsDeviceManager.GraphicsDevice.Viewport.Width, graphicsDeviceManager.GraphicsDevice.Viewport.Height);
            sb.Draw(background, fullscreen, Color.White);
        }

        /// <summary>
        /// TO-DO
        /// </summary>
        protected override void UpdateScreen()
        {
            //throw new NotImplementedException();
        }

        private void removeWidget()
        {
            widgets.Remove(mWidget);
        }
    }
}
