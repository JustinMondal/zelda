using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class MovingNonAnimated : ISprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private Vector2 Position = new Vector2(330, 50);
        private Boolean goingUp = true;
        public MovingNonAnimated(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = 0;
            int column = 0;
            //gets the desired sprite from the source image
            Rectangle sourceRectangle = new Rectangle(width * column+ 10, height * row +35, width, height-5);
            //creates a larger image for the sprite to be drawn
            Rectangle destinationRectangle = new Rectangle((int)Position.X, (int)Position.Y, width * 6, height * 6);
            //creates a better resolution image for the texture
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullCounterClockwise, null);
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public void Update()
        {
            if(goingUp)
                Position.Y -= 3;
                if (Position.Y <= -80)
                    goingUp = false;
            if (!goingUp)
                Position.Y += 4;
                if (Position.Y >= 100)
                    goingUp = true;

        }
    }
}
