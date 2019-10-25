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
        // Instead of using base we can use this (which will "this" will go to icon and to the "base" icon and goes through all the constuctors).
        public Player() : this('@')
        {

        }

        public Player(string imageName) : base('@', imageName)
        {
            OnUpdate += _input.InputDevice;

            // Binds movement methods to wasd.
            _input.AddKeyEvent(MoveRight, 100); // D
            _input.AddKeyEvent(MoveLeft, 97); // A
            _input.AddKeyEvent(MoveUp, 119); // W
            _input.AddKeyEvent(MoveDown, 115); // S
        }

        // Creates a new PLayer with the specified symbol and adds movement key event.
        public Player(char icon) : base(icon)
        {
            OnUpdate += _input.InputDevice;

            // Binds movement methods to wasd.
            _input.AddKeyEvent(MoveRight, 100); // D
            _input.AddKeyEvent(MoveLeft, 97); // A
            _input.AddKeyEvent(MoveUp, 119); // W
            _input.AddKeyEvent(MoveDown, 115); // S
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

            // Remove the player from its current Room
            CurrentScene.RemoveEntity(this);
            // Add the Player to the destination Room
            destination.AddEntity(this);
            // Change the Game's active Scene to the destination
            Game.CurrentScene = destination;
        }
    }
}
