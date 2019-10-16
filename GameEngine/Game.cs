using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    class Game
    {
        // Whenever or not the game should finish running and exiting.
        public static bool GameOver = false;

        private Scene _currentScene;

        // Game Constructor
        public Game()
        {
            _currentScene = new Scene();
        }

        // When called from main, it should run game until it stops.
        public void Run()
        {
            Entity player = new Player('■');
            player.X = 6;
            player.Y = 4;

            Entity enemy = new Entity('#');
            enemy.X = 2;
            enemy.Y = 1;

            _currentScene.AddEntity(player);
            _currentScene.AddEntity(enemy);
            _currentScene.Start();

            // Loops until the game is over.
            while(!GameOver)
            {
                _currentScene.Update();
                _currentScene.Draw();
                PlayerInput.ReadKey();

            }
        }

        public Scene CurrentScene
        {
            get
            {
                return _currentScene;
            }
        }

    }
}