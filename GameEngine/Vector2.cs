using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    class Vector2
    {
        public float x, y;

        public Vector2()
        {
            x = 0;
            y = 0;
        }

        public Vector2(float x, float y)
        {
            this.x = 0;
            this.y = 0;
        }

        // Vector2 + Vector2
        public static Vector2 operator +(Vector2 _vec1, Vector2 _vec2)
        {
            return new Vector2 ((_vec1.x + _vec2.x), (_vec1.y + _vec2.y));
        }

        // Vector2 - Vector2
        public static Vector2 operator -(Vector2 _vec1, Vector2 _vec2)
        {
            return new Vector2((_vec1.x - _vec2.x), (_vec1.y - _vec2.y));
        }

        // Vector2 * Float
        public static Vector2 operator *(float number, Vector2 _vec2)
        {
            return new Vector2((number * _vec2.x), (number * _vec2.y));
        }

        // Float * Vector2
        public static Vector2 operator *(Vector2 _vec1, float number)
        {
            return new Vector2((_vec1.x * number), (_vec1.y * number));
        }

        // Vector2/ Float
        public static Vector2 operator /(float number, Vector2 _vec2)
        {
            return new Vector2((number / _vec2.x), (number / _vec2.y));
        }

        // Float / Vector 2
        public static Vector2 operator /(Vector2 _vec1, float number)
        {
            return new Vector2((number / _vec1.x ), (number / _vec1.y));
        }
    }
}
