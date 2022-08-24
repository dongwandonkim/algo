using System;

namespace Pathfinding_Algo
{
    class Program
    {


        static void Main(string[] args)
        {
            Board board = new Board();
            Player player = new Player();
            board.Initialize(25, player);
            player.Initialize(1, 1, board.Size - 2, board.Size - 2, board);

            Console.CursorVisible = false;

            int lastTick = 0;
            const int WAIT_TICK = 1000 / 30; // 1/30 seconds - 30fps
            while (true)
            {
                #region FPS
                int currentTick = System.Environment.TickCount;
                int elapsedTick = currentTick - lastTick;

                // if elapsedTick is less than 1/30 seconds
                if (elapsedTick < WAIT_TICK)
                {
                    continue;
                }
                int deltaTick = currentTick - lastTick;
                lastTick = currentTick;
                #endregion
                // user input

                // logic
                player.Update(deltaTick);

                // render
                Console.SetCursorPosition(0, 0);
                board.Render();
            }

        }
    }
}

