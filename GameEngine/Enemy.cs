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

        public float Speed { get; set; } = .15f;

        public Enemy() : this('e')
        {

        }

        public Enemy(string imageName) : base('e', imageName)
        {
            _facing = Direction.South;
            OnUpdate += Move;
            OnUpdate += TouchPlayer;
        }

        public Enemy(char icon) : base(icon)
        {
            _facing = Direction.South;
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
           // int direction = random.Next(0, 4);
            switch (_facing)
            {
                case Direction.North:
                    MoveUp();
                    break;

                case Direction.South:
                    MoveDown();
                    break;

                case Direction.East:
                    MoveRight();
                    break;

                case Direction.West:
                    MoveLeft();
                    break;
            }

        }

        private void MoveUp()
        {
            // Move Up if the space is clear
            if (!CurrentScene.GetCollision(X, Y - 1))
            {
                YVelocity = -Speed;
            }
            // Otherwise stop and change direction
            else
            {
                YVelocity = 0f;
                _facing++;
            }
        }

        private void MoveDown()
        {
            // Move Down if the space is clear
            if (!CurrentScene.GetCollision(X, Y + 1))
            {
                YVelocity = Speed;
            }
            // Otherwise stop and change direction
            else
            {
                YVelocity = 0f;
                _facing++;
            }
        }

        private void MoveRight()
        {
            // Move Right if the space is clear
            if (!CurrentScene.GetCollision(X + 1, Y))
            {
                XVelocity = Speed;
            }
            // Otherwise stop and change direction
            else
            {
                XVelocity = 0f;
                _facing++;
            }
        }

        private void MoveLeft()
        {
            // Move Left if the space is clear
            if (!CurrentScene.GetCollision(X - 1, Y))
            {
                XVelocity = -Speed;
            }
            // Otherwise stop and change direction
            else
            {
                XVelocity = 0f;
                _facing = 0;
            }
        }
    }
}
