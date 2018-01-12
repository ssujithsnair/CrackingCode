using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingCode
{
    class MineSweeper
    {
        //https://gist.github.com/dgossow/d28083522608771e1c65f49822820ba9
        const int Mine = 9;
        readonly Cell[,] mines;
        int rows;
        int columns;
        int totalmines;
        struct Cell
        {
            public int Value;
            public bool visible;
        }

        public MineSweeper(int rows, int columns, int mineCount)
        {
            mines = new Cell[rows, columns];
            this.rows = rows;
            this.columns = columns;
            FillMines();
        }

        private void FillMines()
        {
            int mineCount = 0;
            Random random = new Random();
            int totalcells = rows * columns;
            while (mineCount < totalmines)
            {
                int row = random.Next(0, rows);
                int column = random.Next(0, columns);
                if (mines[row,  column].Value == Mine)
                    continue;
                mineCount++;
                for (int i= Math.Max(0, row-1); i< Math.Min(row+1,  rows); i++)
                    for (int j = Math.Max(0, column - 1); j < Math.Min(columns, column + 1); j++)
                    {
                        if (!IsValid(row, column))
                            continue;
                        if (i == row && j == column)
                            mines[row, column].Value = Mine;
                        else if (mines[row, column].Value != Mine)
                            mines[row, column].Value++;
                    }
            }
        }

        public bool ClickCell(int row, int column)
        {
            if (!(IsValid(row, column)) ||
                mines[row, column].visible)
                return false;
            mines[row, column].visible = true;

            if (mines[row, column].Value == Mine)
            {
                Console.WriteLine("Boom... You are dead");
                return true;
            }



            return true;
        }
        private bool IsValid(int row, int column)
        {
            return row >= 0 && row < rows - 1 && column >= 0 && column < columns - 1;
        }
    }
}
