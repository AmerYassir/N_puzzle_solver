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
           /* int[] tmp = {

                8, 5, 7 ,12
                ,9 ,15 ,6 ,3
                ,1 ,0 ,4 ,2
                ,13 ,14 ,10 ,11};
            int size = 4;
            int[,] g= { {4, 9, 7, 10 }
                        ,{15 ,2 ,8 ,13 }
                        ,{ 6, 1, 5, 14 }
                        ,{ 12 ,0 ,11 ,3 }}; 

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
            //grid.RenderGame();*/


            //////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////
            //           BFS

            //int[] puzzle = {1,2,4,3,0,5,7,6,8};
            int[] puzzle = { 0, 1, 3, 4, 2, 5, 7, 8, 6 };
            //test #1
            //int[] puzzle = { 0 ,1, 2, 5 ,6, 3, 4, 7, 8 };
            //test #2
            //int[] puzzle = { 7 ,3, 2, 5 ,0, 6, 1, 8, 4 };
            //test #3
            //int[] puzzle = { 8 ,1, 3, 4 ,0, 2, 7, 6, 5 };
            //test 4*4 
            //int[] puzzle = { 1 ,2, 7, 3 ,5, 6, 0, 4, 9, 10, 11, 8, 13, 14, 15, 12};
            //test 5*5 (24 Puzzle 1) Testcases\Sample\Sample Test\Solvable Puzzles
            //int[] puzzle = { 1 ,2, 8, 3 ,4, 6, 7, 0, 10, 5, 11, 12, 14, 9, 15, 16, 17, 13, 18, 20, 21, 22, 23, 19, 24 };
            //test 5*5 (24 Puzzle 2) Testcases\Sample\Sample Test\Solvable Puzzles
            //int[] puzzle = { 0, 1, 2, 3, 4, 7, 8, 9, 10, 5, 6, 11, 12, 13, 14, 17, 18, 19, 20, 15, 16, 21, 22, 23, 24 };

            BFS bfs = new BFS();
            Node rootPuzzle = new Node(puzzle, 3);
            List<Node> adj = bfs.Breadth(rootPuzzle);
            int count = 1;

            if (adj.Count > 0)
            {
                adj[adj.Count - 1].printPuzzle();
                for (int i = adj.Count - 2; i >= 0; i--)
                {
                    Console.WriteLine();
                    Console.Write("#" + count);
                    adj[i].printPuzzle();
                    count++;
                }
            }

            Console.WriteLine();
            Console.WriteLine("Total # of movements = " + (adj.Count - 1));

        }
    }
}

