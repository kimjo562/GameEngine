using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    class Enemy : Entity
    {
        Random random = new Random();
        private Direction _facing;

        public Enemy() : this('e')
        {


        }

        public Enemy(char icon) : base(icon)
        {
            _facing = Direction.South;
            OnUpdate += Move;
            OnUpdate += Move;
            OnUpdate += TouchPlayer;
        }

        private void TouchPlayer()
        {
            List<Entity> touched;
            touched = CurrentScene.GetEntities(X, Y);
            bool hit = false;
            foreach(Entity e in touched)
            {
                if (e is Player)
                {
                    hit = true;
                    break;
                }
            }

            if(hit == true)
            {
                CurrentScene.RemoveEntity(this);
            }
        }

        private void Move()
        {
            int direction = random.Next(0, 4);
            switch (direction)
            {
                case 0:
                    MoveUp();
                    break;

                case 1:
                    MoveDown();
                    break;

                case 2:
                    MoveRight();
                    break;

                case 3:
                    MoveLeft();
                    break;
            }

        }

        private void MoveUp()
        {
            if (!CurrentScene.GetCollision(X, Y - 1))
            {
                Y--;
            }
            else
            {
                _facing++;
            }
        }

        private void MoveDown()
        {
            if (!CurrentScene.GetCollision(X, Y + 1))
            {
                Y++;
            }
            else
            {
                _facing++;
            }
        }

        private void MoveRight()
        {
            if (!CurrentScene.GetCollision(X + 1, Y))
            {
                X++;
            }
            else
            {
                _facing++;
            }
        }

        private void MoveLeft()
        {
            if (!CurrentScene.GetCollision(X - 1, Y))
            {
                X--;
            }
            else
            {
                _facing = 0;
            }
        }
    }
}
