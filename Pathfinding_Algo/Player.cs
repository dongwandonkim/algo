using System;
namespace Pathfinding_Algo
{
    public class Player
    {
        public int PosY { get; private set; }
        public int PosX { get; private set; }

        Board _board;

        public void Initialize(int posY, int posX, int dextY, int destX, Board board)
        {
            PosY = posY;
            PosX = posX;

            _board = board;
        }

        const int MOVE_TICK = 100;
        int _sumTick = 0;
        public void Update(int deltaTick)
        {
            _sumTick += deltaTick;
            if (_sumTick >= MOVE_TICK)
            {
                _sumTick = 0;
            }
        }
    }
}

