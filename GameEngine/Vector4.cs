using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    class Vector4
    {
        public float w, x, y, z;

        public Vector4()
        {
            w = 0;
            x = 0;
            y = 0;
            z = 0;
        }

        public Vector4(float w, float x, float y, float z)
        {
            this.w = w;
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static Vector4 operator +(Vector4 _vec1, Vector4 _vec2)
        {
            return new Vector4((_vec1.w + _vec2.w), (_vec1.x + _vec2.x), (_vec1.y + _vec2.y), (_vec1.z + _vec2.z));
        }

        public static Vector4 operator -(Vector4 _vec1, Vector4 _vec2)
        {
            return new Vector4((_vec1.w - _vec2.w), (_vec1.x - _vec2.x), (_vec1.y - _vec2.y), (_vec1.z - _vec2.z));
        }

        public static Vector4 operator *(float number, Vector4 _vec2)
        {
            return new Vector4((number * _vec2.w), (number * _vec2.x), (number * _vec2.y), (number * _vec2.z));
        }

        public static Vector4 operator *(Vector4 _vec1, float number)
        {
            return new Vector4((_vec1.w * number), (_vec1.x * number), (_vec1.y * number), (_vec1.z * number));
        }

        public static Vector4 operator /(float number, Vector4 _vec2)
        {
            return new Vector4((number / _vec2.w), (number / _vec2.x), (number / _vec2.y), (number / _vec2.z));
        }

        public static Vector4 operator /(Vector4 _vec1, float number)
        {
            return new Vector4((number / _vec1.w), (number / _vec1.x), (number / _vec1.y), (number / _vec1.z));
        }

        public float Magnitude()
        {
            return (float)Math.Sqrt((x * x) + (y * y) + (z * z));
        }

        public float MagnitudeSqr()
        {
            return (x * x) + (y * y) + (z * z);
        }

        public float Distance(Vector3 other)
        {
            float diffX = x - other.x;
            float diffY = y - other.y;
            float diffZ = z - other.z;
            return (float)Math.Sqrt(diffX * diffX + diffY * +diffY + diffZ * diffZ);
        }

        // Makes the Vector unit length meaning its Magnitude is 1.
        public void Normalize()
        {
            float m = Magnitude();
            this.w /= m;
            this.x /= m;
            this.y /= m;
            this.z /= m;
        }

        public Vector4 GetNormalised()
        {
            return (this / Magnitude());
        }
    }
}
