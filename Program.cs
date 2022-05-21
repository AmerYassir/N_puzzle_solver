using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_puzzle_cs
{
    
    internal class Program
    {

        static public int[,] TakeInput(string fileName)
        {
            FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(file);

            string sizeString = sr.ReadLine();
            int size = int.Parse(sizeString);
            sr.ReadLine();
            int[,] n_Puzzle = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                string[] line = sr.ReadLine().Split();
                for (int j = 0; j < size; j++)
                {
                    int currentNumber = int.Parse(line[j]);
                    n_Puzzle[i, j] = currentNumber;
                }
            }
            return n_Puzzle;
        }  
        static public void AS_Code(int[,]input,int size,int Ham)
        {
            N_puzzle p = new N_puzzle(input, size);

            if (Ham==0)
            {
                p.gameLoop(p.FirstGrid);
                return;
            }
            p.gameLoop(p.FirstGrid, Ham);
        }
        static public void BFS_Code(int[,]input,int size)
        {
            int[]BFS_arr=new int[size*size];
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    BFS_arr[i * size + j] = input[i, j];



            BFS bfs=new BFS();
            Puzzle firstNode =new Puzzle(BFS_arr,size);
            List<Puzzle> output= bfs.Breadth(firstNode);
            int count = 1;
            Console.WriteLine();
            Console.WriteLine(" Puzzle");
            output[output.Count - 1].showHowSolvePuzzle();
            Console.WriteLine();
            Console.WriteLine(" Solve puzzle");
            for (int i = output.Count - 2; i >= 0; i--)
            {
                Console.WriteLine();
                Console.Write("  Move #" + count);
                Console.WriteLine();
                output[i].showHowSolvePuzzle();
                count++;
               
            }

            Console.WriteLine();
            Console.WriteLine("Total # of movements = " + (output.Count - 1));
        }
        static public void start(int[,] input)
        {

            Console.WriteLine("                    ******************************************************************************");
            Console.WriteLine("                    ******************************************************************************");
            Console.WriteLine("                    **                                                                          **");
            Console.WriteLine("                    **                                                                          **");
            Console.WriteLine("                    **                                                                          **");
            Console.WriteLine("                    **                                                                          **");
            Console.WriteLine("                    **                                                                          **");
            Console.WriteLine("                    **                           Welcome to N puzzle                            **");
            Console.WriteLine("                    **                                                                          **");
            Console.WriteLine("                    **                                                                          **");
            Console.WriteLine("                    **                                                                          **");
            Console.WriteLine("                    **                                                                          **");
            Console.WriteLine("                    **                                                                          **");
            Console.WriteLine("                    ******************************************************************************");
            Console.WriteLine("                    ******************************************************************************");
            Console.WriteLine();

            int Choose;
            Console.WriteLine("How do you want to solve the puzzle?");
            Console.WriteLine("1. solve by A* algorithm");
            Console.WriteLine("2. solve by BFS algorithm");
            Console.WriteLine("------------------------------------------------------------------------");
            Console.Write("Enter the number of the solution method you want to solve the puzzle: ");
            Choose = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("------------------------------------------------------------------------");

            if (Choose == 1)
            {
                AS_Code(input, input.GetLength(0), 0);
            }
            else if (Choose == 2)
            {
                BFS_Code(input, ((input.GetLength(0))));
            }
        }
        static void Main()
        {
            //paths for tets folders
            string ComMTest = "C:\\Users\\Amer\\source\\repos\\N_puzzle_cs\\Testcases\\Sample\\Sample Test\\Solvable Puzzles\\";
            //string ComMTest = "C:\\Users\\ayamo\\Documents\\GitHub\\N_puzzle_solver\\Testcases\\Sample\\Sample Test\\Solvable Puzzles\\";
            string ComMaHTest = "C:\\Users\\Amer\\source\\repos\\N_puzzle_cs\\Testcases\\Complete\\Complete Test\\Solvable puzzles\\Manhattan & Hamming\\";
            //string ComMaHTest = "C:\\Users\\ayamo\\Documents\\GitHub\\N_puzzle_solver\\Testcases\\Complete\\Complete Test\\Solvable puzzles\\Manhattan & Hamming\\";
            // file name in the used folder , dont forget to type .txt at the end
            string fileName = "8 Puzzle (1).txt";
            int[,] input = TakeInput(ComMTest + fileName);

            // use on of these algorithms
            // BFS_Code(input,((input.GetLength(0))));
            // AS_Code(input, input.GetLength(0), 0);

            start(input);

           

        }
    }
}

