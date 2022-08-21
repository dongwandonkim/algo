using System;

namespace Pathfinding_Algo
{
    class Program
    {


        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            int lastTick = 0;
            const int WAIT_TICK = 1000 / 30;

            while (true)
            {
                int currentTick = System.Environment.TickCount;
                int elapsedTick = currentTick - lastTick;

                // if elapsedTick is less than 1/30 seconds
                if (elapsedTick < 1000 / 30)
                {
                    continue;
                }
                lastTick = currentTick;
                // user input

                // logic

                // render
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Hello World!");
            }

        }
    }
}

