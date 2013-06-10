using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Colonies.Screen.Screens.Interface.Widgets.Menu
{
    class MenuItem
    {
        private String display;
        private Action function;
        private SpriteFont font;
        private Vector2 position;

        public MenuItem(String display, Action function, SpriteFont font)
        {
            this.display = display;
            this.function = function;
            this.font = font;
        }

        public bool isClicked(int x, int y)
        {
            if (x > position.X && x < position.X + font.MeasureString(display).X
                && y > position.Y && y < position.Y + font.MeasureString(display).Y)
                return true;
            return false;
        }

        public void onClick()
        {
            function();
        }

        public void Draw(SpriteBatch sb)
        {
            sb.DrawString(font, display, position, Color.Tomato);
        }

        public void SetPos(float x, float y)
        {
            position.X = x;
            position.Y = y;
        }
    }
}
