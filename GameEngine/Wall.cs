using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    class Wall : Entity
    {
        public Wall(int x, int y) : base('0', /*file name */ "yes.png")
        {
            X = x;
            Y = y;
            Solid = true;
        }

        public Wall(int x, int y, char icon, string imageName) : base('0', imageName)
        {
            X = x;
            Y = y;
            Solid = true;
        }
    }
}
