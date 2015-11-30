using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace AdventureGame
{
    public class Object
    {
        /*-------------------------Variables---------------------------*/
        protected Vector2 position;
        protected Texture2D spriteTexture;
        protected Rectangle collisionRectangle;
        protected string spriteName;
        protected float rotation = 0.0f;
        protected float speed;
        protected float scale = 2.0f;

        /*----------------------------Constructors------------------------*/
        public Object(Vector2 pos)
        {
            this.position = pos;
        }

        public Object()
        {

        }


        /*---------------------------------Functions----------------------------------*/
        public virtual void LoadContent(ContentManager content, string spriteName)
        {
            this.spriteName = spriteName;

            spriteTexture = content.Load<Texture2D>("Sprites\\" + spriteName);
            
        }

        public virtual void Update(GameTime gameTime)
        {
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(spriteTexture, collisionRectangle, Color.White);
        }

    }
}
