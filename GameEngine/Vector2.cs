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
            this.x = x;
            this.y = y;
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

        public float Magnitude()
        {
            return (float)Math.Sqrt((x * x) + (y * y));
        }

        public float MagnitudeSqr()
        {
            return (x * x) + (y * y);
        }

        public void Normalize()
        {
            float m = Magnitude();
            this.x /= m;
            this.y /= m;
        }

        public Vector2 GetNormalised()
        {
            return (this / Magnitude());
        }

        public float Distance(Vector2 other)
        {
            float diffX = x - other.x;
            float diffY = y - other.y;
            return (float)Math.Sqrt(diffX * diffX + diffY * +diffY);
        }

        public float DotProduct(Vector2 other)
        {
            return (x * other.x) + (y * other.y);
        }

        public Vector2 GetPerpRH()
        {
            return new Vector2 (-y, x);
        }

        public Vector2 GetPerpLH()
        {
            return new Vector2(-x, y);
        }

        public float GetAngle(Vector2 other)
        {
            // normalise the vectors
            Vector2 a = GetNormalised();
            Vector2 b = other.GetNormalised();

            // return the angle between them
            return (float)Math.Acos(a.DotProduct(b));
        }

        public override string ToString()
        {
            return "{ " + x + ", " + y + " }";
        }

    }
}
