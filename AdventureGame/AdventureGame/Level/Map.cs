using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace AdventureGame
{
    class Map
    {
        #region Variables + Properties

        private int[,] mapSize = new int[10, 11];

        private List<Rectangle> rectangles = new List<Rectangle>();
        public List<Rectangle> Rectangles
        {
            get { return rectangles; }
        }

        private List<CollisionTiles> collisionTiles = new List<CollisionTiles>(); // Cube list
        public List<CollisionTiles> CollisionTiles
        {
            get { return collisionTiles; }
        }

        #endregion

        public Map() { } 

        public void Update()
        {
            // collisions destroyed cube were solved by this code
            for (int i = 0; i < CollisionTiles.Count; i++)
            {
                if(CollisionTiles[i].isEnabled == false)
                {
                    CollisionTiles.Remove(CollisionTiles[i]);
                }
            }

         
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (CollisionTiles tile in collisionTiles)
            {
                tile.Draw(spriteBatch);
            }
        }


        #region Other functions

        public void MakeRectangleGrid(int sizeX, int sizeY)
        {

            for (int y = 0; y < sizeY; y++)
            {
                for(int x = 0; x < sizeX; x++)
                {
                    rectangles.Add(new Rectangle(y * 64, x * 64, 64, 64));
                }
            }
        }

        public void AddBlock(Point position, int i)
        {
            collisionTiles.Add(new CollisionTiles(i, new Rectangle(position.X, position.Y, 64, 64))); // right click 
        }

        public void GenerateWorld(string mapName)
        {
            if (!File.Exists("newMap"))
            {
                using (StreamWriter sw = new StreamWriter(mapName))
                {
                    for (int y = 0; y < mapSize.GetLength(1); y++)
                    {
                        for (int x = 0; x < mapSize.GetLength(0); x++)
                        {
                            if ( x != 0 && x < mapSize.GetLength(0))
                            {
                                sw.Write(',');
                            }

                            if (y < 3)
                            {
                                sw.Write("0");    
                            }
                            else if (y == 3)
                                sw.Write("2");
                            else if (y > 3)
                                sw.Write("1");
                        }
                        sw.WriteLine("");
                    }
                    sw.Flush();
                }

            }
        }


        public void LoadWorld(string mapPath, int sizeOfBlock)
        {
            MakeRectangleGrid(mapSize.GetLength(1), mapSize.GetLength(0)); // x --> 1 ; y ---> 0

            using (StreamReader sr = new StreamReader(mapPath))
            {
                int x = 0;
                int y = 0;
                int number;

                do
                {
                    x = 0;
                    string line = sr.ReadLine();
                    string[] numbers = line.Split(',');

                    for (int i = 0; i < numbers.Length; i++)
                    {
                        if (numbers[i] == "")
                        {
                            x = 0;
                            return;
                        }

                        number = int.Parse(numbers[i]);

                        if (number > 0)
                        {
                            collisionTiles.Add(new CollisionTiles(number, new Rectangle(x * sizeOfBlock, y * sizeOfBlock, sizeOfBlock, sizeOfBlock)));
                        }
                        x++;
                    }
                    y++;

                } while (!sr.EndOfStream);
            }
        } 

        #endregion


    }
}
