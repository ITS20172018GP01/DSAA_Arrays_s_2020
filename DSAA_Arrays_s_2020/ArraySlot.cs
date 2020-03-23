using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAA_Arrays_s_2020
{
    public class ArraySlot
    {
        public int value { get; set; }
        public Texture2D texture { get; set; }
        public Rectangle Bounds { get; set; }

        // New variable
        public bool Visible { get; set; }
        public Color BackgroundColor { get; set; }

        
        // we use the enabled property of a game 
        // component to see if its activated
        public ArraySlot()
        {
        }

        public void Draw(SpriteBatch gameSB, SpriteFont font)
        {
            // New Draw code
            if (!Visible) return;
            // We get a spritebatch and font reference as a service
            Vector2 textSize = font.MeasureString(value.ToString());
            gameSB.Draw(texture, Bounds, BackgroundColor);
            gameSB.DrawString(font, value.ToString(),
                Bounds.Center.ToVector2() - textSize / 2, Color.White);
        }

    }
}
