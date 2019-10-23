using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib;
using RL = Raylib.Raylib;

namespace GameEngine
{
    class Scene
    {
        // The List of all the Entities in the Scene
        public Event OnStart;
        public Event OnUpdate;
        public Event OnDraw;

        // The List of all the Entities in the Scene
        private List<Entity> _entities = new List<Entity>();
        // The list of the 
        private List<Entity> _removal = new List<Entity>();
        //The Size of the Scene
        private int _sizeX;
        private int _sizeY;
        // Grid for collision detection
        private bool[,] _wallCollision;
        // The grid for Entity Tracking
        private List<Entity>[,] _tracking;

        // Creates a Scene with a size of 24 x 8
        public Scene() : this(24, 8)
        {
            // If a size has not been set, it will default to this number. (public Scene() : "this" will also do this...)
            //_sizeX = 24;
            //_sizeY = 8;
        }

        // Creates a new Scene with the specified size
        // sizeX the horizontal side of the Scene
        // sizeY the vertical side of the Scene
        public Scene(int sizeX, int sizeY)
        {
            _sizeX = sizeX;
            _sizeY = sizeY;
            // Create the collison grid
            _wallCollision = new bool[_sizeX, _sizeY];
            // Create the tracking grid
            _tracking = new List<Entity>[_sizeX, _sizeY];

        }

        public int SizeX
        {
            get
            {
                return _sizeX;
            }
        }

        public int SizeY
        {
            get
            {
                return _sizeY;
            }
        }

        //        int counter = 0;
        public void Start()
        {
            OnStart?.Invoke();
            foreach (Entity e in _entities)
            {
                e.Start();
            }
        }

        public void Update()
        {
            OnUpdate?.Invoke();

            // Clear the tracking grid
            for (int y = 0; y < _sizeY; y++)
            {
                for (int x = 0; x < _sizeX; x++)
                {
                    _tracking[x, y] = new List<Entity>();
                }

            }
  
            foreach (Entity e in _removal)
            {
                // Remove e from _entities
                _entities.Remove(e);
            }
            _removal.Clear();

            // Clears the collision grid
            foreach (Entity e in _entities)
            {
                // Set the Entity's collision in the collision grid
                int x = (int)e.X;
                int y = (int)e.Y;
                if(e.X >= 0 && e.X < _sizeX && e.Y >= 0 && e.Y < _sizeY)
                {
                    // Add the Entity to the tracking grid
                    _tracking[x, y].Add(e);
                    // Only update this point in the gird if the Entity is solid
                    if(!_wallCollision[x,y])
                    {
                        _wallCollision[x, y] = e.Solid;
                    }
                }

            }

            foreach (Entity e in _entities)
            {
                //Call the Entity's Update events
                e.Update();
            }

        }

        // Called in game every step to render each Entitiy in game
        public void Draw()
        {
            OnDraw?.Invoke();

            // Clear the screen.
            Console.Clear();
            RL.ClearBackground(Color.BLACK);

            // Length = size of the screen.
            char[,] display = new char[_sizeX, _sizeY];

            foreach (Entity e in _entities)
            {
                // Position each Entity's icon in the display.
                if (e.X >= 0 && e.X < _sizeX && e.Y >= 0 && e.Y < _sizeY)
                {
                    display[(int)e.X, (int)e.Y] = e.Icon;
                }
            }

            // Render the display grid to the screen.
            for (int i = 0; i < _sizeY; i++)
            {
                for (int j = 0; j < _sizeX; j++)
                {
                    Console.Write(display[j, i]);
                    foreach (Entity e in _tracking [j, i])
                    {
                        RL.DrawTexture(e.Sprite, j * Game.SizeX, i * Game.SizeY, Color.PURPLE);
                    }
                }
                Console.WriteLine();
            }

            foreach (Entity e in _entities)
            {
                //Call the Entity's Update events
                e.Draw();
            }

            //            Console.Write("Say Oi Boi: " + counter);
        }

        public void AddEntity(Entity entity)
        {
            _entities.Add(entity);
            entity.CurrentScene = this;
        }

        public void RemoveEntity(Entity entity)
        {
            _removal.Add(entity);
            entity.CurrentScene = null;
        }

        // Clear the Scene of Entity
        public void ClearEntities()
        {
            // Nullify each Entity's Scene
            foreach (Entity e in _entities)
            {
                RemoveEntity(e);
            }
        }

        // Returns whether there is a solid Entity at the point.
        public bool GetCollision(float x, float y)
        {
            // Ensure the point is within the Scene
            if(x >= 0 && y >= 0 && x < _sizeX && y < _sizeY)
            {
                return _wallCollision[(int)x, (int)y];
            }
            // A point outside the Scene is a Collision (if set to true)
            else
            {
                return true;
            }
        }

        // Returns the List of Entities at a specified point
        public List<Entity> GetEntities(float x, float y)
        {
            // Ensures the point is within the Scene
            if (x >= 0 && y >= 0 && x < _sizeX && y < _sizeY)
            {
                return _tracking[(int)x, (int)y];
            }
            // A point outside the Scene is not a collision
            else
            {
                return new List<Entity>();
            }
        }

    }
}
