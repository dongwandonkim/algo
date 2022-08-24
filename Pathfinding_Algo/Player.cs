using System;
namespace Pathfinding_Algo
{
    public class Player
    {
        public int PosX { get; private set; }
        public int PosY { get; private set; }

        public void Initialize(int posX, int posY)
        {
            PosX = posX;
            PosY = posY;
        }
    }
}

