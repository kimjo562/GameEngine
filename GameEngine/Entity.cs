using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    delegate void Event();

    class Entity
    {
        // The List of all the Entities in the Scene
        public Event OnStart;
        public Event OnUpdate;
        public Event OnDraw;

        private Vector2 _location = new Vector2();

        public char Icon { get; set; } = ' ';
        public bool Solid { get; set; } = false;
        public float X
        {
            get
            {
                return _location.x;
            }
            set
            {
                _location.x = value;
            }
        }

        public float Y
        {
            get
            {
                return _location.y;
            }
            set
            {
                _location.y = value;
            }
        }

        private Scene _scene;

        public Scene CurrentScene
        {
            set
            {
                _scene = value;
            }
            get
            {
                return _scene;
            }
        }

        public Entity()
        {


        }

        // Overloaded Constructor
        public Entity(char icon)
        {
            Icon = icon;
        }

        public void Start()
        {
            // Checks to see if the Delegate has something in it.
            OnStart?.Invoke();
        }

        public void Update()
        {
            OnUpdate?.Invoke();
        }

        public void Draw()
        {
            OnDraw?.Invoke();
        }
    }
}
