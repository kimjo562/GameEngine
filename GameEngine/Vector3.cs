using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    class Vector3
    {
        public float x, y, z;

        public Vector3()
        {
            x = 0;
            y = 0;
            z = 0;
        }

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static Vector3 operator +(Vector3 _vec1, Vector3 _vec2)
        {
            return new Vector3((_vec1.x + _vec2.x), (_vec1.y + _vec2.y), (_vec1.z + _vec2.z));
        }

        public static Vector3 operator -(Vector3 _vec1, Vector3 _vec2)
        {
            return new Vector3((_vec1.x - _vec2.x), (_vec1.y - _vec2.y), (_vec1.z - _vec2.z));
        }

        public static Vector3 operator *(float number, Vector3 _vec2)
        {
            return new Vector3((number * _vec2.x), (number * _vec2.y), (number * _vec2.z));
        }

        public static Vector3 operator *(Vector3 _vec1, float number)
        {
            return new Vector3((_vec1.x * number), (_vec1.y * number), (_vec1.z * number));
        }

        public static Vector3 operator /(float number, Vector3 _vec2)
        {
            return new Vector3((number / _vec2.x), (number / _vec2.y), (number / _vec2.z));
        }

        public static Vector3 operator /(Vector3 _vec1, float number)
        {
            return new Vector3((number / _vec1.x), (number / _vec1.y), (number / _vec1.z));
        }

        // Returns the magnitude of Vector3
        public float Magnitude()
        {
            return (float)Math.Sqrt((x * x) + (y * y) + (z * z));
        }

        // Returns the sqaure of the magnitude of Vector3
        public float MagnitudeSqr()
        {
            return (x * x) + (y * y) + (z * z);
        }

        // Return the distance between this Vectoe3 and another
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
            x /= m;
            y /= m;
            z /= m;
        }

        public Vector3 GetNormalised()
        {
            return (this / Magnitude());
        }

        public float DotProduct(Vector3 other)
        {
            return x * other.x + y * other.y + z * other.z;
        }

        public Vector3 CrossProduct(Vector3 other)
        {
            return new Vector3((y * other.z - z * other.y), (z * other.x - x * other.z), (x * other.y - y * other.x));
        }

        public float GetAngle(Vector3 other)
        {
            // normalise the vectors
            Vector3 a = GetNormalised();
            Vector3 b = other.GetNormalised();

            // return the angle between them
            return (float)Math.Acos(a.DotProduct(b));
        }

        public override string ToString()
        {
            return "{ " + x + ", " + y + ", " + z + " }";
        }

    }
}
