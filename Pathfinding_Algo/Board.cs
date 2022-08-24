using System;
using System.Collections.Generic;

namespace Pathfinding_Algo
{


    public class Board
    {
        const char CIRCLE = '\u25cf';

        public TileType[,] Tile { get; private set; }
        public int Size { get; private set; }

        Player _player;

        public enum TileType
        {
            Empty,
            Wall
        }


        public void Initialize(int size, Player player)
        {
            if (size % 2 == 0) return;

            Tile = new TileType[size, size];
            Size = size;
            //
            _player = player;

            //GenerateBinaryTreeMaze();
            GenerateSideWinderMaze();

        }
        public void GenerateSideWinderMaze()
        {
            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                    {
                        Tile[y, x] = TileType.Wall;
                    }
                    else
                    {
                        Tile[y, x] = TileType.Empty;
                    }
                }
            }

            // create path
            Random rand = new Random();
            for (int y = 0; y < Size; y++)
            {
                int count = 0;
                for (int x = 0; x < Size; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                    {
                        continue;
                    }

                    if (y == Size - 2 && x == Size - 2) continue;

                    // second last
                    if (y == Size - 2)
                    {
                        Tile[y, x + 1] = TileType.Empty;
                        continue;
                    }
                    if (x == Size - 2)
                    {
                        Tile[y + 1, x] = TileType.Empty;
                        continue;
                    }

                    // create path 50% right or bottom
                    if (rand.Next(0, 2) == 0)
                    {
                        Tile[y, x + 1] = TileType.Empty;
                        count++;
                    }
                    else
                    {
                        int randomIndex = rand.Next(0, count);
                        // go back 2 indexes where it was TileType.Emply initialy
                        Tile[y + 1, x - randomIndex * 2] = TileType.Empty;
                        count = 0;
                    }
                }
            }

        }

        public void GenerateBinaryTreeMaze()
        {
            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                    {
                        Tile[y, x] = TileType.Wall;
                    }
                    else
                    {
                        Tile[y, x] = TileType.Empty;
                    }
                }
            }

            // create path
            Random rand = new Random();
            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                    {
                        continue;
                    }

                    if (y == Size - 2 && x == Size - 2) continue;

                    // second last
                    if (y == Size - 2)
                    {
                        Tile[y, x + 1] = TileType.Empty;
                        continue;
                    }
                    if (x == Size - 2)
                    {
                        Tile[y + 1, x] = TileType.Empty;
                        continue;
                    }

                    // create path 50% right or bottom
                    if (rand.Next(0, 2) == 0)
                    {
                        Tile[y, x + 1] = TileType.Empty;
                    }
                    else
                    {
                        Tile[y + 1, x] = TileType.Empty;
                    }
                }
            }
        }

        public void Render()
        {
            ConsoleColor prevColor = Console.ForegroundColor;

            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    if (y == _player.PosY && x == _player.PosX)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    else
                    {
                        Console.ForegroundColor = GetTileColor(Tile[y, x]);
                    }


                    Console.Write(CIRCLE);
                }
                Console.WriteLine();
            }

            Console.ForegroundColor = prevColor;
        }

        ConsoleColor GetTileColor(TileType type)
        {
            switch (type)
            {
                case TileType.Empty:
                    return ConsoleColor.Green;
                case TileType.Wall:
                    return ConsoleColor.Red;
                default:
                    return ConsoleColor.Green;
            }
        }
    }
}

