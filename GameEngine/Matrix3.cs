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

        public static Matrix3 identity = new Matrix3();

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

        // Sets this Matrix3 to the specified values
        public void Set(float m1x1, float m1x2, float m1x3, float m2x1, float m2x2, float m2x3, float m3x1, float m3x2, float m3x3)
        {
            this.m1x1 = m1x1; this.m1x2 = m1x2; this.m1x3 = m1x3;  
            this.m2x1 = m2x1; this.m2x2 = m2x2; this.m2x3 = m2x3;  
            this.m3x1 = m3x1; this.m3x2 = m3x2; this.m3x3 = m3x3;  
        }

        //Set this Matrix3 to the values of the specified Matrix3
        public void Set(Matrix3 matrix3)
        {
            m1x1 = matrix3.m1x1; m1x2 = matrix3.m1x2; m1x3 = matrix3.m1x3;
            m2x1 = matrix3.m2x1; m2x2 = matrix3.m2x2; m2x3 = matrix3.m2x3;
            m3x1 = matrix3.m3x1; m3x2 = matrix3.m3x2; m3x3 = matrix3.m3x3;
        }

        public static Matrix3 operator *(Matrix3 lhs, Matrix3 rhs)
        {
            return new Matrix3(
                (lhs.m1x1 * rhs.m1x1) + (lhs.m1x2 * rhs.m2x1) + (lhs.m1x3 * rhs.m3x1),
                (lhs.m1x1 * rhs.m1x2) + (lhs.m1x2 * rhs.m2x2) + (lhs.m1x3 * rhs.m3x2),  // First Matrix
                (lhs.m1x1 * rhs.m1x3) + (lhs.m1x2 * rhs.m2x3) + (lhs.m1x3 * rhs.m3x3),

                (lhs.m2x1 * rhs.m1x1) + (lhs.m2x2 * rhs.m2x1) + (lhs.m2x3 * rhs.m3x1),
                (lhs.m2x1 * rhs.m1x2) + (lhs.m2x2 * rhs.m2x2) + (lhs.m2x3 * rhs.m3x2),  // Second Matrix
                (lhs.m2x1 * rhs.m1x3) + (lhs.m2x2 * rhs.m2x3) + (lhs.m2x3 * rhs.m3x3),

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

        public void SetScaled(float x, float y, float z)
        {
            m1x1 = x; m1x2 = 0; m1x3 = 0;
            m2x1 = 0; m2x2 = y; m2x3 = 0;
            m3x1 = 0; m3x2 = 0; m3x3 = z;
        }
        public void SetScaled(Vector3 vec)
        {
            m1x1 = vec.x; m1x2 = 0; m1x3 = 0;
            m2x1 = 0; m2x2 = vec.y; m2x3 = 0;
            m3x1 = 0; m3x2 = 0; m3x3 = vec.z;  
        }

        public void Scale(float x, float y, float z)
        {
            Matrix3 m = new Matrix3();
            m.SetScaled(x, y, z);
        }

        public void Scale(Vector3 vec)
        {
            Matrix3 m = new Matrix3();
            m.SetScaled(vec.x, vec.y, vec.z);
        }

        public void SetRotateX(double radians)
        {
            Set(1,                        0,                         0,
                0, (float)Math.Cos(radians), (float)-Math.Sin(radians),
                0, (float)Math.Sin(radians), (float)Math.Cos(radians));
        }

        public void SetRotateY(double radians)
        {
            Set((float)Math.Cos(radians), 0, (float)Math.Sin(radians),
                0,                        1,                        0,
               (float)-Math.Sin(radians), 0 ,(float)Math.Cos(radians));
        }


        public void SetRotateZ(double radians)
        {
            Set((float)Math.Cos(radians), (float)-Math.Sin(radians), 0,
                (float)Math.Sin(radians), (float)Math.Cos(radians),  0,
                0,                     0,                            1);
        }

        public void RotateX(double radians)
        {
            Matrix3 m = new Matrix3();
            m.SetRotateX(radians);

            Set(this * m);
        }

        public void RotateY(double radians)
        {
            Matrix3 m = new Matrix3();
            m.SetRotateY(radians);

            Set(this * m);
        }

        public void RotateZ(double radians)
        {
            Matrix3 m = new Matrix3();
            m.SetRotateZ(radians);

            Set(this * m);
        }

        public void SetEuler(float pitch, float yaw, float roll)
        {
            Matrix3 x = new Matrix3();
            Matrix3 y = new Matrix3();
            Matrix3 z = new Matrix3();

            x.SetRotateX(pitch);
            y.SetRotateY(yaw);
            z.SetRotateZ(roll);

            // Combine rotations in a specific order
            Set(z * y * x);
        }

        public void SetTranslation(float x, float y, float z)
        {
            m1x3 = x; m2x3 = y; m3x3 = z;
        }

        public void Translate(float x, float y, float z)
        {
            // apply vector offset
            m1x3 += x; m2x3 += y; m3x3 += z;
        }

        public override string ToString()
        {
            return "{ " + m1x1 + ", " + m1x2 + ", " + m1x3 + "\n "
                        + m2x1 + ", " + m2x2 + ", " + m2x3 + "\n "
                        + m3x1 + ", " + m3x2 + ", " + m3x3 + " }";
        }
    }
}
