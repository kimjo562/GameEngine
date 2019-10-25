using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib;
using RL = Raylib.Raylib;

namespace GameEngine
{
    // [static] Unable to call instance of it, just only that it exists to do things.
    class PlayerInput
    {
        private delegate void KeyEvent(int key);

        private KeyEvent OnKeyPress;
        public void AddKeyEvent(Event action, int key)
        {
            void keyPressed(int keyPress)
            {
                if(key == keyPress)
                {
                    action();
                }
            }
            OnKeyPress += keyPressed;
        }

        public void InputDevice()
        {
            // ConsoleKey inputKey = Console.ReadKey().Key;
            int inputKey = RL.GetKeyPressed();
            OnKeyPress(inputKey);
        }
    }
}
