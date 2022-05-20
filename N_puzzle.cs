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
        Grid FirstGrid;
       // priorityQueue pQueue;
        public N_puzzle(int[,] g, int insize)
        {
            FirstGrid = new Grid(g,insize);
           // pQueue = new priorityQueue();
        }
        public Grid addChildrens(Grid g)
        {
            int pDeppth = g.depth;
            g.checkValidMoves();
            node tmpNode;

            for (int i = 0; i < 4; i++)
            {
                if (g.validMoves[i])
                {
                    Grid tmpg = new Grid(g);
                    g =g.movePiece(i,g);
                    tmpNode.parent = tmpg;
                    tmpNode.val = g.ManCalcCost() + (g.depth+1)+ g.cost;

                    tmpNode.depth = g.depth+1;
                    tmpNode.direction = i;
                    ppq.Enqueue(tmpNode, tmpNode.val);
                    g=g.movePieceBcak(i,g);
                }

            }
            return g;
        }
        public void gameLoop(Grid g)
        {
            int counter = 0;
            int minofall = 100;
            node minNode;
            g.cost=g.ManCalcCost();
            while (!g.solved)
            {
                //g.RenderGame();
                g = addChildrens(g);
                // Console.WriteLine("parent");

                //pQueue.pq.First().parent.RenderGame();
                // Console.WriteLine("son");
                
                 minNode = ppq.Dequeue(); ;
                g =g.movePiece(minNode.direction,minNode.parent);
                // g.RenderGame();
                //g.cost = minNode.val;

                g.lastMove = minNode.direction;
                
                g.depth++;
                
                if (g.ManCalcCost() == 0)
                {
                    Console.WriteLine("depth is " + minNode.depth);
                    if (g.depth < minofall)
                    {
                        minofall = g.depth;
                    }
                   // g = g.movePieceBcak(minNode.direction, minNode.parent);
                   // g.RenderGame();
                    counter++;
                    
                    if (counter==2)
                    {
                        Console.WriteLine("best depth is " + minofall);
                        g.solved = true;

                    }

                }
            }
        }
    }
}
