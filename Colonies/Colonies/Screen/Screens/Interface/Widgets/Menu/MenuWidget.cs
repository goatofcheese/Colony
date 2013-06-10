using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Colonies.Screen.Screens.Interface.Widgets.Menu;
using Microsoft.Xna.Framework;

namespace Colonies.Screen.Interface.Widgets
{
    class MenuWidget : Widget
    {
        private String title;
        private List<MenuItem> menuItems;

        private SpriteFont titleFont;
        private static int itemYBuffer = 10;

        /// <summary>
        /// A menu widget needs everything a normal widget has plus a title for the menu
        /// </summary>
        public MenuWidget(Texture2D background, int baseX, int baseY, String name, SpriteFont font) : base(background, baseX, baseY)
        {
            this.title = name;
            this.menuItems = new List<MenuItem>();
            this.titleFont = font;

        }

        /// <summary>
        /// Handles widget input (child implementation).
        /// </summary>
        protected override void HandleWidgetInput()
        {
            int x = inputManager.GetMouseX();
            int y = inputManager.GetMouseY();

            foreach(MenuItem item in menuItems){
                if (item.isClicked(x, y))
                    item.onClick();
            }
        }

        /// <summary>
        /// Draws the widget (child implementation).
        /// </summary>
        protected override void DrawWidget(SpriteBatch sb)
        {
            Rectangle fullscreen = new Rectangle(baseX, baseY, background.Width, background.Height);
            sb.Draw(background, fullscreen, Color.White);

            Vector2 position = new Vector2(baseX + background.Width/2, baseY + itemYBuffer);
            sb.DrawString(titleFont, title, position, Color.Yellow);

            position = titleFont.MeasureString(title);
            int count = 1;
            foreach (MenuItem item in menuItems)
            {
                float x = baseX + (background.Width / 2);
                float y = baseY + position.Y + (itemYBuffer * (count + 2));
                item.SetPos(x, y);
                item.Draw(sb);
                count++;
            }
        }

        public void AddMenuItem(MenuItem item)
        {
            menuItems.Add(item);
        }

    }
}
