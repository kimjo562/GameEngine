using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
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

        protected Entity _parent = null;
        protected List<Entity> _children = new List<Entity>();

        // The Location of the Entity
        // private Vector3 _location = new Vector3(0, 0, 1);
        // The Velocity of the Entity
         private Vector2 _velocity = new Vector2();
        // private Matrix3 _transform = new Matrix3();
        // private Matrix3 _translation = new Matrix3();
        // private Matrix3 _rotation = new Matrix3();
        // private Matrix3 _scale = new Matrix3();
        // private float _scale = 1.0f;
        private Matrix3 _localTransform = new Matrix3();
        private Matrix3 _globalTransform = new Matrix3();


        // The Character representing the Entity on the screen
        public char Icon { get; set; } = ' ';
        // The image representing the Entity on the screen.
        public SpriteEntity Sprite { get; set; }
        // Whether or not this Entity returns a collision.
        public bool Solid { get; set; } = false;
        // The Entity's relative origin
        public float OriginX { get; set; } = 0;
        public float OriginY { get; set; } = 0;


        // The Entity's location on the X axis
        public float X
        {
            get
            {
                return _localTransform.m1x3;
            }
            set
            {
                _localTransform.SetTranslation(value, Y, 1);
                UpdateTransform();
            }
        }
        // The Entity's location on the Y axis
        public float Y
        {
            get
            {
                return _localTransform.m2x3;
            }
            set
            {
                _localTransform.SetTranslation(X, value, 1);
                UpdateTransform();
            }
        }

        public float XAbsolute
        {
            get { return _globalTransform.m1x3; }
        }

        public float YAbsolute
        {
            get { return _globalTransform.m2x3; }
        }

        // The Entity's velocity on the X Axis
        public float XVelocity
        {
            get
            {
                 return _velocity.x;
                // return _translation.m1x3;
            }
            set
            {
                _velocity.x = value;
               // _translation.SetTranslation(value, YVelocity, 1);
            }
        }

        // The Entity's velocity on the Y Axis
        public float YVelocity
        {
            get
            {
                 return _velocity.y;
                // return _translation.m2x3;
            }
            set
            {
                 _velocity.y = value;
                // _translation.SetTranslation(XVelocity, value, 1);
            }
        }

        // The Entity's scale
        public float Size
        {
            get
            {
                return 1;
                // return _scale.m1x1;
                // return _scale;
            }
            //set
            //{
            //    _localTransform.SetScaled(value, value, 1);
            //    // _scale.SetScaled(value, value, 1);
            //    // _scale = value;

            //}
        }

        // The Entity's Rotation
        public float Rotation
        {
            get
            {
                return (float)Math.Atan2(_globalTransform.m2x1, _globalTransform.m1x1);
            }
            //set
            //{
            //    _localTransform.SetRotateZ(value);
            //}
        }

        //public float Width
        //{
        //    get
        //    {
        //        return Sprite.
        //    }
        //}

        private Scene _scene;
        // The Scene the Entity is currently in
        public Scene CurrentScene { set; get; }
        //The parent of this Entity
        public Entity Parent
        {
            get
            {
                return _parent;
            }
        }

        // Creates an Entity with default values
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
            Sprite = new SpriteEntity();
            Sprite.Load(imageName);
            AddChild(Sprite);
        }

        // Destructor
        ~Entity()
        {
            if(_parent != null)
            {
                _parent.RemoveChild(this);
            }
            foreach (Entity e in _children)
            {
                e._parent = null;
            }
        }

        public int GetChildCount()
        {
            return _children.Count;
        }

        public Entity GetChild(int index)
        {
            return _children[index];
        }

        public void AddChild(Entity child)
        {
            // Make sure the child already have a parent
            if(child != null && child._parent != null)
            {
                return;
            }
            // Assign this Entity as the child's parent
            child._parent = this;
            // Add new child to collection
            _children.Add(child);
        }

        public void RemoveChild(Entity child)
        {
            bool isMyChild = _children.Remove(child);
            if (isMyChild)
            {
                child._parent = null;
            }
        }

        public void Scale(float width, float height)
        {
            _localTransform.Scale(width, height, 1);
            UpdateTransform();
        }

        // Rotate the Entity by the specified amount
        public void Rotate(float radians)
        {
            _localTransform.RotateZ(radians);
            UpdateTransform();
        }

        protected void UpdateTransform()
        {
            if (_parent != null)
            {
                _globalTransform = _parent._globalTransform * _localTransform;
            }
            else
            {
                _globalTransform = _localTransform;
            }
            foreach (Entity child in _children)
            {
                child.UpdateTransform();
            }
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
            // _location += _velocity;
            // Matrix3 transform = _translation * _rotation;
            //_location = transform * _location;
            X += _velocity.x;
            Y += _velocity.y;
            UpdateTransform();
            OnUpdate?.Invoke();
        }

        // Call the Entity's OnDraw event
        public void Draw()
        {
            OnDraw?.Invoke();
        }
    }
}
