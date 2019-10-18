using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    class Player : Entity
    {
        // Instead of using base we can use this (which will "this" will go to icon and to the "base" icon and goes through all the constuctors).
        public Player() : this('■')
        {

        }

        public Player(char icon) : base(icon)
        {
            PlayerInput.AddKeyEvent(MoveRight, ConsoleKey.RightArrow);
            PlayerInput.AddKeyEvent(MoveLeft, ConsoleKey.LeftArrow);
            PlayerInput.AddKeyEvent(MoveUp, ConsoleKey.UpArrow);
            PlayerInput.AddKeyEvent(MoveDown, ConsoleKey.DownArrow);
        }

        // Move one space to the right.
        private void MoveRight()
        {
            if(!CurrentScene.GetCollision(X + 1, Y))
            {
                X++;
            }
        }

        // Move one space to the left.
        private void MoveLeft()
        {
            if(!CurrentScene.GetCollision(X - 1, Y))
            {
                X--;
            }
        }

        private void MoveUp()
        {
            if (!CurrentScene.GetCollision(X, Y - 1))
            {
                Y--;
            }
        }

        private void MoveDown()
        {
            if (!CurrentScene.GetCollision(X, Y + 1))
            {
                Y++;
            }
        }
    }
}
