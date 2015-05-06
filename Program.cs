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
            
            while (true)
            {
                sudoku.DrawTable();
                sudoku.ChoosePosition();
                sudoku.CheckPosition();
                sudoku.CheckSquare();
                sudoku.CheckLines();
                sudoku.CheckIfValid();
            }

        }

    }

    class Sudoku
    {
        public int[,] table = new int[9, 9];
        public int userX = 0;
        public int userY = 0;
        public int newNumber = 0;
        public bool isValid = true;
        public int inSquare;
        public int minY;
        public int minX;

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

            Console.ForegroundColor = ConsoleColor.White;

            for (int j = 0; j < 18; j = j + 2)
            {
                for (int i = 0; i < 36; i = i + 4)
                {
                    Console.SetCursorPosition(i, j);
                    Console.WriteLine("|---");
                    Console.SetCursorPosition(i, j + 1);
                    if (table[j / 2, i / 4] != 0)
                    {
                        Console.Write("| ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(table[j / 2, i / 4] + " ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.WriteLine("|   ");
                    }

                    if (j == 6 || j == 12)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.SetCursorPosition(i, j);
                        Console.WriteLine("|===");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    if (i == 12 || i == 24)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.SetCursorPosition(i, j);
                        Console.WriteLine("|");
                        Console.SetCursorPosition(i, j + 1);
                        Console.WriteLine("|");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    if (j == 0)
                    {
                        Console.SetCursorPosition(i, j);
                        Console.WriteLine("    ");
                    }

                    if (i == 0)
                    {
                        Console.SetCursorPosition(i, j);
                        Console.WriteLine(" ");                        
                        Console.WriteLine(" ");                        
                    }
                    
                }
            }

        }

        public void ChoosePosition()
        {

            Console.SetCursorPosition(0, 20);
            string input;

            Console.WriteLine("Ange rad:");
            input = Console.ReadLine();
            Int32.TryParse(input, out userY);                
            userY--;

            Console.WriteLine("Ange kolumn:");
            input = Console.ReadLine();
            Int32.TryParse(input, out userX);
            userX--;

            Console.WriteLine("Ange nummer:");
            input = Console.ReadLine();
            Int32.TryParse(input, out newNumber);
        }

        public void CheckPosition()
        {
            if (table[userY, userX] != 0)
                isValid = false;
        }

        public void CheckSquare()
        {
            if (userY >= 0 && userY < 3 && userX >= 0 && userX <= 2)
                inSquare = 1;
            else if (userY >= 0 && userY < 3 && userX > 2 && userX <= 5)
                inSquare = 2;
            else if (userY >= 0 && userY < 3 && userX > 5 && userX <= 8)
                inSquare = 3;
            else if (userY >= 3 && userY < 6 && userX >= 0 && userX <= 2)
                inSquare = 4;
            else if (userY >= 3 && userY < 6 && userX > 2 && userX <= 5)
                inSquare = 5;
            else if (userY >= 3 && userY < 6 && userX > 5 && userX <= 8)
                inSquare = 6;
            else if (userY >= 6 && userY < 9 && userX >= 0 && userX <= 2)
                inSquare = 7;
            else if (userY >= 6 && userY < 9 && userX > 2 && userX <= 5)
                inSquare = 8;
            else if (userY >= 6 && userY < 9 && userX > 5 && userX <= 8)
                inSquare = 9;

            switch (inSquare)
            {
                case 1:
                    minX = 0;
                    minY = 0;
                    break;
                case 2:
                    minX = 3;
                    minY = 0;
                    break;
                case 3:
                    minX = 6;
                    minY = 0;
                    break;
                case 4:
                    minX = 0;
                    minY = 3;
                    break;
                case 5:
                    minX = 3;
                    minY = 3;
                    break;
                case 6:
                    minX = 6;
                    minY = 3;
                    break;
                case 7:
                    minX = 0;
                    minY = 6;
                    break;
                case 8:
                    minX = 3;
                    minY = 6;
                    break;
                case 9:
                    minX = 6;
                    minY = 6;
                    break;
                default:
                    minX = 0;
                    minY = 0;
                    Console.WriteLine("Error!!!");
                    break;
            }

            for (int i = minY; i <= minY + 2; i++)
            {
                for (int j = minX; j <= minX + 2; j++)
                {
                    if (table[userY, userX] == newNumber)
                        isValid = false;
                }                
            }
        }
        public void CheckLines()
        {
            for (int i = 0; i <= 8; i++)
            {
                if (table[userY, i] == newNumber)
                    isValid = false;
            }
            for (int i = 0; i <= 8; i++)
            {
                if (table[i, userX] == newNumber)
                    isValid = false;
            }
        }
        public void CheckIfValid()
        {
            if (!isValid)
            {
                Console.WriteLine("Wrong! try again");
            }
            else
            {
                table[userY, userX] = newNumber;
                Console.WriteLine("Correct!");
            }
            Console.WriteLine("Press any key to continue playing.");
            Console.ReadKey();
            Console.Clear();
        }
   
    }

}
