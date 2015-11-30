 using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace AdventureGame
{
    public class Game : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;

        public int height = 720;
        public int width = 1280;


        public GameWindow mainMenu, gameLevel;

        private KeyboardState key, prevKey;

        /*-----------------------------Auto-generated functions-----------------------------*/

        public Game()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {

            graphics.PreferredBackBufferHeight = height;
            graphics.PreferredBackBufferWidth = width;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();



            /*========================================*/
            MenuItemComponent menuItems = new MenuItemComponent(this, new Vector2(30, 290), Color.Black, Color.Yellow, 56);

            menuItems.AddItem("START");
            menuItems.AddItem("INSTRUCTIONS");
            menuItems.AddItem("AUTHORS");
            menuItems.AddItem("\nEND");

            MenuComponent menu = new MenuComponent(this, menuItems);
            LevelComponent level = new LevelComponent(this);
            HUD hud = new HUD(this);

            mainMenu = new GameWindow(this, menu, menuItems);
            gameLevel = new GameWindow(this, level, hud);

            /*========================================*/

            foreach (GameComponent komponenta in Components)
            {
                SwitchComponent(komponenta, false);
            }

            // switch window to main menu
            SwitchWindow(mainMenu);

            base.Initialize();
        }

        protected override void LoadContent()
        { 
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
            prevKey = key;
            key = Keyboard.GetState();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);
        }

        /*---------------------------Other functions--------------------------*/

        private void SwitchComponent(GameComponent component, bool switchedOn) 
        {
            component.Enabled = switchedOn;
            if (component is DrawableGameComponent)
                ((DrawableGameComponent)component).Visible = switchedOn;
        }

        public void SwitchWindow(GameWindow window)
        {
            GameComponent[] allowedComponents = window.GetComponents();

            foreach (GameComponent component in Components)
            {
                bool allowed = allowedComponents.Contains(component);
                SwitchComponent(component, allowed);
            }

            prevKey = key;
        }


        public bool newKey(Keys Key)
        {
            return key.IsKeyDown(Key) && !prevKey.IsKeyDown(Key);
        }

    }
}
