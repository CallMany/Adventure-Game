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
    public class Player : Object
    {
        private Vector2 velocity;
        private bool hasJumped;
        MouseState mouse;


        public Player(Vector2 posi)
            : base(posi)
        {
            hasJumped = true;
        }

        public override void Update(GameTime gameTime)
        {
            mouse = Mouse.GetState();

            position.X += velocity.X;
            position.Y += velocity.Y;

            collisionRectangle = new Rectangle((int)position.X, (int)position.Y, spriteTexture.Width / 2, spriteTexture.Height / 2 );

            Input(gameTime);
            /*--------------------------------------------------------------*/
            FallDown();
            base.Update(gameTime);
        }


        public void FallDown()
        {
            if (velocity.Y < 10)
                velocity.Y += 0.4f;
        }

        private void Input(GameTime gameTime)
        { 

            #region Movement of a Player
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                velocity.X = (float)gameTime.ElapsedGameTime.Milliseconds / 3;
            }
            else if(Keyboard.GetState().IsKeyDown(Keys.A))
            {
                velocity.X = -(float)gameTime.ElapsedGameTime.Milliseconds / 3;
            }
            else
            {
                velocity.X = 0f;
            }

            #endregion

            #region Gravitation of a Player
            if(Keyboard.GetState().IsKeyDown(Keys.Space) && hasJumped == false)
            {
                position.Y -= 60f;
                velocity.Y -= -0.4f;
                hasJumped = true;
            }
            #endregion
        }

        public void Collisions(Rectangle newRectangle)
        {
            if(collisionRectangle.isOnTopOf(newRectangle))
            {
                collisionRectangle.Y  = newRectangle.Y - collisionRectangle.Height;
                velocity.Y = 0f;
                hasJumped = false;
            }
            else if(collisionRectangle.isOnLeftOf(newRectangle))
            {
                position.X = newRectangle.X - collisionRectangle.Width;
            }
            else if(collisionRectangle.isOnRightOf(newRectangle))
            {
                position.X = newRectangle.X + newRectangle.Width;
            }
            else if(collisionRectangle.isOnBottomOf(newRectangle)) // doesn´t do anything
            {
                velocity.Y = 1f;
            }
            
        }
    }
}
