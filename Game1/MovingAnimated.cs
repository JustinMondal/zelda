using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class MovingAnimated : ISprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int totalFrames;
        private Vector2 Position = new Vector2(330, 50);
        private Boolean GoingLeft = true;
        private int delay = -2500;
        public MovingAnimated(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            totalFrames = Rows * Columns;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = 18;
            int height = Texture.Height / Rows;
            //use this to cycle through other rows when applicable(int)((float)currentFrame / (float)Columns)
            //need to cycle through 3 of the sprites for each direction 6 in total 
            int row = 0;
            //the desired columns of the frames for the sprites running left or right
            int[] locLeft = new int[] {11,10,9};
            int[] locRight = new int[] { 16,17,18 };
            //rotates through the desired frames for going left or right
            Rectangle sourceRectangleLeft = new Rectangle(width * locLeft[currentFrame % 3] + 3, height * row, width, height);
            Rectangle sourceRectangleRight = new Rectangle(width * locRight[currentFrame%3]+6, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)Position.X, (int)Position.Y, width * 6, height * 6);
            //creates a better resolution for the sprite
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullCounterClockwise, null);
            //if going left the left direction sprites are used otherwise the right animations are used
            if(GoingLeft)
                spriteBatch.Draw(Texture, destinationRectangle, sourceRectangleLeft, Color.White);
            else
               spriteBatch.Draw(Texture, destinationRectangle, sourceRectangleRight, Color.White);
            spriteBatch.End();
        }

        public void Update()
        {
            //add a delay sprite moves way to fast
            //slows the sprite for my machine this is NOT a universal delay
            //delay used to slow down the animation so that it can be seen
            if (delay < totalFrames)
            {
               delay += totalFrames;
            }
            //once the delay is over the animation changes to the next
            if (delay >= totalFrames)
            {
                currentFrame++;
                if (currentFrame == totalFrames)
                    currentFrame = 0;
                delay = -2500;
            }
            //checks for the direction the sprite is going and stops it from going off screen and changes its direction
            //and uses the right animations and vice versa
             if (GoingLeft) {
                Position.X -= 2;
                if (Position.X <= 0)
                   GoingLeft = false; 
            }
            else
            {
                Position.X += 2;
                if (Position.X >= 700)
                    GoingLeft = true;
            }
               
        }
    }
}
