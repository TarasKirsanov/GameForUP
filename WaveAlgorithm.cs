using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbit__Game
{
    public static class WaveAlgorithm
    {
        static void Swap(ref int x, ref int y) { int z = x; x = y; y = z; }
        public static void Print(int[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {

                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j] + " ");
                }
                Console.WriteLine();

            }
        }
        public static int NextStep(int startX, int startY, int targetX, int targetY, Grid grid)
        {
            bool add = true;
            int[,] cMap = new int[grid.countOfColumns, grid.countOfRows];
            int x, y, step = 0;
            for (x = 0; x < grid.countOfRows; x++)
                for (y = 0; y < grid.countOfColumns; y++)
                {
                    if (!grid.IsFree(x, y))
                        cMap[x, y] = -2;//индикатор стены
                    else
                        cMap[x, y] = -1;//индикатор еще не ступали сюда
                }
            cMap[startX, startY] = 0;//Начинаем с финиша
            while (add)
            {
                add = false;
                for (x = 0; x < grid.countOfRows; x++)
                    for (y = 0; y < grid.countOfColumns; y++)
                    {
                        if (cMap[x, y] == step)
                        {
                            //Ставим значение шага+1 в соседние ячейки (если они проходимы)
                            if (grid.IsFree(x - 1, y) && cMap[x - 1, y] == -1)
                                cMap[x - 1, y] = step + 1;
                            if (grid.IsFree(x, y - 1) && cMap[x, y - 1] == -1)
                                cMap[x, y - 1] = step + 1;
                            if (grid.IsFree(x + 1, y) && cMap[x + 1, y] == -1)
                                cMap[x + 1, y] = step + 1;
                            if (grid.IsFree(x, y + 1) && cMap[x, y + 1] == -1)
                                cMap[x, y + 1] = step + 1;
                        }
                    }
                add = true;
                int currX = targetX, currY = targetY;
                if (cMap[targetX, targetY] != -1)//решение найдено
                {
                    Print(cMap);
                    while (step != 0)
                    {

                        if (currX - 1 >= 0 && cMap[currX - 1, currY] == step)
                        {
                            --currX;
                            //Console.WriteLine(2);
                        }
                        else if (currX + 1 < grid.countOfRows && grid.IsFree(currX + 1, currY) && cMap[currX + 1, currY] == step)
                        {
                            ++currX;
                            //Console.WriteLine(3);
                        }
                        else if (currY - 1 >= 0 && cMap[currX, currY - 1] == step)
                        {
                            --currY;
                            //Console.WriteLine(0);
                        }
                        else if (currY + 1 < grid.countOfColumns && cMap[currX, currY + 1] == step)
                        {
                            ++currY;
                            //Console.WriteLine(1);
                        }
                        --step;
                    }
                    if (startX != currX)
                    {
                        if (currX - startX < 0)
                        {
                            return 0;
                        }
                        else
                        {
                            return 1;
                        }
                    }
                    if (startY != currY)
                    {
                        if (currY - startY < 0)
                        {
                            return 2;
                        }
                        else
                        {
                            return 3;
                        }
                    }
                }


                if (step > grid.countOfColumns * grid.countOfRows)
                {
                    return -1;
                }
                step++;
            }
            return -1;
        }
    }
}
