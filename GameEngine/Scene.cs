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
        // Events that are called when the scene is Started, Updated and Drawn.
        public Event OnStart;
        public Event OnUpdate;
        public Event OnDraw;

        // The List of all the Entities in the Scene
        private List<Entity> _entities = new List<Entity>();
        // The list of Entities to add from the Scene
        private List<Entity> _additions = new List<Entity>();
        // The list of Entities to remove from the Scene
        private List<Entity> _removals = new List<Entity>();
        //The Size of the Scene
        private int _sizeX;
        private int _sizeY;
        // Grid for collision detection
        private bool[,] _wallCollision;
        // The grid for Entity Tracking
        private List<Entity>[,] _tracking;
        private bool _started = false;
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

        public bool Started
        {
            get { return _started; }
        }

        //        int counter = 0;
        public void Start()
        {
            OnStart?.Invoke();
            foreach (Entity e in _entities)
            {
                e.Start();
            }
            _started = true;
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
  
            // Add all the Entities readied for addition
            foreach(Entity e in _additions)
            {
                // Add e to _entities
                _entities.Add(e);
            }
            _additions.Clear();

            foreach (Entity e in _removals)
            {
                // Remove e from _entities
                _entities.Remove(e);
            }
            _removals.Clear();

            // Clears the collision grid
            foreach (Entity e in _entities)
            {
                // Set the Entity's collision in the collision grid
                int x = (int)e.XAbsolute;
                int y = (int)e.YAbsolute;
                // Only update if the Entity is within bounds.
                if(e.XAbsolute >= 0 && e.XAbsolute < _sizeX && e.YAbsolute >= 0 && e.YAbsolute < _sizeY)
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
                int x = (int)e.XAbsolute;
                int y = (int)e.YAbsolute;
                if (x >= 0 && x < _sizeX && y >= 0 && y < _sizeY)
                {
                    display[x, y] = e.Icon;
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
                        if(e.Sprite == null)
                        {
                            continue;  // Skips this item in _tracking
                        }
                        // RL.DrawTexture(e.Sprite, (int)(e.X * Game.SizeX), (int)(e.Y * Game.SizeY), Color.PURPLE);
                        // Texture 
                        Texture2D texture = e.Sprite.Texture;
                        // Position
                        float positionX = e.Sprite.XAbsolute * Game.UnitSize.x;
                        float positionY = e.Sprite.YAbsolute * Game.UnitSize.y;
                        Raylib.Vector2 position = new Raylib.Vector2(positionX, positionY);
                        // Rotation
                        float rotation = e.Rotation * (float)(180.0f/Math.PI);
                        // Scale
                        float scale = e.Sprite.Size;
                        // Draw
                        RL.DrawTextureEx(texture, position, rotation, scale, Color.PURPLE);
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
            // Ensure the Entity is not already added
            if(_additions.Contains(entity))
            {
                return;
            }
            // Ready the Tntity for addition
            _additions.Add(entity);
            // Set this Scene as the Entity's Scene
            entity.CurrentScene = this;
        }

        public void RemoveEntity(Entity entity)
        {
            // Ensure the Entity is not already removed
            if (_removals.Contains(entity))
            {
                return;
            }
            // Ready the Entity for removal
            _removals.Add(entity);
            // Nullify the Entity's Scene
            entity.CurrentScene = null;
        }

        // Clear the Scene of Entities and nullify their Scenes
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
            int checkX = (int)Math.Round(x);
            int checkY = (int)Math.Round(y);
            // Ensures the point is within the Scene
            if (checkX >= 0 && checkY >= 0 && checkX < _sizeX && checkY < _sizeY)
            {
                return _tracking[checkX, checkY];
            }
            // A point outside the Scene is not a collision
            else
            {
                return new List<Entity>();
            }
        }

    }
}
