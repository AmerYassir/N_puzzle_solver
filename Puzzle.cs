using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_puzzle_cs
{
    internal class Puzzle
    {
		public Puzzle basicPuzzle;
		public List<Puzzle> childPazzle = new List<Puzzle>();
		public List<int> puzzleGame = new List<int>();

		public Puzzle(int[] puzzle, int sizePuzzle)
		{
			for (int i = 0; i < sizePuzzle * sizePuzzle; i++)
				if (puzzle[i] == 0)
					this.puzzleGame.Add(puzzle.Length);
				else
					this.puzzleGame.Add(puzzle[i]);
		}
		public void up(int index, List<int> puzzle, int sizePuzzle)
		{
			int[] matCopy = new int[sizePuzzle * sizePuzzle];
			if (0 <= index - sizePuzzle)
			{
				//Copy mat
				for (int i = 0; i < sizePuzzle * sizePuzzle; i++)
					matCopy[i] = puzzle[i];

				//Swap 
				int temp = matCopy[index - sizePuzzle];
				matCopy[index - sizePuzzle] = matCopy[index];
				matCopy[index] = temp;

				Puzzle nodeChild = new Puzzle(matCopy, sizePuzzle);
				childPazzle.Add(nodeChild);
				nodeChild.basicPuzzle = this;

			}
		}
		public void down(int index, List<int> puzzle, int sizePuzzle)
		{
			int[] matCopy = new int[sizePuzzle * sizePuzzle];
			if (sizePuzzle * sizePuzzle > index + sizePuzzle)
			{
				//Copy mat
				for (int i = 0; i < sizePuzzle * sizePuzzle; i++)
					matCopy[i] = puzzle[i];

				//Swap 
				int temp = matCopy[index + sizePuzzle];
				matCopy[index + sizePuzzle] = matCopy[index];
				matCopy[index] = temp;

				Puzzle nodeChild = new Puzzle(matCopy, sizePuzzle);
				childPazzle.Add(nodeChild);
				nodeChild.basicPuzzle = this;

			}
		}
		public void right(int index, List<int> puzzle, int sizePuzzle)
		{
			if (sizePuzzle - 1 > index % sizePuzzle)
			{
				int[] matCopy = new int[sizePuzzle * sizePuzzle];

				//Copy mat
				for (int i = 0; i < sizePuzzle * sizePuzzle; i++)
					matCopy[i] = puzzle[i];

				//Swap 
				int temp = matCopy[index + 1];
				matCopy[index + 1] = matCopy[index];
				matCopy[index] = temp;

				Puzzle nodeChild = new Puzzle(matCopy, sizePuzzle);
				childPazzle.Add(nodeChild);
				nodeChild.basicPuzzle = this;

			}
		}
		public void left(int index, List<int> puzzle, int sizePuzzle)
		{
			int[] matCopy = new int[sizePuzzle * sizePuzzle];
			if (0 < index % sizePuzzle)
			{
				//Copy mat
				for (int i = 0; i < sizePuzzle * sizePuzzle; i++)
					matCopy[i] = puzzle[i];

				//Swap 
				int temp = matCopy[index - 1];
				matCopy[index - 1] = matCopy[index];
				matCopy[index] = temp;

				Puzzle nodeChild = new Puzzle(matCopy, sizePuzzle);
				childPazzle.Add(nodeChild);
				nodeChild.basicPuzzle = this;

			}
		}
		public bool testPuzzleIsGoal()
		{
			int element = puzzleGame[0];
			bool goal = false;
			for (int i = 1; i < puzzleGame.Count; i++)
			{
				if (puzzleGame[i] < element)
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
		public bool puzzleRepeat(List<int> puzzle)
		{
			bool check = false;
			for (int i = 0; i < puzzle.Count; i++)
				if (puzzleGame[i] != puzzle[i])
					check = true;

			return check;
		}
		public void showHowSolvePuzzle()
		{
			int index = 0;
			for (int i = 0; i < (int)Math.Sqrt(puzzleGame.Count); i++)
			{
				for (int j = 0; j < (int)Math.Sqrt(puzzleGame.Count); j++)
				{
					if (puzzleGame[index] == puzzleGame.Count)
						Console.Write("  " + " ");
					else
						Console.Write("  " + puzzleGame[index]);
					index++;
				}
				Console.WriteLine();
			}
		}
	}
}
