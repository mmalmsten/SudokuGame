using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {

            Sudoku sudoku = new Sudoku();
            sudoku.DrawTable();
            sudoku.ChoosePosition();

        }

    }

    class Sudoku
    {
        public int[,] table = new int[9, 9];
        public int userX = 0;
        public int userY = 0;
        public bool empty;
        public bool inSquare;
        public bool inY;
        public bool inX;

        public void DrawTable()
        {
            table[0, 0] = 7;
            table[0, 2] = 8;
            table[0, 6] = 2;
            table[1, 1] = 6;
            table[1, 2] = 1;
            table[1, 4] = 2;
            table[1, 5] = 4;
            table[1, 6] = 8;
            table[2, 1] = 4;
            table[2, 3] = 8;
            table[2, 5] = 3;
            table[2, 7] = 6;
            table[3, 0] = 3;
            table[3, 1] = 2;
            table[3, 3] = 7;
            table[3, 7] = 4;
            table[4, 3] = 5;
            table[4, 4] = 3;
            table[4, 5] = 9;
            table[5, 1] = 5;
            table[5, 5] = 6;
            table[5, 7] = 3;
            table[5, 8] = 1;
            table[6, 1] = 8;
            table[6, 3] = 3;
            table[6, 5] = 7;
            table[6, 7] = 2;
            table[7, 2] = 3;
            table[7, 3] = 4;
            table[7, 4] = 1;
            table[7, 6] = 9;
            table[7, 7] = 5;
            table[8, 2] = 4;
            table[8, 6] = 3;
            table[8, 8] = 7;

            for (int j = 0; j < 18; j=j+2)
            {
                for (int i = 0; i < 36; i=i+4)
                {
                    Console.SetCursorPosition(i, j);
                    Console.WriteLine("|---");
                    Console.SetCursorPosition(i, j+1);
                    Console.WriteLine("| " + table[j/2, i/4] + " ");
                }
            }

        }

        public void ChoosePosition()
        {
            Console.WriteLine("Ange rad:");
            var input = Console.ReadLine();
            Int32.TryParse(input, out userY);

            Console.WriteLine("Ange kolumn:");
            input = Console.ReadLine();
            Int32.TryParse(input, out userX);

        }

        public void CheckPosition()
        {

            if (table[userY, userX] == 0)
                empty = true;
            else
                empty = false;


           

        }
   
    }

}
