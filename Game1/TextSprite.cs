using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class TextSprite : ISprite
    {
        //the font
        private SpriteFont Font;

        public TextSprite(SpriteFont Font)
        {
            this.Font = Font;
        }

        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            spriteBatch.Begin();
            //draws the credits for the game
            spriteBatch.DrawString(Font, "Credits", new Vector2(100, 350), Color.Black);
            spriteBatch.DrawString(Font, "Program Made By: Clark Godiwn", new Vector2(100, 370), Color.Black);
            spriteBatch.DrawString(Font, "Sprites From: http://www.mariouniverse.com/wp-content/img/sprites/nes/smb/characters.gif", new Vector2(100, 390), Color.Black);
            spriteBatch.End();
        }

        public void Update()
        {
           
        }
    }
}
