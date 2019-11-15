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
        public static readonly Vector2 UnitSize = new Vector2(15, 16);
        // public static readonly int UnitSizeX = 15;
        // public static readonly int UnitSizeY = 16;
        private Player player;
        private Enemy enemy;

        // Whenever or not the game should finish running and exiting.
        public static bool GameOver = false;
        // The Scene we are currently running
        private static Scene _currentScene;
        // The Scene we are about to go to
        private static Scene _nextScene;
        // The timer for the entire Game
        private Timer _gameTimer;
        // The Camera for the 3d View
        // private Camera3D _camera;

        // Game Constructor
        public Game()
        {
            RL.InitWindow(800, 400, "Smote");
            RL.SetTargetFPS(30);

            _gameTimer = new Timer();

            /*            Raylib.Vector3 cameraPosition = new Raylib.Vector3(-10, -10, -10);
                        Raylib.Vector3 cameraTarget = new Raylib.Vector3(0, 0, 0);
                        Raylib.Vector3 cameraUp = new Raylib.Vector3(0, 0, -1);

                        _camera = new Camera3D(cameraPosition, cameraTarget, cameraUp);  */
        }

        private void Initalize()
        {
            Room startingRoom = LoadEntity("startingRoom.txt");
            Room northRoom = LoadEntity("northRoom.txt");
            Room southRoom = LoadEntity("southRoom.txt");
            Room eastRoom = LoadEntity("eastRoom.txt");
            Room westRoom = LoadEntity("westRoom.txt");

            startingRoom.North = northRoom;
            startingRoom.South = southRoom;
            startingRoom.East = eastRoom;
            startingRoom.West = westRoom;

            northRoom.South = startingRoom;
            southRoom.North = startingRoom;
            eastRoom.West = startingRoom;
            westRoom.East = startingRoom;


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

            Camera2D camera = new Camera2D();
            camera.zoom = 1;

            // Loops until the game is over.
            while (!GameOver && !RL.WindowShouldClose())
            {
                // Start the Scene if needed
                if(_currentScene != _nextScene)
                {
                    _currentScene = _nextScene;
                }

                
                // Update the Active Scene
                _currentScene.Update(_gameTimer.GetDeltaTime());

                // Start the Scene if needed
                if(!_currentScene.Started)
                {
                    _currentScene.Start();
                }
                // Draw the Active Scene
                RL.BeginDrawing();
                //   RL.BeginMode3D(_camera);
                RL.BeginMode2D(camera);
                _currentScene.Draw();
                //   RL.EndMode3D();
                RL.EndMode2D();
                RL.EndDrawing();

            }
            RL.CloseWindow();
        }

        // The Scene we are currently running
        public static Scene CurrentScene
        {
            set
            {
                _nextScene = value;
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

        private Room LoadEntity(string path)
        {
            StreamReader reader = new StreamReader(path);
            int width = 0;
            int height = 0;

            Int32.TryParse(reader.ReadLine(), out width);
            Int32.TryParse(reader.ReadLine(), out height);
            Room room = new Room(width, height);

            for (int y = 0; y < height; y++)
            {
                string row = reader.ReadLine();
                for (int x = 0; x < width; x++)
                {
                    char tile = row[x];
                    switch (tile)
                    {
                        case '@':
                            player = new Player("player.png");
                            room.AddEntity(player);
                            player.X = x;
                            player.Y = y;
                            // player.Sprite.X -= 0f;
                            // player.Sprite.Y -= 0f;

                            //Entity sword = new Entity('/', "sword.png");
                            //player.AddChild(sword);
                            //sword.Sprite.X += 1f;
                            //// sword.Sprite.Y += 0.5f;
                            //room.AddEntity(sword);
                            break;

                        case 'e':
                            enemy = new Enemy("eEnemy.png");
                            room.AddEntity(enemy);
                            enemy.X = x;
                            enemy.Y = y;
                            break;

                        case '0':
                            room.AddEntity(new Wall(x, y, '0', "0wall.png"));
                            break;

                    }
                }
            }

            return room;
        }
    }
}

// x = 23
// y = 10
// map