using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    class Matrix2
    {
        // Static reference to the identity matrix
        public static Matrix2 identity = new Matrix2();

        // Creates a Matrix2 equal to the ____ matrix
        public float m1x1, m1x2, m2x1, m2x2;

        public Matrix2()
        {
            m1x1 = 1; m1x2 = 0;   // 1 0 
            m2x1 = 0; m2x2 = 1;   // 0 1 
        }

        // Creates a Matrix2 with the specifited values.
        public Matrix2(float m1x1, float m1x2, float m2x1, float m2x2)
        {
            this.m1x1 = m1x1; this.m1x2 = m1x2;   // 1 0 
            this.m2x1 = m2x1; this.m2x2 = m2x2;   // 0 1 
        }

        // Matrix2 * Matrix2
        public static Matrix2 operator *(Matrix2 lhs, Matrix2 rhs)
        {
            return new Matrix2(
                (lhs.m1x1 * rhs.m1x1) + (lhs.m1x2 * rhs.m2x1),
                (lhs.m1x1 * rhs.m1x2) + (lhs.m1x2 * rhs.m2x2),
                (lhs.m2x1 * rhs.m1x1) + (lhs.m2x2 * rhs.m2x1),
                (lhs.m2x1 * rhs.m1x2) + (lhs.m2x2 * rhs.m2x2));
        }

        public static Vector2 operator *(Matrix2 lhs, Vector2 rhs)
        {
            return new Vector2((lhs.m1x1 * rhs.x) + (lhs.m1x2 * rhs.y),
                               (lhs.m2x1 * rhs.x) + (lhs.m2x2 * rhs.y));
        }

        public override string ToString()
        {
            return "{ " + m1x1 + ", " + m1x2 + "\n "
                        + m2x1 + ", " + m2x2 + " }";

        }
    }
}
