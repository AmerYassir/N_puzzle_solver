using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace N_puzzle_cs
{
    
    internal class N_puzzle
    {

        PriorityQueue<node,int> ppq=new PriorityQueue<node,int>();
        PriorityQueue<node,int> savedMoves =new PriorityQueue<node,int>();
        public Grid FirstGrid;
        public N_puzzle(int[,] g, int insize)
        {
            FirstGrid = new Grid(g,insize);
        }
        public bool IsSolveable()
        {
            int conv = 0;

            for (int i = 0; i < FirstGrid.size; i++)
            {
                for (int j = 0; j < FirstGrid.size; j++)
                {
                    int val = FirstGrid.grid[i,j];
                    int tmpi = i;
                    int tmpj = j;
                    for (int k = tmpi; k < FirstGrid.size; k++)
                    {
                        for (int h = tmpj; h < FirstGrid.size; h++)
                        {
                            //tmpj = 0;
                            if (FirstGrid.grid[k,h] < val && FirstGrid.grid[k,h] != 0)
                            {
                                conv++;
                            }
                        }
                        tmpj = 0;
                    }
                    tmpi = 0;

                }
            }
            if (FirstGrid.size % 2 == 0)
            {
                if (FirstGrid.spacePos.y % 2 == 0 && conv % 2 == 1)
                    return true;
                if (FirstGrid.spacePos.y % 2 == 1 && conv % 2 == 0)
                    return true;
                return false;
            }
            else
            {
                return (conv % 2 == 0);

            }
        }
        public Grid addChildrens(Grid g)
        {
            g.checkValidMoves();
            node tmpNode;

            for (int i = 0; i < 4; i++)
            {
                if (g.validMoves[i])
                {
                    Grid tmpg = new Grid(g);
                    tmpg.gparent = g.gparent;

                    g = g.movePiece(i,g);
                    tmpNode.parent = tmpg;
                    tmpNode.val = g.ManCalcCost()+ (g.depth+1)+ g.cost;

                    tmpNode.depth = g.depth+1;
                    tmpNode.direction = i;
                    ppq.Enqueue(tmpNode, tmpNode.val);
                    g=g.movePieceBcak(i,g);
                }

            }
            return g;
        }

        public Grid addChildrens(Grid g,int Ham)
        {
            g.checkValidMoves();
            node tmpNode;

            for (int i = 0; i < 4; i++)
            {
                if (g.validMoves[i])
                {

                    Grid tmpg = new Grid(g);
                    tmpg.gparent = g.gparent;

                    g = g.movePiece(i, g);
                    tmpNode.parent = tmpg;
                    tmpNode.val = g.HamCalcCost() + (g.depth + 2) + g.cost;

                    tmpNode.depth = g.depth + 1;
                    tmpNode.direction = i;
                    ppq.Enqueue(tmpNode, tmpNode.val);
                    g = g.movePieceBcak(i, g);
                }

            }
            return g;
        }

        public void gameLoop(Grid g)
        {
            Grid tmppg;
            node minNode;
            g.cost=g.ManCalcCost();
            while (!g.solved)
            {
                g = addChildrens(g);

                minNode = ppq.Dequeue();
                tmppg=new Grid(minNode.parent);
                g =g.movePiece(minNode.direction,minNode.parent);
                g.lastMove = minNode.direction;
                g.gparent = tmppg;
                g.depth++;
                
                if (g.ManCalcCost() == 0)
                {
                    Console.WriteLine("depth is " + minNode.depth);
                    minNode.parent.RenderGame();
                    paintFinalSteps(g);

                    g.solved = true;
                }
            }
        }

        public void gameLoop(Grid g,int Ham)
        {
            Grid tmppg;
            node minNode;
            g.cost = g.HamCalcCost();
            while (!g.solved)
            {
                g = addChildrens(g,Ham);
                minNode = ppq.Dequeue();
                tmppg = new Grid(minNode.parent);

                g = g.movePiece(minNode.direction, minNode.parent);
                g.lastMove = minNode.direction;
                g.gparent=tmppg;
                g.depth++;

                if (g.HamCalcCost() == 0)
                {
                    Console.WriteLine("depth is " + minNode.depth);
                    paintFinalSteps(g);
                    g.solved = true;
                }
            }
        }

        public void paintFinalSteps(Grid g)
        {
            int size = g.depth;
            List<Grid>output= new List<Grid>();
            while (g.gparent!=null)
            {
                output.Add(g);
                g = g.gparent;
            }
            for (int i = 0; i < size; i++)
            {
                output[size-i-1].RenderGame();
            }
        }
    }
}
