using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace N_puzzle_cs
{
    
    internal class Program
    {

        static public int[,] TakeInput(string fileName)
        {
            FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader Sread = new StreamReader(file);

            string sizeString = Sread.ReadLine();
            int size = int.Parse(sizeString);
            Sread.ReadLine();
            int[,] n_Puzzle = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                string[] line = Sread.ReadLine().Split();
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

            if (!p.IsSolveable())
            {
                Console.WriteLine("Not Solvable ...\n");
                return;
            }
            if (Ham==1)
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
                Console.Write(" Move Number: " + count);
                Console.WriteLine();
                output[i].showHowSolvePuzzle();
                count++;
               
            }

            Console.WriteLine();
            Console.WriteLine("Total # of movements = " + (output.Count - 1));
        }
        static public void start()
        {
            Console.WriteLine("                    ******************************************************************************");
            Console.WriteLine("                    ******************************************************************************");
            Console.WriteLine("                    **                                                                          **");
            Console.WriteLine("                    **                                                                          **");
            Console.WriteLine("                    **                                                                          **");
            Console.WriteLine("                    **                                                                          **");
            Console.WriteLine("                    **                                                                          **");
            Console.WriteLine("                    **                                                                          **");
            Console.WriteLine("                    **                            Welcome to N puzzle                           **");
            Console.WriteLine("                    **                                                                          **");
            Console.WriteLine("                    **                                                                          **");
            Console.WriteLine("                    **                                                                          **");
            Console.WriteLine("                    **                                                                          **");
            Console.WriteLine("                    **                                                                          **");
            Console.WriteLine("                    **                                                                          **");
            Console.WriteLine("                    ******************************************************************************");
            Console.WriteLine("                    ******************************************************************************");
            Console.WriteLine();

            /*
            string SampleTestNotSolvable = "C:\\Users\\Amer\\source\\repos\\N_puzzle_cs\\Testcases\\Sample\\Sample Test\\Unsolvable Puzzles\\";
            string SampleTestSolvable = "C:\\Users\\Amer\\source\\repos\\N_puzzle_cs\\Testcases\\Sample\\Sample Test\\Solvable Puzzles\\";
            string ComMTest = "C:\\Users\\Amer\\source\\repos\\N_puzzle_cs\\Testcases\\Complete\\Complete Test\\Solvable puzzles\\Manhattan Only\\";
            string ComMaHTest = "C:\\Users\\Amer\\source\\repos\\N_puzzle_cs\\Testcases\\Complete\\Complete Test\\Solvable puzzles\\Manhattan & Hamming\\";
            string VLtest = "C:\\Users\\Amer\\source\\repos\\N_puzzle_cs\\Testcases\\Complete\\Complete Test\\V. Large test case\\";
            string NotSolvable = "C:\\Users\\Amer\\source\\repos\\N_puzzle_cs\\Testcases\\Complete\\Complete Test\\Unsolvable puzzles\\";
            */

            string SampleTestNotSolvable = "C:\\Users\\ayamo\\Documents\\GitHub\\N_puzzle_solver\\Testcases\\Sample\\Sample Test\\Unsolvable Puzzles\\";
            string SampleTestSolvable = "C:\\Users\\ayamo\\Documents\\GitHub\\N_puzzle_solver\\Testcases\\Sample\\Sample Test\\Solvable Puzzles\\";
            string ComMTest = "C:\\Users\\ayamo\\Documents\\GitHub\\N_puzzle_solver\\Testcases\\Complete\\Complete Test\\Solvable puzzles\\Manhattan Only\\";
            string ComMaHTest = "C:\\Users\\ayamo\\Documents\\GitHub\\N_puzzle_solver\\Testcases\\Complete\\Complete Test\\Solvable puzzles\\Manhattan & Hamming\\";
            string VLtest = "C:\\Users\\ayamo\\Documents\\GitHub\\N_puzzle_solver\\Testcases\\Complete\\Complete Test\\V. Large test case\\";
            string NotSolvable = "C:\\Users\\ayamo\\Documents\\GitHub\\N_puzzle_solver\\Testcases\\Complete\\Complete Test\\Unsolvable puzzles\\";

            Stopwatch stopwatch = new Stopwatch();

            int select;
            string path="";
            string fileName="";
            Console.WriteLine(" Select the input from ");
            Console.WriteLine(" 1. Sample Test ");
            Console.WriteLine(" 2. Complete Test ");
            Console.Write("  Enter your choice: ");
            select = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("------------------------------------------------------------------------------");

            switch (select)
            {
                case 1:
                    Console.WriteLine(" Select the input from ");
                    Console.WriteLine(" 1. Sample Solvable ");
                    Console.WriteLine(" 2. Sample Unsolvable ");
                    Console.Write("  Enter your choice: ");
                    select = Convert.ToInt16(Console.ReadLine());
                    Console.WriteLine("------------------------------------------------------------------------------");
                    switch (select)
                    {
                        case 1:
                            path = SampleTestSolvable;
                            Console.WriteLine(" What file do you want? ");
                            Console.WriteLine(" 1. 8 Puzzle (1) ");
                            Console.WriteLine(" 2. 8 Puzzle (2)");
                            Console.WriteLine(" 3. 8 Puzzle (3)");
                            Console.WriteLine(" 4. 15 Puzzle - 1");
                            Console.WriteLine(" 5. 24 Puzzle 1");
                            Console.WriteLine(" 6. 24 Puzzle 2");
                            Console.Write("  Enter the file number you want: ");
                            select = Convert.ToInt16(Console.ReadLine());
                            Console.WriteLine("------------------------------------------------------------------------------");

                            switch (select)
                            {
                                case 1:
                                    fileName = "8 Puzzle (1).txt";
                                    break;
                                case 2:
                                    fileName = "8 Puzzle (2).txt";
                                    break;
                                case 3:
                                    fileName = "8 Puzzle (3).txt";
                                    break;
                                case 4:
                                    fileName = "15 Puzzle - 1.txt";
                                    break;
                                case 5:
                                    fileName = "24 Puzzle 1.txt";
                                    break;
                                case 6:
                                    fileName = "24 Puzzle 2.txt";
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case 2:
                            path = SampleTestNotSolvable;
                            Console.WriteLine(" What file do you want? ");
                            Console.WriteLine(" 1. 8 Puzzle - Case 1 ");
                            Console.WriteLine(" 2. 8 Puzzle(2) - Case 1");
                            Console.WriteLine(" 3. 8 Puzzle(3) - Case 1");
                            Console.WriteLine(" 4. 15 Puzzle - Case 2");
                            Console.WriteLine(" 5. 15 Puzzle - Case 3");
                            Console.Write("  Enter the file number you want: ");
                            select = Convert.ToInt16(Console.ReadLine());
                            Console.WriteLine("------------------------------------------------------------------------------");

                            switch (select)
                            {
                                case 1:
                                    fileName = "8 Puzzle - Case 1.txt";
                                    break;
                                case 2:
                                    fileName = "8 Puzzle(2) - Case 1.txt";
                                    break;
                                case 3:
                                    fileName = "8 Puzzle(3) - Case 1.txt";
                                    break;
                                case 4:
                                    fileName = "15 Puzzle - Case 2.txt";
                                    break;
                                case 5:
                                    fileName = "15 Puzzle - Case 3.txt";
                                    break;
                                default:
                                    break;
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                case 2:
                    Console.WriteLine(" Select the input from ");
                    Console.WriteLine(" 1. Complete solvable Manhatten only ");
                    Console.WriteLine(" 2. Complete solvable Manhatten & Hamming ");
                    Console.WriteLine(" 3. Complete Unsolvable ");
                    Console.WriteLine(" 4. Complete Very Large");
                    Console.Write("  Enter your choice: ");
                    select = Convert.ToInt16(Console.ReadLine());
                    Console.WriteLine("------------------------------------------------------------------------------");
                    switch (select)
                    {
                        case 1:
                            path = ComMTest;
                            Console.WriteLine(" What file do you want? ");
                            Console.WriteLine(" 1. 15 Puzzle 1");
                            Console.WriteLine(" 2. 15 Puzzle 3");
                            Console.WriteLine(" 3. 15 Puzzle 4");
                            Console.WriteLine(" 4. 15 Puzzle 5");
                            Console.Write("  Enter the file number you want: ");
                            select = Convert.ToInt16(Console.ReadLine());
                            Console.WriteLine("------------------------------------------------------------------------------");

                            switch (select)
                            {
                                case 1:
                                    fileName = "15 Puzzle 1.txt";
                                    break;
                                case 2:
                                    fileName = "15 Puzzle 3.txt";
                                    break;
                                case 3:
                                    fileName = "15 Puzzle 4.txt";
                                    break;
                                case 4:
                                    fileName = "15 Puzzle 5.txt";
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case 2:
                            path = ComMaHTest;
                            Console.WriteLine(" What file do you want? ");
                            Console.WriteLine(" 1. 50 Puzzle ");
                            Console.WriteLine(" 2. 99 puzzle 1");
                            Console.WriteLine(" 3. 99 puzzle 2");
                            Console.WriteLine(" 4. 9999 puzzle");
                            Console.Write("  Enter the file number you want: ");
                            select = Convert.ToInt16(Console.ReadLine());
                            Console.WriteLine("------------------------------------------------------------------------");

                            switch (select)
                            {
                                case 1:
                                    fileName = "50 Puzzle.txt";
                                    break;
                                case 2:
                                    fileName = "99 Puzzle - 1.txt";
                                    break;
                                case 3:
                                    fileName = "99 Puzzle - 2.txt";
                                    break;
                                case 4:
                                    fileName = "9999 Puzzle.txt";
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case 3:
                            path = NotSolvable;
                            Console.WriteLine(" What file do you want? ");
                            Console.WriteLine(" 1. 15 Puzzle 1 - Unsolvable ");
                            Console.WriteLine(" 2. 99 Puzzle - Unsolvable Case 1");
                            Console.WriteLine(" 3. 99 Puzzle - Unsolvable Case 2");
                            Console.WriteLine(" 4. 9999 Puzzle");
                            Console.Write("  Enter the file number you want: ");
                            select = Convert.ToInt16(Console.ReadLine());
                            Console.WriteLine("------------------------------------------------------------------------------");

                            switch (select)
                            {
                                case 1:
                                    fileName = "15 Puzzle 1 - Unsolvable.txt";
                                    break;
                                case 2:
                                    fileName = "99 Puzzle - Unsolvable Case 1.txt";
                                    break;
                                case 3:
                                    fileName = "99 Puzzle - Unsolvable Case 2.txt";
                                    break;
                                case 4:
                                    fileName = "9999 Puzzle.txt";
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case 4:
                            path = VLtest;
                            fileName = "TEST.txt";
                            break;
                        default:
                            break;
                    }
                    break;

                default:
                    break;
            }
            int[,] input = TakeInput(path+fileName);

            int Choose;
            Console.WriteLine(" How do you want to solve the puzzle?");
            Console.WriteLine(" 1. Solve by A* algorithm");
            Console.WriteLine(" 2. Solve by BFS algorithm");
            Console.Write("  Enter the number of the solution method you want to solve the puzzle: ");
            Choose = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("------------------------------------------------------------------------------");
            N_puzzle p = new N_puzzle(input, input.GetLength(0));

            if (!p.IsSolveable())
            {
                Console.WriteLine(" Not Solvable ...\n");
                return;
            }
            switch (Choose)
            {
                case 1:
                    Console.WriteLine(" 1. Solve by Manhatten function");
                    Console.WriteLine(" 2. Solve by Hamming function");
                    Console.Write("  Enter the number of the herustix function you want to solve the puzzle: ");
                    Choose = Convert.ToInt16(Console.ReadLine());
                    Console.WriteLine("------------------------------------------------------------------------------");
                    stopwatch.Start();
                    AS_Code(input, input.GetLength(0), Choose);
                    stopwatch.Stop();
                    Console.WriteLine("Total time: " + stopwatch.Elapsed.ToString());
                    break;
                case 2:
                    stopwatch.Start();
                    BFS_Code(input, ((input.GetLength(0))));
                    stopwatch.Stop();
                    Console.WriteLine("Total time: " + stopwatch.Elapsed.ToString());

                    break;
                default:
                    break;
            }
           
        }
        static void Main()
        {
            start();
        }
    }
}

