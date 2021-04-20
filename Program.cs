using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("please enter the num of rows:");
            int row = int.Parse(Console.ReadLine());
            Console.WriteLine("please enter the num of colums:");
            int column = int.Parse(Console.ReadLine());
            double[,] matric = new double[row, column];
            if (row + 1 == column && row != 0)
            {
                Console.WriteLine("please enter" + " " + row * column + " " + "values:");

                readArray(row, column, matric);
                printArray(row, column, matric);

                Console.WriteLine("*********************************");
                Console.ReadKey();
                Console.Beep();

                Console.WriteLine("gauss-gordon steps");
                bool w = false; bool q = true;
                for (int s = 0; s < row; s++)
                {
                    double leading = matric[s, s];

                    //(((((((((((((((((((((((((((((((((((((((((((((((swapping))))))))))))))))))))))))))))))))))))

                    if (matric[s, s] == 0 && w == true)
                    {
                        double z;
                        for (int i = 0; i < column; i++)
                        {
                            z = matric[s, i];
                            matric[s, i] = matric[s + 1, i];
                            matric[s + 1, i] = z;
                        }
                    }

                        //make sure that

                    else if (matric[row - 1, s] == 0 && matric[row - 1, column - 1] == 0)
                    {
                        w = true; q = q & w;
                        if (q == true)
                        {
                            Console.WriteLine("There are too many solution");
                            break;
                        }
                    }

                    else if (matric[row - 1, s] == 0 && matric[row - 1, column - 1] != 0)
                    {
                        w = true; q = q & w; if (q == true)
                        {
                            Console.WriteLine("There is no solution"); break;
                        }
                    }


                    //


                    for (int j = 0; j < column; j++)
                    {
                        matric[s, j] = (1 / leading * matric[s, j]);
                    }

                    for (int k = 0; k < row; k++)
                    {
                        leading = matric[k, s];
                        if (s != k)
                        {
                            for (int j = 0; j < column; j++)
                            { matric[k, j] = matric[k, j] - (leading * matric[s, j]); }

                            for (int i = 0; i < row; i++)
                            {
                                for (int j = 0; j < column; j++)
                                { Console.Write("{0}\t", matric[i, j]); }
                                Console.WriteLine();
                            }
                            Console.WriteLine("*********************************");
                            Console.Beep();
                            Console.ReadKey();

                        }
                    }
                }

                if (w == false)
                {

                    Console.WriteLine("finally the solution:");
                    for (int i = 0; i < row; i++)
                    {
                        for (int j = 0; j < column; j++)
                        { Console.Write("{0}\t", matric[i, j]); }
                        Console.WriteLine();
                    }
                    Console.WriteLine("*********************************");
                    Console.Beep();
                    System.Console.ReadKey();
                    System.Console.ReadKey();
                }
            }
            else { Console.WriteLine("NOT VALID(THE NUM OF COLUMS MUST = THE NUM OF ROWS+1)"); }
            Console.Beep();
            Console.ReadKey();

        }

        private static void printArray(int m, int n, double[,] matric)
        {
            Console.WriteLine("your augmented matrix is:");
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                { Console.Write("{0}\t", matric[i, j]); }
                Console.WriteLine();
            }
        }

        private static void readArray(int m, int n, double[,] matric)
        {

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("[{0},{1}]=", i, j);
                    matric[i, j] = double.Parse(Console.ReadLine());
                }
            }
        }
    }
}
