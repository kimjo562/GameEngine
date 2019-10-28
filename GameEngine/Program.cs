using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    class Program
    {
        static void Main(string[] args)
        {
/*          
            //Find the Magnitude
            Console.WriteLine(new Vector3(1f, 1f, 1f).MagnitudeSqr());
            Console.WriteLine(new Vector2(3, -2).MagnitudeSqr());
            Console.WriteLine(new Vector3(-1f, 1f, -1f).MagnitudeSqr());
            Console.WriteLine(new Vector3(0.5f, -1f, 0.25f).MagnitudeSqr());

            //Finds the Distance
            Console.WriteLine(new Vector2(-2f, 5.5f).Distance(new Vector2(9f, -22f)));
            Console.WriteLine(new Vector3(0f, 1f, 2f).Distance(new Vector3(9f, -2f, 7f)));
            Console.ReadKey();
            return;
*/
            // Create a new game and run it.
            Game game = new Game();
            game.Run();
        }
    }
}
