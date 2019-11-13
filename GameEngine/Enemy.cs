using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    class Enemy : Entity
    {
        private Direction _facing;
        private float _speed = 5f;

        public float Speed
        {
            get
            {
                return _speed;
            }
            set
            {
                _speed = value;
            }
        }

        public Enemy() : this('e')
        {

        }

        public Enemy(string imageName) : base('e', imageName)
        {
            _facing = Direction.North;
            OnUpdate += Move;
            OnUpdate += TouchPlayer;
            // Scale = 2.0f;
        }

        public Enemy(char icon) : base(icon)
        {
            _facing = Direction.North;
            OnUpdate += Move;
            OnUpdate += TouchPlayer;
            // Scale = 2.0f;
        }

        private void TouchPlayer(float deltaTime)
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

        private void Move(float deltaTime)
        {
            switch (_facing)
            {
                case Direction.North:
                    MoveUp(deltaTime);
                    break;

                case Direction.South:
                    MoveDown(deltaTime);
                    break;

                case Direction.East:
                    MoveRight(deltaTime);
                    break;

                case Direction.West:
                    MoveLeft(deltaTime);
                    break;
            }

        }

        private void MoveUp(float deltaTime)
        {
            // Move Up if the space is clear
            if (!CurrentScene.GetCollision(XAbsolute, Sprite.Top - Speed * deltaTime))
            {
                YVelocity =- Speed * deltaTime;
            }
            // Otherwise stop and change direction
            else
            {
                YVelocity = 0f;
                _facing++;
            }
        }

        private void MoveDown(float deltaTime)
        {
            // Move Down if the space is clear
            if (!CurrentScene.GetCollision(XAbsolute, Sprite.Bottom + Speed * deltaTime))
            {
                YVelocity = Speed * deltaTime;
            }
            // Otherwise stop and change direction
            else
            {
                YVelocity = 0f;
                _facing++;
            }
        }

        private void MoveRight(float deltaTime)
        {
            // Move Right if the space is clear
            if (!CurrentScene.GetCollision(Sprite.Right + Speed * deltaTime, YAbsolute))
            {
                XVelocity = Speed * deltaTime;
            }
            // Otherwise stop and change direction
            else
            {
                XVelocity = 0f;
                _facing++;
            }
        }

        private void MoveLeft(float deltaTime)
        {
            // Move Left if the space is clear
            if (!CurrentScene.GetCollision(Sprite.Left - Speed * deltaTime, YAbsolute))
            {
                XVelocity =- Speed * deltaTime;
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
