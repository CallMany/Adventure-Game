using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventureGame
{
    class Tiles
    {
        #region Variables

        public bool isEnabled = true;

        protected Texture2D texture;

        private Rectangle rectangle;
        public Rectangle Rectangle
        {
            get { return rectangle; }
            set { rectangle = value; }
        } 

        private static ContentManager content;
        public  static ContentManager Content
        {
            protected get { return content; }
            set { content = value; }
        }

        #endregion

        #region Methods

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isEnabled)
            {
                spriteBatch.Draw(texture, rectangle, Color.White); // If isEnabled = true --> Draw a tile
            }
        } 

        #endregion
    }


    class CollisionTiles : Tiles
    {
        public CollisionTiles(int i, Rectangle rectangle)
        {
            texture = Content.Load<Texture2D>("Sprites\\Tiles\\Tile" + i);
            this.Rectangle = rectangle;
        }

    }


}