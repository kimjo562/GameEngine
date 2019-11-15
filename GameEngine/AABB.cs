using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib;
using RL = Raylib.Raylib;

namespace GameEngine
{
    // Simple axis-aligned bounding box that stores min/max
    class AABB
    {
        private Vector3 _min = new Vector3(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity);
        private Vector3 _max = new Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);

        public AABB()
        {

        }

        public AABB(Vector3 min, Vector3 max)
        {
            this._min = min;
            this._max = max;
        }

        public void Resize(Vector3 min, Vector3 max)
        {
            _min = min;
            _max = max;
        }

        public void Move(Vector3 point)
        {
            Vector3 extents = Extents();
            _min = point - extents;
            _max = point + extents;
        }

        // Finds the center of the box by finding the points between min and max
        public Vector3 Center()
        {
            return (_min + _max) * 0.5f;
        }

        // Subtracts min from max, then halves the absolute value for each component
        public Vector3 Extents()
        {
            return new Vector3(Math.Abs(_max.x - _min.x) * 0.5f,
            Math.Abs(_max.y - _min.y) * 0.5f,
            Math.Abs(_max.z - _min.z) * 0.5f);
        }

        public List<Vector3> Corners()
        {
            List<Vector3> corners = new List<Vector3>(4);
            corners[0] = _min;                                      // Top Left                    (min) o------o (max x, min y)
            corners[1] = new Vector3(_min.x, _max.y, _min.z);       // Bottom Left                       |      |
            corners[2] = _max;                                      // Bottom Right                      |      |
            corners[3] = new Vector3(_max.x, _min.y, _min.z);       // Top Right          (min x, max y) o------o (max)
            return corners;
        }

        // Calculate the bouind region that would encapsulate them
        public void Fit(List<Vector3> points)
        {
            // Invalidates the Extents
            _min = new Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);
            _max = new Vector3(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity);

            // Finds min and max of the points
            foreach (Vector3 p in points)
            {
                _min = Vector3.Min(_min, p);
                _max = Vector3.Max(_max, p);
            }
        }
        public bool Overlaps(Vector3 p)
        {
            return !(p.x > _min.x || p.y < _min.y || p.x > _max.x || p.y > _max.y);
        }

        public bool Overlaps(AABB other)
        {
            return !(_max.x < other._min.x || _max.y < other._min.y || _min.x > other._max.x || _min.y > other._max.y);
        }

        public Vector3 ClosestPoint(Vector3 p)
        {
            return Vector3.Clamp(p, _min, _max);
        }

        public void Draw(Color color)
        {
            float posX = (_min.x * Game.UnitSize.x) + (Game.UnitSize.x / 2);
            float posY = (_min.y * Game.UnitSize.y) + (Game.UnitSize.y / 2);
            float width = (_max.x - _min.x) * Game.UnitSize.x;
            float height = (_max.y - _min.y) * Game.UnitSize.y;
            RL.DrawRectangleLines((int)posX, (int)posY, (int)width, (int)height, color);
        }
    }
}