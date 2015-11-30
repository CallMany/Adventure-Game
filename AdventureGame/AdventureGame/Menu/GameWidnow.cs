using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace AdventureGame
{
    public class GameWindow
    {
        Game game; 
        List<GameComponent> Components;


        // Constructor
        public GameWindow(Game game, params GameComponent[] components)
        {
            this.game = game;
            this.Components = new List<GameComponent>();

            foreach (GameComponent Component in components)
            {
                AddComponent(Component);
            }
        }

        // Add Component to List and 'Components' in game class
        public void AddComponent(GameComponent component)
        {
            Components.Add(component);
            if (!game.Components.Contains(component))
                game.Components.Add(component);
        }

        // Return Components in 'Components'
        public GameComponent[] GetComponents()
        {
            return Components.ToArray();
        }
    }
}
