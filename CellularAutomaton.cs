using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class CellularAutomaton
    {
        //public List<List<Cell>> allCells=new List<List<Cell>>();
     //   public List<int>[] aliveIDs;
        public int cellSize;
        public int iterations;
        public Board startBoard;
        public List<Board> boards=new List<Board>();

        public CellularAutomaton(Board board, int iter, int cellSize)
        {
            //      aliveIDs = new List<int>[iter];
            //      for (int l=0;l<iter;iter++)
            //     {
            //          aliveIDs[l] = new List<int>();
            //      }
            this.startBoard = board;
            this.boards.Add(board);
            this.iterations = iter;
            this.cellSize = cellSize;
            //this.allCells.Add(board.cells);
           // aliveIDs[0] = new List<int>();
      //      foreach (var c in this.board.cells)
       //     {
        //        if (c.Life == true)
       //             aliveIDs[0].Add(c.id);
       ///     }

            for(int i=1;i<iter;i++)
            {
                //this.startBoard.update();
                this.boards.Add(new Board(startBoard));
                //aliveIDs[i] = new List<int>();
                // this.allCells.Add(board.cells);
                //this.allCells[i] = new List<Cell>(board.cells);
      //          foreach (var c in board.cells)
      //          {
      //              if (c.Life == true)
      //                  aliveIDs[i].Add(c.id);
      //          }
            }
        }

        public void drawResult(int width, int height, Graphics graphics, Pen pen, SolidBrush brush )
        {
            for (int it = 0; it < width; it += cellSize)
                graphics.DrawLine(pen, it, 0, it, height);

            for (int it = 0; it < height; it += cellSize)
                graphics.DrawLine(pen, 0, it, width, it);

            for (int i = 0; i < iterations; i++)
                for (int s = 0; s < startBoard.size; s++)
                    if(boards[i].cells[s].Life==true)// if (aliveIDs[i].Contains(s))
                        graphics.FillRectangle(brush, s * this.cellSize + 1, i * this.cellSize + 1, this.cellSize - 1, this.cellSize - 1);
            //if (this.allCells[i][s].Life==true)
        }
    }
}
