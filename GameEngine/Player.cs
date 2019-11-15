using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    class Player : Entity
    {
        private PlayerInput _input = new PlayerInput();
        private Entity _sword = new Entity('/', "sword.png");

        // Instead of using base we can use this (which will "this" will go to icon and to the "base" icon and goes through all the constuctors).
        public Player() : this('@')
        {

        }

        public Player(string imageName) : base('@', imageName)
        {
            OnUpdate += _input.InputDevice;
            OnUpdate += Orbit;
            OnStart += CreateSword;
            OnStart += AttachSword;

            // Binds movement methods to wasd.
            _input.AddKeyEvent(MoveRight, 100); // D
            _input.AddKeyEvent(MoveLeft, 97); // A
            _input.AddKeyEvent(MoveUp, 119); // W
            _input.AddKeyEvent(MoveDown, 115); // S
            _input.AddKeyEvent(DetachSword, 113); // Q
            _input.AddKeyEvent(AttachSword, 101); // E
        }

        // Creates a new PLayer with the specified symbol and adds movement key event.
        public Player(char icon) : base(icon)
        {
            OnUpdate += _input.InputDevice;
            OnUpdate += Orbit;

            // Binds movement methods to wasd.
            _input.AddKeyEvent(MoveRight, 100); // D
            _input.AddKeyEvent(MoveLeft, 97); // A
            _input.AddKeyEvent(MoveUp, 119); // W
            _input.AddKeyEvent(MoveDown, 115); // S
            _input.AddKeyEvent(DetachSword, 113); // Q
            _input.AddKeyEvent(AttachSword, 101); // E
        }

        private void Orbit(float deltaTime)
        {
            foreach (Entity child in _children)
            {
                child.Rotate(-2.5f * deltaTime);
            }
              // Rotate(0.1f);
        }

        //Create and add a sword to the scene
        private void CreateSword()
        {
            CurrentScene.AddEntity(_sword);
            _sword.X = X;
            _sword.Y = Y;
        }

        // Add sword as a child
        private void AttachSword()
        {
            if (_sword.CurrentScene != CurrentScene || GetDistance(_sword) > 1)
            //if(!Hitbox.Overlaps(_sword.Hitbox))
            {
                return;
            }
            AddChild(_sword);
            _sword.X = 1f;
            _sword.Y = 0.5f;
        }

        // Drops the sword
        private void DetachSword()
        {
            RemoveChild(_sword);
        }

        public Entity Sword
        {
            get { return _sword; }
        }

        // Move one space to the right.
        private void MoveRight()
        {
            if (X + 1 > CurrentScene.SizeX - 1)
            {
                if (CurrentScene is Room)
                {
                    Room dest = (Room)CurrentScene;
                    Travel(dest.East);
                }
                X = 0;
            }
            else if (!CurrentScene.GetCollision(X + 1, Y))
            {
                X++;
            }
        }

        // Move one space to the left.
        private void MoveLeft()
        {
            if (X - 1 < 0)
            {
                if (CurrentScene is Room)
                {
                    Room dest = (Room)CurrentScene;
                    Travel(dest.West);
                }
                X = CurrentScene.SizeX;
            }
            if (!CurrentScene.GetCollision(X - 1, Y))
            {
                X--;
            }
        }

        // Move one space up
        private void MoveUp()
        {
            if(Y - 1 < 0)
            {
                if(CurrentScene is Room)
                {
                    Room dest = (Room)CurrentScene;
                    Travel(dest.North);
                }
                Y = CurrentScene.SizeY;
            }
            if (!CurrentScene.GetCollision(X, Y - 1))
            {
                Y--;
            }
        }

        // Move one space down
        private void MoveDown()
        {
            if(Y + 1 > CurrentScene.SizeY - 1)
            {
                if (CurrentScene is Room)
                {
                    Room dest = (Room)CurrentScene;
                    Travel(dest.South);
                }
                Y = 0;
            }
            else if (!CurrentScene.GetCollision(X, Y + 1))
            {
                Y++;
            }
        }

        // Move the player to the destination Room and change the Scene
        private void Travel(Room destination)
        {
            // Ensure destination is not null
            if (destination == null)
            {
                return;
            }

            if (_sword.Parent == this)
            {
                // Remove the sword from the current room
                CurrentScene.RemoveEntity(_sword);
                destination.AddEntity(_sword);
            }

            // Remove the player from its current Room
            CurrentScene.RemoveEntity(this);
            // Add the Player to the destination Room
            destination.AddEntity(this);
            // Change the Game's active Scene to the destination
            Game.CurrentScene = destination;
        }
    }
}
