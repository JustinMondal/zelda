using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class NonAnimatedSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public NonAnimatedSprite(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            //the row location of the sprite is in on the sprite sheet
            int row = 0;
            //the column location of the sprite is in on the sprite sheet
            int column = 14;
            //location of the sprite on the sprite sheet with small adjustment in the x direction
            Rectangle sourceRectangle = new Rectangle(width * column+4, height * row, width, height);
            //location of the sprite in the game
            Rectangle destinationRectangle = new Rectangle(330, 50, width*6, height*6);
            //creates a better resolution for the sprite
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullCounterClockwise, null);
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public void Update()
        {
          
        }
    }
}
