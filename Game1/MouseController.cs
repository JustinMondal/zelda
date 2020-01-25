using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class MouseController : IController
    {
        private Game1 current;

        public MouseController(Game1 game1)
        {
            this.current = game1;
        }

        public void Update()
        {
            MouseState state = Mouse.GetState();

            // Check if Right Mouse Button pressed, if so, exit
            if(state.RightButton == ButtonState.Pressed)
            {
                current.Exit();
            }
            //sets the sprite to the desired one
            if (state.LeftButton == ButtonState.Pressed)
                //sets the sprite to nonanimated nonmoving sprite
                if (state.Position.X <= 400 & state.Position.Y <= 200)
                    current.setSprite(1);
                //sets the sprite to nonanimated moving sprite
                else if (state.Position.X > 400 & state.Position.Y <= 200)
                    current.setSprite(2);
                //sets the sprite to nonanimated moving sprite
                else if (state.Position.X <= 400 & state.Position.Y > 200)
                    current.setSprite(3);
                //sets the sprite to animated moving sprite
                else if (state.Position.X > 400 & state.Position.Y > 200)
                    current.setSprite(4);

        }
    }
}
