using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
	class KeyboardController : IController
	{
		//holds previous state to prevent rapid clicking
		KeyboardState previousState;
		//the current game
		Game1 currentGame;

		public KeyboardController(Game1 game1)
		{
			currentGame = game1;
			previousState = Keyboard.GetState();
		}

		public void Update()
		{
			KeyboardState state = Keyboard.GetState();
			//exits the game by pressing the 0 key on the keyboard or on the num pad
			if (state.IsKeyDown(Keys.D0)||state.IsKeyDown(Keys.NumPad0))
				currentGame.Exit();
			//changes the sprite to the nonanimated nonmoving sprite
			else if ((state.IsKeyDown(Keys.D1) & !previousState.IsKeyDown(
				Keys.D1)|| (state.IsKeyDown(Keys.NumPad1) & !previousState.IsKeyDown(
				Keys.NumPad1))))
				currentGame.setSprite(1);
			//changes the sprite to the animated nonmoving sprite
			else if (state.IsKeyDown(Keys.D2) & !previousState.IsKeyDown(
				Keys.D2) || (state.IsKeyDown(Keys.NumPad2) & !previousState.IsKeyDown(
				Keys.NumPad2)))
				currentGame.setSprite(2);
			//changes the sprite to the nonanimated moving sprite
			else if (state.IsKeyDown(Keys.D3) & !previousState.IsKeyDown(
				Keys.D3) || (state.IsKeyDown(Keys.NumPad3) & !previousState.IsKeyDown(
				Keys.NumPad3)))
				currentGame.setSprite(3);
			//changes the sprite to the animated moving sprite
			else if (state.IsKeyDown(Keys.D4) & !previousState.IsKeyDown(
				Keys.D4) || (state.IsKeyDown(Keys.NumPad4) & !previousState.IsKeyDown(
				Keys.NumPad4)))
				currentGame.setSprite(4);


			previousState = Keyboard.GetState();

		}
	}
}
