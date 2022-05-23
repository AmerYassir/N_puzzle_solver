using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_puzzle_cs
{
    struct Vec
    {
		public int x;
		public int y;
    }
    struct node
    {
        public int direction;
        
        public Grid parent;
    };
    internal class Grid : ICloneable
    {
        public  int size;

        public int[,] grid;
        public Vec spacePos;
        public int lastMove;
        public int depth;
        public int cost;
        public bool solved;
        //public Grid gparent;
        public Grid(int[,] g,int insize)
        {
            grid=new int[insize,insize];
            grid = g;
            spacePos = new Vec();
            size = insize;
            lastMove = -1;
            depth = 0;
            cost = 0;
            solved = false;
           // gparent = null;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (g[i,j]==0)
                    {
                        spacePos.x = j;
                        spacePos.y = i;
                        break;
                    }
                }
            }
        }
        public Grid(Grid another)
        {
            int[,] refGrid = null;
            try
            {
                refGrid = (int[,])another.grid.Clone();
                // You can set the brain in the constructor
            }
            catch (Exception e) { Console.WriteLine("wow  exp"); }
            grid = refGrid;
            size = another.size;
            lastMove=another.lastMove;
            depth = another.depth;
            cost = another.cost;
            solved = another.solved;
            spacePos=another.spacePos;
           // gparent = another.gparent;
        }
		public void RenderGame()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(grid[i,j]+"| ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
           // Console.WriteLine("cost is : "+ManCalcCost());

            Console.WriteLine("Move Number "+depth);

        }
        public int changeInManCost()
        {
            if (lastMove == -1)
                return 0;
            Vec added = new Vec();
            int startCost;
            int finCost;
            Grid tmp=new Grid(this);
            Vec tmpsp = spacePos;
            switch (lastMove)
            {
                case 0:
                    added.x = 0;
                    added.y = 1;
                    break;
                case 1:
                    added.x = 0;
                    added.y = -1;
                    break;
                case 2:
                    added.x = 1;
                    added.y = 0;
                    break;
                case 3:
                    added.x = -1;
                    added.y = 0;
                    break;
                default:
                    break;
            }
            added.x += spacePos.x;
            added.y += spacePos.y;

            
            int div, mod;
            if (grid[added.y, added.x] % size > 0)
            {
                div = grid[added.y, added.x] / size;
                mod = grid[added.y, added.x] % size - 1;
            }
            else
            {
                div = grid[added.y, added.x] / size - 1;
                mod = size - 1;
            }

            int tmp1 = Math.Abs(div - added.y);
            int tmp2 = Math.Abs(mod - added.x);
            finCost = (tmp1 + tmp2);

            
             tmp1 = Math.Abs(div - spacePos.y);
             tmp2 = Math.Abs(mod - spacePos.x);
            startCost = (tmp1 + tmp2);
            return finCost - startCost;
        }
        public int ManCalcCost()
        {
            int cost = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (grid[i,j] == 0)
                    {
                        continue;
                    }
                    int div, mod;
                    if (grid[i, j] % size > 0)
                    {
                        div = grid[i, j] / size;
                        mod = grid[i, j] % size - 1;
                    }
                    else
                    {
                        div = grid[i, j] / size - 1;
                        mod = size - 1;
                    }

                    int tmp1 = Math.Abs(div - i);
                    int tmp2 = Math.Abs(mod - j);
                    cost += (tmp1 + tmp2);
                }
            }
           // this.cost = cost;
            return cost;

        }
        public int HamCalcCost()
        {
            int cost = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                   // int tmm=grid[i, j];
                    if (grid[i,j] != (i * size + j+1)&& grid[i,j]!=0)
                    {
                        cost++;
                    }
                }
            }
            return cost;
        }
        public void swap(int xMove,int yMove)
        {
            int tmp = grid[spacePos.y + yMove,spacePos.x + xMove];
            grid[spacePos.y + yMove,spacePos.x + xMove] = 0;
            grid[spacePos.y,spacePos.x] = tmp;
            spacePos.x += xMove;
            spacePos.y += yMove;
        }
        public bool checkMove(int xMove, int yMove)
        {
            if (spacePos.x + xMove < 0 || spacePos.y + yMove < 0 || spacePos.x + xMove > size - 1 || spacePos.y + yMove > size - 1)
            {
                return false;
            }
            return true;
        }
        public Grid movePiece(int direction,Grid g)
        {
            switch (direction)
            {
                case 0:
                    g.swap(0, -1);
                    break;
                case 1:
    
                    g.swap(0, 1);
                    break;
                case 2:
 
                    g.swap(-1, 0);
                    break;
                case 3:
                    g.swap(1, 0);
                    break;
                default:
                    Console.WriteLine("not valid Move,please try again");
                    break;
            }
            return g;
        }
        public Grid movePieceBcak(int direction, Grid g)
        {
            switch (direction)
            {
                case 0:

                    g.swap(0, 1);
                    break;
                case 1:
                    g.swap(0, -1);
                    break;
                case 2:

                    g.swap(1, 0);
                    break;
                case 3:

                    g.swap(-1, 0);
                    break;
                default:
                    Console.WriteLine("not valid Move,please try again");
                    break;
            }
            return g;
        }
        public void checkValidMoves(bool[]validMoves)
        {
            // 0 is up
            // 1 is down
            // 2 is left
            // 3 is right

            validMoves[0] = checkMove(0, -1);
            validMoves[1] = checkMove(0, 1);
            validMoves[2] = checkMove(-1, 0);
            validMoves[3] = checkMove(1, 0);

            if (lastMove >= 0)
            {

                if (lastMove % 2 == 0)
                    validMoves[lastMove + 1] = false;
                else
                {
                    validMoves[lastMove - 1] = false;
                }

            }
        }

        public Object Clone()
        {
            return new Grid(this);
        }
    }
}
