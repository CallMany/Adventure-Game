using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventureGame
{
    static class RectangleHelper
    {

        public static bool isOnTopOf(this Rectangle r1, Rectangle r2)
        {
            return (r1.Bottom >= r2.Top - 1 &&
                    r1.Bottom <= r2.Top + (r2.Height / 2) &&
                    r1.Right >= r2.Left + r2.Width / 5 &&
                    r1.Left <= r2.Right - r2.Width / 5);
        }

        public static bool isOnBottomOf(this Rectangle r1, Rectangle r2)
        {
            return (r1.Top <= r2.Bottom + (r2.Width / 5) &&
                    r1.Top >= r2.Bottom - 1 &&
                    r1.Right >= r2.Left + (r2.Width / 5) &&
                    r1.Left <= r2.Right - (r2.Width / 5));
        }

        public static bool isOnLeftOf(this Rectangle r1, Rectangle r2)
        {
            return (r1.Right <= r2.Right &&
                    r1.Right >= r2.Left - 4 &&
                    r1.Top <= r2.Bottom - (r2.Width / 5) &&
                    r1.Bottom >= r2.Top + (r2.Width / 5)
                );
        }

        public static bool isOnRightOf(this Rectangle r1, Rectangle r2)
        {
            return (r1.Left >= r2.Left &&
                    r1.Left <= r2.Right &&
                    r1.Top <= r2.Bottom - (r2.Width / 5) &&
                    r1.Bottom >= r2.Top + (r2.Width / 5)
                );
        }
    }
}
