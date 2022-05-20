using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_puzzle_cs
{
    class BFS
    {
		public bool checkSamePuzzle(Node rootNode, List<Node> adj)
		{
			bool check = true;
			for (int i = 0; i < adj.Count; i++)
				if (adj[i].samePuzzle(rootNode.puzzleGame))
					check = false;

			return check;
		}
		public List<Node> Breadth(Node root)
		{
			bool goal = true;
			List<Node> puzzleList = new List<Node>();
			List<Node> CloseList = new List<Node>();
			List<Node> OpenList = new List<Node>();
			OpenList.Add(root);

			while (goal && OpenList.Count > 0)
			{
				CloseList.Add(OpenList[0]);
				OpenList[0].movePiece();

				for (int i = 0; i < OpenList[0].childNode.Count; i++)
				{
					Node currentChild = OpenList[0].childNode[i];

					if (!currentChild.testPuzzleIsGoal())
					{
						goal = false;
						//Path Trace
						puzzleList.Add(currentChild);
						while (currentChild.parPuzzle != null)
						{
							currentChild = currentChild.parPuzzle;
							puzzleList.Add(currentChild);
						}
					}

					if (checkSamePuzzle(currentChild, OpenList) &&
						checkSamePuzzle(currentChild, CloseList))
						OpenList.Add(currentChild);
				}
				OpenList.RemoveAt(0);
			}
			return puzzleList;
		}
	}
}
