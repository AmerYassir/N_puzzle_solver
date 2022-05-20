using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_puzzle_cs
{
    class Node
    {
		public Node parPuzzle;
		public List<Node> childNode = new List<Node>();
		public List<int> puzzleGame = new List<int>();

		public Node(int[] mat, int size)
		{
			for (int i = 0; i < size * size; i++)
				if (mat[i] == 0)
					this.puzzleGame.Add(mat.Length);
				else
					this.puzzleGame.Add(mat[i]);
		}
		public void down(int index, List<int> mat, int sizeMat)
		{
			int[] matCopy = new int[sizeMat * sizeMat];
			if (index + sizeMat < sizeMat * sizeMat)
			{
				//Copy mat
				for (int i = 0; i < sizeMat * sizeMat; i++)
					matCopy[i] = mat[i];

				//Swap 
				int temp = matCopy[index + sizeMat];
				matCopy[index + sizeMat] = matCopy[index];
				matCopy[index] = temp;

				Node nodeChild = new Node(matCopy, sizeMat);
				childNode.Add(nodeChild);
				nodeChild.parPuzzle = this;

			}
		}
		public void up(int index, List<int> mat, int sizeMat)
		{
			int[] matCopy = new int[sizeMat * sizeMat];
			if (index - sizeMat >= 0)
			{
				//Copy mat
				for (int i = 0; i < sizeMat * sizeMat; i++)
					matCopy[i] = mat[i];

				//Swap 
				int temp = matCopy[index - sizeMat];
				matCopy[index - sizeMat] = matCopy[index];
				matCopy[index] = temp;

				Node nodeChild = new Node(matCopy, sizeMat);
				childNode.Add(nodeChild);
				nodeChild.parPuzzle = this;

			}
		}
		public void left(int index, List<int> mat, int sizeMat)
		{
			int[] matCopy = new int[sizeMat * sizeMat];
			if (index % sizeMat > 0)
			{
				//Copy mat
				for (int i = 0; i < sizeMat * sizeMat; i++)
					matCopy[i] = mat[i];

				//Swap 
				int temp = matCopy[index - 1];
				matCopy[index - 1] = matCopy[index];
				matCopy[index] = temp;

				Node nodeChild = new Node(matCopy, sizeMat);
				childNode.Add(nodeChild);
				nodeChild.parPuzzle = this;

			}
		}
		public void right(int index, List<int> mat, int sizeMat)
		{
			if (index % sizeMat < sizeMat - 1)
			{
				int[] matCopy = new int[sizeMat * sizeMat];

				//Copy mat
				for (int i = 0; i < sizeMat * sizeMat; i++)
					matCopy[i] = mat[i];

				//Swap 
				int temp = matCopy[index + 1];
				matCopy[index + 1] = matCopy[index];
				matCopy[index] = temp;

				Node nodeChild = new Node(matCopy, sizeMat);
				childNode.Add(nodeChild);
				nodeChild.parPuzzle = this;

			}
		}
		public bool testPuzzleIsGoal()
		{
			int element = puzzleGame[0];
			bool goal = false;
			for (int i = 1; i < puzzleGame.Count; i++)
			{
				if (element > puzzleGame[i])
					goal = true;
				element = puzzleGame[i];
			}
			return goal;
		}
		public void movePiece()
		{
			for (int i = 0; i < puzzleGame.Count; i++)
				if (puzzleGame[i] == puzzleGame.Count)
				{
					up(i, puzzleGame, (int)Math.Sqrt(puzzleGame.Count));
					down(i, puzzleGame, (int)Math.Sqrt(puzzleGame.Count));
					right(i, puzzleGame, (int)Math.Sqrt(puzzleGame.Count));
					left(i, puzzleGame, (int)Math.Sqrt(puzzleGame.Count));
					break;
				}
		}
		public bool samePuzzle(List<int> mat)
		{
			bool check = true;
			for (int i = 0; i < mat.Count; i++)
				if (puzzleGame[i] != mat[i])
					check = false;

			return check;
		}
		public void printPuzzle()
		{
			Console.WriteLine();
			int index = 0;
			for (int i = 0; i < (int)Math.Sqrt(puzzleGame.Count); i++)
			{
				for (int j = 0; j < (int)Math.Sqrt(puzzleGame.Count); j++)
				{
					if (puzzleGame[index] == puzzleGame.Count)
					{
						Console.Write(0 + " ");
						index++;
					}
					else
					{
						Console.Write(puzzleGame[index] + " ");
						index++;
					}
				}
				Console.WriteLine();
			}
		}
	}
}
