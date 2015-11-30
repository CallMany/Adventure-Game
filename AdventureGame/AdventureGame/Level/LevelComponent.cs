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

    public class LevelComponent : Microsoft.Xna.Framework.DrawableGameComponent
    {
        Game game;
        Map map;
        Player player = new Player(new Vector2(50,50));
        
        MouseState mouse;


        public LevelComponent(Game game)
            : base(game)
        {
            this.game = game;
        }

        public override void Initialize()
        {

            map = new Map();

            game.IsMouseVisible = true;
            

            base.Initialize();
        }

        protected override void LoadContent()
        {
            
            map.GenerateWorld("newMap");
            player.LoadContent(game.Content, "Player\\spritePlayer");

            Tiles.Content = game.Content;

            map.LoadWorld("newMap", 64);

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            player.Update(gameTime);
            mouse = Mouse.GetState();

            map.Update();
            foreach (CollisionTiles tile in map.CollisionTiles)
            {
                player.Collisions(tile.Rectangle);

                if (tile.Rectangle.Contains(new Point(mouse.X, mouse.Y)) && (mouse.LeftButton == ButtonState.Pressed))
                {
                    tile.isEnabled = false;
                }
            }

            foreach (Rectangle rct in map.Rectangles)
            {
                if (rct.Contains(new Point(mouse.X, mouse.Y)) && mouse.RightButton == ButtonState.Pressed)
                {
                    map.AddBlock(new Point(rct.X, rct.Y), 1);
                }
            }

            base.Update(gameTime);

            
        }

        public override void Draw(GameTime gameTime)
        {
            game.spriteBatch.Begin();

            map.Draw(game.spriteBatch);
            player.Draw(game.spriteBatch);

            game.spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
