using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AdventureGame
{
    public class OreGenerater
    {
        private List<int[,]> Templates;
        private string filePath;
        private Random random;

        public OreGenerater(string filePath)
        {
            Templates = new List<int[,]>();
            random = new Random();
            this.filePath = filePath;
        }

        public void LoadOres()
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                int[,] template = new int[4,4];
                int j = 0;
                int lineNumber = 1;

                while( (line = sr.ReadLine()) != null)
                {
                    
                    if( (lineNumber % 5) != 0)
                    {
                        for(int i = 0; i < 4; i++)
                        {
                            template[i, j] = int.Parse(line[i].ToString());
                        }
                        j++;

                        if(j > 3)
                        {
                            Templates.Add(template);
                            j = 0;
                            template = new int[4, 4];
                        }
                    }
                    lineNumber++;

                }
            }
        }


    }
}
