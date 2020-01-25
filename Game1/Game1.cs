using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Game1
{
    
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        //example of using an interface for object implmentation
        //IWriter writer = new XmlWriter();
        //writer.WriteFile(); //method from an interface
        //writer.SetName(); //error the SetName method is not part of the IWriter interface
        
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private ISprite sprite;
        private ISprite textSprite;
        List<IController> controllerList; // could also be defined as List <IController>
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        //sets to a corresponing sprite type
        public void setSprite(int toSet)
        {
            //sets to nonanimated-nonmoving sprite
            if (toSet == 1)
            {
                sprite = new NonAnimatedSprite(Content.Load<Texture2D>("MarioSprite"), 12, 28);
            }
            //sets to an animated-nonmoving sprite
            if (toSet == 2)
            {
                sprite = new AnimatedSprite(Content.Load<Texture2D>("MarioSprite"), 12, 28);
            }
            //sets to nonanimated-moving sprite
            if (toSet == 3)
            {
                sprite = new MovingNonAnimated(Content.Load<Texture2D>("MarioSprite"), 12, 28);
            }
            //sets to an animated-moving sprite
            if (toSet == 4)
            {
                sprite = new MovingAnimated(Content.Load<Texture2D>("MarioSprite"), 12, 28);
            }
        }
        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            //initializes the controller list and the controllers within
            controllerList = new List<IController>();
            controllerList.Add(new KeyboardController(this));
            controllerList.Add(new MouseController(this));
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //loads initial nonmoving nonanimated sprite
            sprite = new NonAnimatedSprite(Content.Load<Texture2D>("MarioSprite"),12,28);
            //sets up the credits text
            textSprite = new TextSprite(Content.Load<SpriteFont>("File"));

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            Content.Unload();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            
            //updates both sprites
            sprite.Update();
            textSprite.Update();
            //checks for controller updates
            foreach (IController controller in controllerList)
            {
                controller.Update();
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //draws the background
            GraphicsDevice.Clear(Color.CornflowerBlue);
            //draws the sprite
            sprite.Draw(spriteBatch, Vector2.Zero);
            //draws the credits 
            textSprite.Draw(spriteBatch,Vector2.Zero);
            base.Draw(gameTime);
        }
    }
}
