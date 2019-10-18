using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    class Scene
    {
        private List<Entity> _entities = new List<Entity>();
        private int _sizeX;
        private int _sizeY;
        // Grid for collision detection
        private bool[,] _wallCollision;

        public Scene() : this(24, 8)
        {
            // If a size has not been set, it will default to this number. (public Scene() : "this" will also do this...)
            //_sizeX = 24;
            //_sizeY = 8;
        }

        public Scene(int sizeX, int sizeY)
        {
            _sizeX = sizeX;
            _sizeY = sizeY;
            // Create the collison grid
            _wallCollision = new bool[_sizeX, _sizeY];

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
            foreach (Entity e in _entities)
            {
                e.Start();
            }
        }

        public void Update()
        {
            //            counter++;
            foreach (Entity e in _entities)
            {
                e.Update();
                int x = (int)e.X;
                int y = (int)e.Y;
                if(e.X >= 0 && e.X < _sizeX && e.Y >= 0 && e.Y < _sizeY)
                {
                    if(!_wallCollision[x,y])
                    {
                        _wallCollision[x, y] = e.Solid;
                    }
                }

            }
        }

        public void Draw()
        {
            // Clear the screen.
            Console.Clear();

            // Length = size of the screen.
            char[,] display = new char[_sizeX, _sizeY];

            foreach (Entity e in _entities)
            {
                e.Draw();
                // Position each Entity's icon in the display.
                if (e.X >= 0 && e.X < _sizeX && e.Y >= 0 && e.Y < _sizeY)
                {
                    display[(int)e.X, (int)e.Y] = e.Icon;
                }
            }

            for (int i = 0; i < _sizeY; i++)
            {
                for (int j = 0; j < _sizeX; j++)
                {
                    Console.Write(display[j, i]);
                }
                Console.WriteLine();
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
            _entities.Remove(entity);
            entity.CurrentScene = null;
        }

        // Clear the Scene of Entity
        public void ClearEntities()
        {
            foreach (Entity e in _entities)
            {
                e.CurrentScene = null;
            }
            _entities.Clear();
        }

        // Returns whether there is a solid Entity at the point.
        public bool GetCollision(float x, float y)
        {
            if(x >= 0 && y >= 0 && x < _sizeX && y < _sizeY)
            {
                return _wallCollision[(int)x, (int)y];
            }
            else
            {
                return true;
            }
        }

    }
}
