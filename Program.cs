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
            {
                for (int j = 0; j < size; j++)
                {
                    BFS_arr[i * size + j] = input[i, j];
                }
            }
            BFS bfs=new BFS();
            Node firstNode=new Node(BFS_arr,size);
            List<Node> output= bfs.Breadth(firstNode);
            for (int i = 0; i < output.Count; i++)
            {
                Console.WriteLine("move " + (i + 1));
                output[i].printPuzzle();
            }
        }
        static void Main()
        {
            //paths for tets folders
            string ComMTest = "C:\\Users\\Amer\\source\\repos\\N_puzzle_cs\\Testcases\\Complete\\Complete Test\\Solvable puzzles\\Manhattan Only\\";
            string ComMaHTest = "C:\\Users\\Amer\\source\\repos\\N_puzzle_cs\\Testcases\\Complete\\Complete Test\\Solvable puzzles\\Manhattan & Hamming\\";
            // file name in the used folder , dont forget to type .txt at the end
            string fileName = "15 Puzzle 1.txt";
            int[,] input = TakeInput(ComMTest + fileName);

            // use on of these algorithms
            // BFS_Code(input,((input.GetLength(0))));
            // AS_Code(input, input.GetLength(0), 0);
        }
    }
}

