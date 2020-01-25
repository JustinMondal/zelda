using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Game1
{
    class AnimatedSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int totalFrames;
        //frame delay should be updated with gametime object for universal use
        private int delay = -3000;
        
        //constructor
        public AnimatedSprite(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            totalFrames = Rows * Columns;
        }
        public void Update()
        {
            //this method is used as no gameTime is being passed to Animated Sprite
            //delay used to slow down the animation so that it can be seen
            if (delay < totalFrames)
            {
                delay += totalFrames;
            }
            //once the delay is over the animation changes to the next
            if (delay >= totalFrames) { 
                currentFrame++;
                if (currentFrame == totalFrames)
                    currentFrame = 0;
                delay = -3000;
            }
                
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            //width and height of the displayed image to be taken from sprite sheet
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            //use this to cycle through other rows when applicable(int)((float)currentFrame / (float)Columns);
            int row = 0;
            //array to rotate through the desired frames for animation
            int[] loc= new int[]{16,17,18};
            //int column = currentFrame % Columns;
            //gets the sprite from the sprite sheet with the small adjustment to get the sprite in frame and to use the desired sprite
            Rectangle sourceRectangle = new Rectangle(width * loc[currentFrame%3]+6, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle(330, 50, width * 6, height * 6);
            //resizes the image with a better resolution
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullCounterClockwise, null);
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
    
}
