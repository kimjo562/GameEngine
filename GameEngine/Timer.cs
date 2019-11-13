using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics; // Used for Stopwatch

namespace GameEngine
{
    class Timer
    {
        private Stopwatch _stopwatch = new Stopwatch();

        // Long is like an Int but Long(er)
        private long _currentTime = 0;
        private long _previousTime = 0;

        private float _deltaTime = 0.005f;

        public Timer()
        {
            _stopwatch.Start();
        }

        public void Restart()
        {
            _stopwatch.Restart();
        }

        // Get time in seconds
        public float Seconds
        {
            get { return _stopwatch.ElapsedMilliseconds / 1000.0f; }
        }

        // The difference between the current time and the previous time (deltatime)
        public float GetDeltaTime()
        {
            _previousTime = _currentTime;
            _currentTime = _stopwatch.ElapsedMilliseconds;
            _deltaTime = (_currentTime - _previousTime) / 1000.0f;
            return _deltaTime;
        }
    }
}
