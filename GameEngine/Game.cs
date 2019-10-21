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
        private static Scene _currentScene;

        // Game Constructor
        public Game()
        {

        }

        private void Initalize()
        {
            Room startingRoom = new Room();
            Room northRoom = new Room();
            Room southRoom = new Room();
            Room eastRoom = new Room();
            Room westRoom = new Room();

            startingRoom.North = northRoom;
            startingRoom.South = southRoom;
            startingRoom.East = eastRoom;
            startingRoom.West = westRoom;

            northRoom.South = startingRoom;
            southRoom.North = startingRoom;
            eastRoom.West = startingRoom;
            westRoom.East = startingRoom;

            // Add Walls to the Scene
            for (int i = 0; i < startingRoom.SizeX; i++)
            {
                if (i != 5)
                {
                    startingRoom.AddEntity(new Wall(i, 5));
                    startingRoom.AddEntity(new Wall(i, 4));

                    startingRoom.AddEntity(new Wall(i, 0));
                    startingRoom.AddEntity(new Wall(i, 7));


                    northRoom.AddEntity(new Wall(i, 5));
                    northRoom.AddEntity(new Wall(i, 4));

                    northRoom.AddEntity(new Wall(i, 0));
                    northRoom.AddEntity(new Wall(i, 7));


                    southRoom.AddEntity(new Wall(i, 5));
                    southRoom.AddEntity(new Wall(i, 4));

                    southRoom.AddEntity(new Wall(i, 0));
                    southRoom.AddEntity(new Wall(i, 7));


                    eastRoom.AddEntity(new Wall(i, 5));
                    eastRoom.AddEntity(new Wall(i, 4));

                    eastRoom.AddEntity(new Wall(i, 0));
                    eastRoom.AddEntity(new Wall(i, 7));


                    westRoom.AddEntity(new Wall(i, 5));
                    westRoom.AddEntity(new Wall(i, 4));

                    westRoom.AddEntity(new Wall(i, 0));
                    westRoom.AddEntity(new Wall(i, 7));
                }
            }

            for (int i = 0; i < startingRoom.SizeY; i++)
            {
                if (i != 2 && i != 6)
                {
                    startingRoom.AddEntity(new Wall(0, i));
                    startingRoom.AddEntity(new Wall(23, i));

                    northRoom.AddEntity(new Wall(0, i));
                    northRoom.AddEntity(new Wall(23, i));

                    southRoom.AddEntity(new Wall(0, i));
                    southRoom.AddEntity(new Wall(23, i));

                    eastRoom.AddEntity(new Wall(0, i));
                    eastRoom.AddEntity(new Wall(23, i));

                    westRoom.AddEntity(new Wall(0, i));
                    westRoom.AddEntity(new Wall(23, i));
                }
            }

            // Create a Player and position it
            Entity player = new Player('■');
            player.X = 3;
            player.Y = 3;
            // Create a Enemy and position it
            Entity enemy = new Enemy('e');
            enemy.X = 2;
            enemy.Y = 1;

            // Add Enemy and Player to the Scene
            startingRoom.AddEntity(player);
            startingRoom.AddEntity(enemy);

            CurrentScene = startingRoom;
        }

        // When called from main, it should run game until it stops.
        public void Run()
        {
            Initalize();

            PlayerInput.AddKeyEvent(ExitButton, ConsoleKey.Escape);

            // Loops until the game is over.
            while (!GameOver)
            {
                _currentScene.Update();
                _currentScene.Draw();
                PlayerInput.ReadKey();
            }
        }

        // The Scene we are currently running
        public static Scene CurrentScene
        {
            set
            {
                _currentScene = value;
                _currentScene.Start();
            }
            get
            {
                return _currentScene;
            }
        }
        

        public void ExitButton()
        {
            Game.GameOver = true;
            Console.Clear();
            Console.WriteLine("Now Closing the Game.");
            Console.ReadKey();
            for (int i = 5; i > 0; i--)
            {
                Console.Clear();
                Console.WriteLine("Logging out in " + i + "...");
                System.Threading.Thread.Sleep(1000);

            }
        }


    }
}