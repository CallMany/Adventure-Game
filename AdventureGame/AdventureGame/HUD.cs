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

    public class HUD : Microsoft.Xna.Framework.DrawableGameComponent
    {
        /*------------------------------Variables-----------------------*/
        Game game;

        Texture2D itemHandler, Health;


        // Constructor
        public HUD(Game game)
            : base(game)
        {
            this.game = game;
        }
        /*------------------------Automatical-generated functions----------------------*/
        public override void Initialize()
        {

            base.Initialize();
        }

        protected override void LoadContent()
        {
            itemHandler = game.Content.Load<Texture2D>(@"Sprites\Player\itemHandler");

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            game.spriteBatch.Begin();

            int space = 0;
            for(int i = 0; i < 7; i++)
            {
                game.spriteBatch.Draw(itemHandler, new Vector2(230 + space + (i * itemHandler.Width), game.height - 120 ), Color.White);
                space += 25;
            }

            game.spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
