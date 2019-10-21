using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    enum Direction
    {
        North,
        South,
        East,
        West,
    }


    class Room : Scene
    {
        // Rooms connnected to this one
        private Room _north;
        private Room _south;
        private Room _east;
        private Room _west;

        public Room() : this(24, 8)
        {

        }

        public Room(int sizeX, int sizeY) : base(sizeX, sizeY)
        {

        }

        public Room North
        {
            get
            {
                return _north;
            }
            set
            {
                if (value != null)
                {
                    // Connect the Rooms both ways
                    value._south = this;
                }
                else
                {
                    _north._south = null;
                }
                _north = value;
            }
        }

        public Room South
        {
            get
            {
                return _south;
            }
            set
            {
                if (value != null)
                {
                    value._north = this;
                }
                else
                {
                    _south._north = null;
                }
                _south = value;
            }
        }

        public Room East
        {
            get
            {
                return _east;
            }
            set
            {
                if (value != null)
                {
                    value._west = this;
                }
                else
                {
                    _east._west = null;
                }
                _east = value;
            }
        }

        public Room West
        {
            get
            {
                return _west;
            }
            set
            {
                if (value != null)
                {
                    value._east = this;
                }
                else
                {
                    _west._east = null;
                }
                _west = value;
            }
        }
    }
}
