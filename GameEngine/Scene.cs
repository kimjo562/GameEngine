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

        public Scene()
        {
            // If a size has not been set, it will default to this number.
            _sizeX = 24;
            _sizeY = 8;
        }

        public Scene(int sizeX, int sizeY)
        {
            _sizeX = sizeX;
            _sizeY = sizeY;
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
                    display[e.X, e.Y] = e.Icon;
                }
            }

            for (int i = 0; i < _sizeY; i++)
            {
                for (int j = 0; j < _sizeX; j++)
                {
                    Console.Write(display[j, i]);
                }
                Console.WriteLine("|");
            }
            //            Console.Write("Say Oi Boi: " + counter);
        }

        public void AddEntity(Entity entity)
        {
            _entities.Add(entity);
            entity.MyScene = this;
        }

        public void RemoveEntity(Entity entity)
        {
            _entities.Remove(entity);
            entity.MyScene = null;
        }

        public void ClearEntities()
        {
            foreach (Entity e in _entities)
            {
                e.MyScene = null;
            }
            _entities.Clear();
        }
    }
}
