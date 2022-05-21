using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_puzzle_cs
{
    class BFS
    {
		public bool checkPuzzleRepeat(Puzzle rootNode, List<Puzzle> adj)
		{
			bool check = true;
			for (int i = 0; i < adj.Count; i++)
				if (!adj[i].puzzleRepeat(rootNode.puzzleGame))
					check = false;

			return check;
		}
		public List<Puzzle> Breadth(Puzzle puzzle)
		{
			bool checkPuzzleIsGoal = true;
			List<Puzzle> solvePuzzle = new List<Puzzle>();
			List<Puzzle> ClosePuzzle = new List<Puzzle>();
			List<Puzzle> OpenPuzzle = new List<Puzzle>();
			OpenPuzzle.Add(puzzle);

			while (checkPuzzleIsGoal && OpenPuzzle.Count > 0)
			{
				ClosePuzzle.Add(OpenPuzzle[0]);
				OpenPuzzle[0].movePiece();

				for (int i = 0; i < OpenPuzzle[0].childPazzle.Count; i++)
				{
					Puzzle childOpen = OpenPuzzle[0].childPazzle[i];

					if (!childOpen.testPuzzleIsGoal())
					{
						checkPuzzleIsGoal = false;
						//Path Trace
						solvePuzzle.Add(childOpen);
						while (childOpen.basicPuzzle != null)
						{
							childOpen = childOpen.basicPuzzle;
							solvePuzzle.Add(childOpen);
						}
					}

					if (checkPuzzleRepeat(childOpen, OpenPuzzle) &&
						checkPuzzleRepeat(childOpen, ClosePuzzle))
						OpenPuzzle.Add(childOpen);
				}
				OpenPuzzle.RemoveAt(0);
			}
			return solvePuzzle;
		}
	}
}
