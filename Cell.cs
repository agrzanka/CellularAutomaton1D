using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Cell
    {
        public bool Life { get; set; }
        public int id;
        public List<int> neighbors=new List<int>();

        public Cell()
        {
            this.Life = false;
            this.id = 0;
        }

        public Cell(int id, bool life, int boardSize)
        {
            this.id = id;
            this.Life = life;

        }

        public void setNeighbors(int boardSize)
        {
            if (this.id==0)
            {
                this.neighbors.Add(boardSize - 1);
                this.neighbors.Add(id + 1);
            }
            else if(this.id==(boardSize-1))
            {
                this.neighbors.Add(id - 1);
                this.neighbors.Add(0);
            }
            else
            {
                this.neighbors.Add(id - 1);
                this.neighbors.Add(id + 1);
            }
        }
    }
}
