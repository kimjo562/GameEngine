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
            //Examples();
            //return;

            // Create a new game and run it.
            Game game = new Game();
            game.Run();
        }


        static void Examples()
        {
            //Find the Magnitude
            Console.WriteLine(new Vector3(1f, 1f, 1f).MagnitudeSqr());
            Console.WriteLine(new Vector2(3, -2).MagnitudeSqr());
            Console.WriteLine(new Vector3(-1f, 1f, -1f).MagnitudeSqr());
            Console.WriteLine(new Vector3(0.5f, -1f, 0.25f).MagnitudeSqr());


            //Finds the Distance
            Console.WriteLine(new Vector2(-2f, 5.5f).Distance(new Vector2(9f, -22f)));
            Console.WriteLine(new Vector3(0f, 1f, 2f).Distance(new Vector3(9f, -2f, 7f)));
            Console.ReadKey();


            Console.WriteLine(new Vector2(1f, 2f));
            Console.WriteLine(new Vector2(1f, 0f).DotProduct(new Vector2(0f, 1f)));
            Console.WriteLine(new Vector2(1f, 1f).DotProduct(new Vector2(-1f, -1f)));
            Console.WriteLine(new Vector3(2f, 3f, 1f).DotProduct(new Vector3(-3f, 1f, 2f)));

            Console.WriteLine(new Vector3(2f, 3f, 1f).CrossProduct(new Vector3(-3f, 1f, 2f)));
            Console.WriteLine(new Vector2(1f, 3f).GetAngle(new Vector2(0.5f, -0.25f)));
            Console.WriteLine(new Vector3(-0.5f, 0f, 2f).GetAngle(new Vector3(-1f, 0f, -1f)));



            Vector3 up = new Vector3(0f, 1f, 0f);
            Vector3 playerLoc = new Vector3(10f, 0f, 18f);
            Vector3 enemyLoc = new Vector3(-7.5f, 0f, 9f);
            Vector3 enemyDir = new Vector3(0.857f, 0f, -0.514f);

            Vector3 enemytoPlayer = playerLoc - enemyLoc;

            Console.WriteLine("Distance from enemy to player: " + enemytoPlayer);

            // Is the player in front of the enemy?
            if (enemyDir.DotProduct(enemytoPlayer) > 0)
            {
                Console.WriteLine("Player is in front of enemy.");
            }
            else
            {
                Console.WriteLine("Player is behind enemy.");
            }

            Vector3 enemyLeft = enemyDir.CrossProduct(up);

            if (enemyLeft.DotProduct(enemytoPlayer) > 0)
            {
                Console.WriteLine("Player is in left of enemy.");
            }
            else
            {
                Console.WriteLine("Player is right enemy.");
            }

            // Is the PLayer in the enemy's FOV
            if (enemyDir.GetAngle(enemytoPlayer) > Math.PI / 4 || enemyDir.GetAngle(enemytoPlayer) >= 7 * Math.PI / 4)
            {
                Console.WriteLine("I see you boi.");
            }

            Console.ReadKey();
        }
    }
}
