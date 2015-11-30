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
    public class MenuItemComponent : Microsoft.Xna.Framework.DrawableGameComponent
    {
        Game game;
        private SpriteFont minecraftFont;

        private List<MenuItem> items;
        public MenuItem selectedItem;
        private Vector2 position;
        private Color unselectedColor;
        private Color selectedColor;
        private int height;

        public MenuItemComponent(Game game, Vector2 position, Color unselectedColor, Color selectedColor, int height)
            : base(game)
        {
            this.position = position;
            this.game = game;
            this.unselectedColor = unselectedColor;
            this.selectedColor = selectedColor;
            this.height = height;
            items = new List<MenuItem>();
            selectedItem = null;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            minecraftFont = game.Content.Load <SpriteFont>(@"Fonts\Minecraft_font");

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            // keys reaction
            if (game.newKey(Keys.Up))
                SelectPrevItem();
            if (game.newKey(Keys.Down))
                SelectNextItem();

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            game.spriteBatch.Begin();
            /*============================*/
            foreach (MenuItem item in items)
            {
                Color color = unselectedColor;
                if (item == selectedItem)
                    color = selectedColor;
                game.spriteBatch.DrawString(minecraftFont , item.text, item.position,
                                            color, 0.0f, new Vector2(0,0), item.size,
                                            SpriteEffects.None, 0 );
            }


            /*============================*/
            game.spriteBatch.End();

            base.Draw(gameTime);
        }



        public void AddItem(string text)
        {
            // set position by item order 
            Vector2 p = new Vector2(position.X, position.Y + items.Count * height);
            MenuItem item = new MenuItem(text, p);
            items.Add(item);
            // select first item
            if (selectedItem == null)
                selectedItem = item;
        }

        private void SelectNextItem()
        {
            int index = items.IndexOf(selectedItem);
            if (index < items.Count - 1)
                selectedItem = items[index + 1];
            else
                selectedItem = items[0];
        }

        private void SelectPrevItem()
        {
            int index = items.IndexOf(selectedItem);
            if (index > 0)
                selectedItem = items[index - 1];
            else
                selectedItem = items[items.Count - 1];
        }


    }
}
