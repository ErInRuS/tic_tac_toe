using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Крестики-нолики";
            Console.CursorVisible = false;
            game();
        }

        static ConsoleColor borderColor = ConsoleColor.DarkGreen;
        static ConsoleColor borderSumbolColor = ConsoleColor.Green;
        static ConsoleColor colorStar = ConsoleColor.DarkGray;
        static ConsoleColor SumbolXColor = ConsoleColor.Red;
        static ConsoleColor SumbolYColor = ConsoleColor.Blue;


        static void game()
        {
            char x = 'X';
            char y = '0';
            char space = '*';
            bool hodX = true;
            char[,] matrix = new char[3, 3];
            int positionY = 2;
            int positionX = 1;
            int num = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = space;
                }
            }
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Нажмите любую кнопку");
            Console.ResetColor();
            ConsoleKeyInfo consoleKey = Console.ReadKey();
            int maxHod = matrix.Length;
            while (consoleKey.Key != ConsoleKey.Escape)
            {
                do
                {
                    Console.Clear();
                    if (hodX)
                    {
                        Console.Title = "Ход Х";
                    }
                    else
                    {
                        Console.Title = "Ход 0";
                    }
                    for (int k = 0; k < matrix.GetLength(0); k++)
                    {
                        if (k == 0)
                        {
                            Console.ForegroundColor = borderSumbolColor;
                            Console.WriteLine("+-+-+-+");
                            Console.ResetColor();
                        }
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            if (j == 0 | j == matrix.GetLength(1))
                            {
                                Console.ForegroundColor = borderSumbolColor;
                                Console.Write("|");
                                Console.ResetColor();
                            }
                            if (k == positionY & j == positionX)
                            {
                                if (matrix[k, j] == x)
                                {
                                    Console.ForegroundColor = SumbolXColor;
                                    Console.Write(matrix[k, j]);
                                    Console.ResetColor();
                                }
                                else if (matrix[k, j] == y)
                                {
                                    Console.ForegroundColor = SumbolYColor;
                                    Console.Write(matrix[k, j]);
                                    Console.ResetColor();
                                }
                                else
                                {
                                    if (Console.Title == "Ход 0")
                                    {
                                        Console.ForegroundColor = SumbolYColor;
                                        Console.Write(matrix[k, j]);
                                        Console.ResetColor();
                                    }
                                    else if (Console.Title == "Ход Х")
                                    {
                                        Console.ForegroundColor = SumbolXColor;
                                        Console.Write(matrix[k, j]);
                                        Console.ResetColor();
                                    }
                                }
                            }
                            else if (matrix[k, j] == x)
                            {
                                Console.ForegroundColor = SumbolXColor;
                                Console.Write(matrix[k, j]);
                                Console.ResetColor();
                            }
                            else if (matrix[k, j] == y)
                            {
                                Console.ForegroundColor = SumbolYColor;
                                Console.Write(matrix[k, j]);
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.ForegroundColor = colorStar;
                                Console.Write(matrix[k, j]);
                                Console.ResetColor();
                            }
                            Console.ForegroundColor = borderSumbolColor;
                            Console.Write("|");
                            Console.ResetColor();
                        }
                        Console.ForegroundColor = borderSumbolColor;
                        Console.WriteLine("\n+-+-+-+");
                        Console.ResetColor();
                    }
                    Console.ForegroundColor = colorStar;
                    Console.WriteLine($"[x {positionY} ,y {positionX} ]");
                    Console.ResetColor();
                    consoleKey = Console.ReadKey();
                    switch (consoleKey.Key)
                    {
                        case ConsoleKey.W:
                            if (positionY <= 0)
                            {
                                positionY = matrix.GetLength(0) - 1;
                            }
                            else
                            {
                                positionY--;
                            }
                            break;
                        case ConsoleKey.S:
                            if (positionY >= matrix.GetLength(0) - 1)
                            {
                                positionY = 0;
                            }
                            else
                            {
                                positionY++;
                            }
                            break;
                        case ConsoleKey.A:
                            if (positionX <= 0)
                            {
                                positionX = matrix.GetLength(1) - 1;
                            }
                            else
                            {
                                positionX--;
                            }
                            break;
                        case ConsoleKey.D:
                            if (positionX >= matrix.GetLength(1) - 1)
                            {
                                positionX = 0;
                            }
                            else
                            {
                                positionX++;
                            }
                            break;
                        case ConsoleKey.Enter:

                            if (hodX == true & matrix[positionY, positionX] != y & matrix[positionY, positionX] != x)
                            {
                                matrix[positionY, positionX] = x;
                                hodX = false;
                                num++;

                            }
                            else if (hodX == false & matrix[positionY, positionX] != x & matrix[positionY, positionX] != y
                                )
                            {
                                matrix[positionY, positionX] = y;
                                hodX = true;
                                num++;
                            }
                            break;
                    }
                } while (consoleKey.Key != ConsoleKey.Enter);
                bool winX = ChekPosition(x, matrix);
                bool winY = ChekPosition(y, matrix);
                if (winX)
                {
                    Console.Title = "Победа X";
                    Console.WriteLine($"Победили {x}");
                    Console.ReadKey();
                    break;
                }
                else if (winY == true)
                {
                    Console.Title = "Победа 0";
                    Console.WriteLine($"Победили {y}");
                    Console.ReadKey();
                    break;
                }
                if (num == matrix.Length)
                {
                    Console.WriteLine("Ничья");
                    Console.ReadKey();
                    return;
                }

            }
            Console.Clear();
            //for (int k = 0; k < matrix.GetLength(0); k++)
            //{
            //    for (int j = 0; j < matrix.GetLength(1); j++)
            //    {
            //        Console.Write(matrix[k, j]);
            //    }
            //    Console.WriteLine();
            //}
        }
        static bool ChekPosition(char x, char[,] arr)
        {
            if (arr[0, 0] == x & arr[1, 0] == x & arr[2, 0] == x || arr[0, 1] == x & arr[1, 1] == x & arr[2, 1] == x || arr[0, 2] == x & arr[1, 2] == x & arr[2, 2] == x ||
                arr[0, 0] == x & arr[0, 1] == x & arr[0, 2] == x || arr[1, 0] == x & arr[1, 1] == x & arr[1, 2] == x || arr[2, 0] == x & arr[2, 1] == x & arr[2, 2] == x ||
                arr[0, 0] == x & arr[1, 1] == x & arr[2, 2] == x || arr[0, 2] == x & arr[1, 1] == x & arr[2, 0] == x)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}