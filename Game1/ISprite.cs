using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    interface ISprite
    {
        //the desired Texture/Sprite
        Texture2D Texture { get; set; }
        //the number of rows in the sprite sheet
        int Rows { get; set; }
        //the number of columns in the sprite sheet
        int Columns { get; set; }
        void Update();
        void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}