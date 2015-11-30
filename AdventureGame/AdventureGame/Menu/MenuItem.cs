using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;


namespace AdventureGame
{
    public class MenuItem
    {
        public string text;
        public Vector2 position;
        public float size;

        public MenuItem(string text, Vector2 position)
        {
            this.text = text;
            this.position = position;
            size = 0.9f;
        }
    }
}

