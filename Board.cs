using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Board
    {
        public int size;
        public List<Cell> cells=new List<Cell>();
        public int ruleType;
        public List<bool> rule=new List<bool>();

        public Board(int size, int ruleType)
        {
            this.size = size;
            this.ruleType = ruleType;
            this.MakeTheRule(ruleType);
            
            for (int i=0;i<size;i++)
            {
                this.cells.Add(new Cell(i, false, size));
            }

            foreach(var c in cells)
            {
                c.setNeighbors(this.size);
            }
            this.setup();
        }

        public Board(Board b)
        {
            this.size = b.size;
            this.ruleType = b.ruleType;
            this.rule = b.rule;
            this.cells = b.cells;
            this.update();
        }

        public void MakeTheRule(int ruleType)
        {
            for (int i=7;i>-1;i--)
            {
                int p = (int)Math.Pow(2, i);
                bool r = Convert.ToBoolean(ruleType / p);
                this.rule.Add(r);
                ruleType = ruleType % p;
            }
        }

        public void setup()
        {
            int start = this.size / 2;
            this.cells[start].Life = true;
        }

        public void update()
        {
            List<int> nextRoundAlive = new List<int>();

            foreach(var c in this.cells)
            {
                if (cells[c.neighbors[0]].Life == false) //left neighbor dead
                {
                    if (c.Life == false)
                    {
                        if (cells[c.neighbors[1]].Life == false)       //000
                        {
                            if (rule[7])
                                nextRoundAlive.Add(c.id);
                        }
                        else                                            //001
                            if (rule[6])
                            nextRoundAlive.Add(c.id);
                    }
                    else
                    {
                        if (cells[c.neighbors[1]].Life == false)       //010
                        {
                            if (rule[5])
                                nextRoundAlive.Add(c.id);
                        }
                        else                                            //011
                            if (rule[4])
                            nextRoundAlive.Add(c.id);
                    }
                }
                else
                {
                    if (c.Life == false)
                    {
                        if (cells[c.neighbors[1]].Life == false)       //100
                        {
                            if (rule[3])
                                nextRoundAlive.Add(c.id);
                        }
                        else                                            //101
                            if (rule[2])
                            nextRoundAlive.Add(c.id);
                    }
                    else
                    {
                        if (cells[c.neighbors[1]].Life == false)       //110
                        {
                            if (rule[1])
                                nextRoundAlive.Add(c.id);
                        }
                        else                                            //111
                            if (rule[0])
                            nextRoundAlive.Add(c.id);
                    }
                }
            }

            foreach(var c in this.cells)
            {
                if (nextRoundAlive.Contains(c.id))
                    c.Life = true;
                else
                    c.Life = false;
            }
        }
    }
}
