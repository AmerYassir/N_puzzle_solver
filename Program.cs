using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_puzzle_cs
{
    
    internal class Program
    {
        static void Main()
        {





            int[] tmp = {

8, 5, 7 ,12
,9 ,15 ,6 ,3
,1 ,0 ,4 ,2
,13 ,14 ,10 ,11};
            int size = 4;
            int[,] g= { {4, 9, 7, 10 }
,{15 ,2 ,8 ,13 }
,{ 6, 1, 5, 14 }
,{ 12 ,0 ,11 ,3 }}; ;

            int[,] tmp2=new int[4,4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    tmp2[i, j] = tmp[j + (i * 4)];
                }
            }
            Grid grid = new Grid(tmp2,size);
            N_puzzle p = new N_puzzle(g,size);
             p.gameLoop(grid);
            //grid.RenderGame();
        }
    }
}

