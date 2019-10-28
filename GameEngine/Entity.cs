using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib;
using RL = Raylib.Raylib;

namespace GameEngine
{
    delegate void Event();

    class Entity
    {
        // The List of all the Entities in the Scene
        public Event OnStart;
        public Event OnUpdate;
        public Event OnDraw;

        // The Location of the Entity
        private Vector2 _location = new Vector2();
        // The Velocity of th Entity
        private Vector2 _velocity = new Vector2();

        // The Character representing the Entity on the screen
        public char Icon { get; set; } = ' ';
        // The image representing the Entity on the screen.
        public Texture2D Sprite { get; set; }
        // Whether or not this Entity returns a collision.
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

        // The Entity's velocity on the X Axis
        public float XVelocity
        {
            get
            {
                return _velocity.x;
            }
            set
            {
                _velocity.x = value;
            }
        }

        // The Entity's velocity on the Y Axis
        public float YVelocity
        {
            get
            {
                return _velocity.y;
            }
            set
            {
                _velocity.y = value;
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

        // Creates an Entity with the specified icon and image
        public Entity(char icon, string imageName) : this(icon)
        {
            Sprite = RL.LoadTexture(imageName);
        }

        // Call the Entity's OnStart event
        public void Start()
        {
            // Checks to see if the Delegate has something in it.
            OnStart?.Invoke();
        }

        // Call the Entity's OnUpdate event
        public void Update()
        {
            _location += _velocity;
            OnUpdate?.Invoke();
        }

        // Call the Entity's OnDraw event
        public void Draw()
        {
            OnDraw?.Invoke();
        }
    }
}
