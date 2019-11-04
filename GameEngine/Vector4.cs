using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    class Vector4
    {
        public float x, y, z, w;

        public Vector4()
        {
            x = 0;
            y = 0;
            z = 0;
            w = 0;
        }

        public Vector4(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public static Vector4 operator +(Vector4 _vec1, Vector4 _vec2)
        {
            return new Vector4((_vec1.x + _vec2.x), (_vec1.y + _vec2.y), (_vec1.z + _vec2.z), (_vec1.w + _vec2.w));
        }

        public static Vector4 operator -(Vector4 _vec1, Vector4 _vec2)
        {
            return new Vector4((_vec1.x - _vec2.x), (_vec1.y - _vec2.y), (_vec1.z - _vec2.z), (_vec1.w - _vec2.w));
        }

        public static Vector4 operator *(float number, Vector4 _vec2)
        {
            return new Vector4((number * _vec2.y), (number * _vec2.z), (number * _vec2.w), (number * _vec2.x));
        }

        public static Vector4 operator *(Vector4 _vec1, float number)
        {
            return new Vector4((_vec1.x * number), (_vec1.y * number), (_vec1.z * number), (_vec1.w * number));
        }

        public static Vector4 operator /(float number, Vector4 _vec2)
        {
            return new Vector4((number / _vec2.x), (number / _vec2.y), (number / _vec2.z), (number / _vec2.w));
        }

        public static Vector4 operator /(Vector4 _vec1, float number)
        {
            return new Vector4((number / _vec1.x), (number / _vec1.y), (number / _vec1.z), (number / _vec1.w));
        }

        public float Magnitude()
        {
            return (float)Math.Sqrt((x * x) + (y * y) + (z * z) + (w * w));
        }

        public float MagnitudeSqr()
        {
            return (x * x) + (y * y) + (z * z) + (w * w);
        }

        public float Distance(Vector4 other)
        {
            float diffX = x - other.x;
            float diffY = y - other.y;
            float diffZ = z - other.z;
            float diffW = w - other.w;
            return (float)Math.Sqrt(diffX * diffX + diffY * +diffY + diffZ * diffZ + diffW * diffW);
        }

        // Makes the Vector unit length meaning its Magnitude is 1.
        public void Normalize()
        {
            float m = Magnitude();
            this.x /= m;
            this.y /= m;
            this.z /= m;
            this.w /= m;
        }

        public Vector4 GetNormalised()
        {
            return (this / Magnitude());
        }

        public float DotProduct(Vector4 other)
        {
            return x * other.x + y * other.y + z * other.z + w * other.w;
        }

        public Vector4 CrossProduct(Vector4 other)
        {
            return new Vector4((y * other.z - z * other.y), (z * other.x - x * other.z), (x * other.y - y * other.x), 0);
        }


        /*
                public static Vector4 operator +(Vector4 lhs, Vector4 rhs)
                {
                    return new Vector4(
                   lhs.x + rhs.x,
                   lhs.y + rhs.y,
                   lhs.z + rhs.z,
                   lhs.w + rhs.w);
                }

                public static Vector4 operator -(Vector4 lhs, Vector4 rhs)
                {
                    return new Vector4(
                   lhs.x - rhs.x,
                   lhs.y - rhs.y,
                   lhs.z - rhs.z,
                   lhs.w - rhs.w);
                }

                public static Vector4 operator *(Vector4 lhs, float rhs)
                {
                    return new Vector4(
                   lhs.x * rhs,
                   lhs.y * rhs,
                   lhs.z * rhs,
                   lhs.w * rhs);
                }
        */
    }
}
