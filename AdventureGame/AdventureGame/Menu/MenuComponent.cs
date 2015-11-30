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
    public class MenuComponent : Microsoft.Xna.Framework.DrawableGameComponent
    {
        Game game;
        Texture2D background;
        SpriteFont title;
        float scale, deltaScale; // scale of title
        Vector2 titlePosition;

        private MenuItemComponent menuItems;

        public MenuComponent(Game game, MenuItemComponent menuItems)
        : base(game)
        {
            this.game = game;
            this.menuItems = menuItems;
        }

        public override void Initialize()
        {
            
            scale = 1.2f;
            deltaScale = 0.002f;

            titlePosition = new Vector2(290, 20);
            

            base.Initialize();
        }

        protected override void LoadContent()
        {
            background = game.Content.Load<Texture2D>(@"Sprites\Menu\menuBackground");
            title = game.Content.Load<SpriteFont>(@"Fonts\Minecraft_font");

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {

            /*--------------------create Bubble Efect for title-------------------*/
            scale += deltaScale;
            
            if (scale > 1.273f)
                deltaScale *= -1;
            else if ( scale < 1.1f)
                deltaScale = (float)Math.Abs(deltaScale);

            /*-------------------------Enter reactions of menu items---------------------------*/
            if (game.newKey(Keys.Enter))
            {
                switch (menuItems.selectedItem.text)
                {
                    case "START":
                        game.SwitchWindow(game.gameLevel);
                        break;
                    case "INSTRUCTIONS":
                        break;
                    case "AUTHORS":
                        break;
                    case "\nEND":
                        game.Exit();
                        break;
                }
            }
            
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            game.spriteBatch.Begin();
            /*===========================================*/
            game.spriteBatch.Draw(background, new Vector2(0, 0), Color.White);


            game.spriteBatch.DrawString(title, "MINECRAFT ADVENTURE", titlePosition, Color.Yellow,
                                        0.0f, new Vector2(0, 0), scale, SpriteEffects.None, 0.0f);

            /*===========================================*/
            game.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
