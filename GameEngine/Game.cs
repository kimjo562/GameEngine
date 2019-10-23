using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib;
using RL = Raylib.Raylib;

namespace GameEngine
{
    class Game
    {
        // The tilesize of the game (px x px)
        public static readonly int SizeX = 16;
        public static readonly int SizeY = 16;
        private Player player;
        private Enemy enemy;

        // Whenever or not the game should finish running and exiting.
        public static bool GameOver = false;
        private static Scene _currentScene;

        // Game Constructor
        public Game()
        {
            RL.InitWindow(800, 600, "Smote");
            RL.SetTargetFPS(10);
        }

        private void Initalize()
        {
            Room startingRoom = (Room)LoadEntity("startingRoom.txt");      
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

            StartRoom();

            // Add Walls to the Scene


            void StartRoom()
            {
                // Create a Player and position it
                player = new Player("player.png");
                player.X = 14;
                player.Y = 3;
                // Create a Enemy and position it
                enemy = new Enemy("eEnemy.png");
                enemy.X = 2;
                enemy.Y = 1;

                // Add Enemy and Player to the Scene
                startingRoom.AddEntity(player);
                startingRoom.AddEntity(enemy);
            }

            CurrentScene = startingRoom;
        }

        // When called from main, it should run game until it stops.
        public void Run()
        {
            /* 
              Press escape button to close the game.
            PlayerInput.AddKeyEvent(ExitButton, ConsoleKey.Escape);
            */

            Initalize();

            // Loops until the game is over.
            while (!GameOver && !RL.WindowShouldClose())
            {
                _currentScene.Update();

                RL.BeginDrawing();
                _currentScene.Draw();
                RL.EndDrawing();

                PlayerInput.ReadKey();
            }
            RL.CloseWindow();
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

        private Scene LoadEntity(string path)
        {
            int width;
            int height;
            StreamReader reader = new StreamReader(path);

            Int32.TryParse(reader.ReadLine(), out width);
            Int32.TryParse(reader.ReadLine(), out height);
            reader.Close();

            Scene scene = new Room(width, height);
            string[] lines = File.ReadAllLines(path);

            int counter = 0;

            foreach (string line in lines)
            {
                for (int i = 0; i > line.Length; i++)
                {
                    if(line[i] == '@')
                    {
                        player = new Player();
                        scene.AddEntity(player);
                    }
                    if (line[i] == 'e')
                    {
                        enemy = new Enemy();
                        scene.AddEntity(enemy);
                    }

                    // Finds wall
                    if (line[i] == '0')
                    {
                        scene.AddEntity(new Wall(counter, i, '0', "0wall.png"));
                    }
                    else if (line[i] == 'O')
                    {
                        scene.AddEntity(new Wall(counter, i, 'O', "Owall.png"));
                    }
                    else if (line[i] == '1')
                    {
                        scene.AddEntity(new Wall(counter, i, '1', "1corner.png"));
                    }
                    else if (line[i] == '2')
                    {
                        scene.AddEntity(new Wall(counter, i, '2', "2corner.png"));
                    }
                    else if (line[i] == '3')
                    {
                        scene.AddEntity(new Wall(counter, i, '3', "3corner.png"));
                    }
                    else if (line[i] == '4')
                    {
                        scene.AddEntity(new Wall(counter, i, '4', "4corner.png"));
                    }
                    else if (line[i] == '5')
                    {
                        scene.AddEntity(new Wall(counter, i, '5', "5nub.png"));
                    }
                    else if (line[i] == '6')
                    {
                        scene.AddEntity(new Wall(counter, i, '6', "6nub.png"));
                    }
                    else if (line[i] == '7')
                    {
                        scene.AddEntity(new Wall(counter, i, '7', "7nub.png"));
                    }
                    else if (line[i] == '8')
                    {
                        scene.AddEntity(new Wall(counter, i, '8', "8nub.png"));
                    }
                }
                counter++;
            }

            return scene;
        }
    }
}

// x = 23
// y = 10
// map