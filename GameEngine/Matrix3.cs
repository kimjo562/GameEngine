using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    class Matrix3
    {
        // Creates a Matrix3 equal to the ____ matrix
        public float m1x1, m1x2, m1x3, m2x1, m2x2, m2x3, m3x1, m3x2, m3x3;

        public Matrix3()
        {
            m1x1 = 1; m1x2 = 0; m1x3 = 0;  // 1 0 0
            m2x1 = 0; m2x2 = 1; m2x3 = 0;  // 0 1 0
            m3x1 = 0; m3x2 = 0; m3x3 = 1;  // 0 0 1
        }

        // Creates a Matrix3 with the specifited values.
        public Matrix3(float m1x1, float m1x2, float m1x3, float m2x1, float m2x2, float m2x3, float m3x1, float m3x2, float m3x3)
        {
            this.m1x1 = m1x1; this.m1x2 = m1x2; this.m1x3 = m1x3;  // 1 0 0
            this.m2x1 = m2x1; this.m2x2 = m2x2; this.m2x3 = m2x3;  // 0 1 0
            this.m3x1 = m3x1; this.m3x2 = m3x2; this.m3x3 = m3x3;  // 0 0 1
        }

        public static Matrix3 operator *(Matrix3 lhs, Matrix3 rhs)
        {
            return new Matrix3(
                (lhs.m1x1 * rhs.m1x1) + (lhs.m1x2 * rhs.m2x1) + (lhs.m1x3 * rhs.m3x1),
                (lhs.m1x1 * rhs.m1x2) + (lhs.m1x2 * rhs.m2x2) + (lhs.m1x3 * rhs.m2x2),  // First Matrix
                (lhs.m1x1 * rhs.m1x1) + (lhs.m1x2 * rhs.m2x3) + (lhs.m1x3 * rhs.m3x3),

                (lhs.m2x1 * rhs.m1x1) + (lhs.m2x2 * rhs.m2x1) + (lhs.m2x1 * rhs.m3x1),
                (lhs.m2x1 * rhs.m1x2) + (lhs.m2x2 * rhs.m2x2) + (lhs.m2x2 * rhs.m3x2),  // Second Matrix
                (lhs.m2x1 * rhs.m1x1) + (lhs.m2x2 * rhs.m2x3) + (lhs.m2x3 * rhs.m3x3),

                (lhs.m3x1 * rhs.m1x1) + (lhs.m3x2 * rhs.m2x1) + (lhs.m3x3 * rhs.m3x1),
                (lhs.m3x1 * rhs.m1x2) + (lhs.m3x2 * rhs.m2x2) + (lhs.m3x3 * rhs.m3x2),  // Third Matrix
                (lhs.m3x1 * rhs.m1x3) + (lhs.m3x2 * rhs.m2x3) + (lhs.m3x3 * rhs.m3x3));
        }

        public static Vector3 operator *(Matrix3 lhs, Vector3 rhs)
        {
            return new Vector3(
                (lhs.m1x1 * rhs.x) + (lhs.m1x2 * rhs.y) + (lhs.m1x3 * rhs.z),   // X Vector
                (lhs.m2x1 * rhs.x) + (lhs.m2x2 * rhs.y) + (lhs.m2x3 * rhs.z),   // Y Vector
                (lhs.m3x1 * rhs.x) + (lhs.m3x2 * rhs.y) + (lhs.m3x3 * rhs.z));  // Z Vector
        }
    }
}
