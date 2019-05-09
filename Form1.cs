using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int maxSize;
        public Form1()
        {
            InitializeComponent();
            maxSize = (panel1.Width < panel1.Height) ? panel1.Width : panel1.Height;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int size = (int)numericUpDown1.Value;
            int iter = (int)numericUpDown2.Value;
            int rule = (int)numericUpDown3.Value;

            if(size==0&&iter==0)
            {
                string message = "do you want to setup default values (size=30, number of iterations=25)?";
                string caption = "you cannot use 0 as a size and number of iterations";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(this, message, caption, buttons,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);

                if (result == DialogResult.Yes)
                {
                    size = 30;
                    numericUpDown1.Value = 30;
                    iter = 25;
                    numericUpDown2.Value = 25;
                }
                else
                {
                    size = 1;
                    this.Close();
                }
            }
            else if(size==0)
            {
                string message = "do you want to setup default value (size=30)?";
                string caption = "you cannot use 0 as a size";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(this, message, caption, buttons,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);

                if (result == DialogResult.Yes)
                {
                    size = 30;
                    numericUpDown1.Value = 30;
                }
                else
                {
                    this.Close();
                }
            }
            else if (iter==0)
            {
                string message = "do you want to setup default value (number of iterations=25)?";
                string caption = "you cannot use 0 as a number of iterations";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(this, message, caption, buttons,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);

                if (result == DialogResult.Yes)
                {
                    iter = 25;
                    numericUpDown2.Value = 25;
                }
                else
                {
                    this.Close();
                }
            }

            int cellSize = (size > iter) ? maxSize / size : maxSize / iter;

            panel1.Width = cellSize * size;
            panel1.Height = cellSize * iter;

            panel1.Refresh();
            Board board = new Board(size, rule);
            CellularAutomaton cellularAutomaton = new CellularAutomaton(board, iter, cellSize);

            Pen pen = new Pen(Color.MediumVioletRed, 1f);
            SolidBrush brush = new SolidBrush(Color.MediumVioletRed);
            Graphics graphics = panel1.CreateGraphics();
            cellularAutomaton.drawResult(panel1.Width, panel1.Height, graphics, pen, brush);


        }
    }
}
