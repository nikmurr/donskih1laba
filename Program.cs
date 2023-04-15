using System;
using System.Linq;
using System.Collections.Generic;

namespace Mur2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string mainCounter;
            do
            {
                Console.WriteLine("Привет! Это программа, которая умеет определять вид и площадь треугольника.\n");
                uint a;
                uint b;
                uint c;
                while (true)
                {
                    while (true)
                    {
                        Console.Write("Сторона а равна: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        string aStr = Console.ReadLine();
                        Console.ResetColor();
                        if (NumTest(aStr) == 1)
                        {
                            a = Convert.ToUInt32(aStr);
                            break;
                        }
                    }
                    while (true)
                    {
                        Console.Write("Сторона b равна: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        string bStr = Console.ReadLine();
                        Console.ResetColor();
                        if (NumTest(bStr) == 1)
                        {
                            b = Convert.ToUInt32(bStr);
                            break;
                        }
                    }
                    while (true)
                    {
                        Console.Write("Сторона c равна: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        string cStr = Console.ReadLine();
                        Console.ResetColor();
                        if (NumTest(cStr) == 1)
                        {
                            c = Convert.ToUInt32(cStr);
                            break;
                        }
                    }

                    if ((a + b <= c) || (a + c <= b) || (b + c <= a))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ошибка! Треугольник с такими сторонами не существует.\n");
                        Console.ResetColor();
                    }
                    else
                    {
                        break;
                    }
                }
                double S;
                Console.Write("\nТип треугольника: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                if ((a == b) && (a == c))
                {
                    Console.Write("равносторонний, ");
                    S = Math.Round(Math.Sqrt(3) / 4 * Math.Pow(a, 2), 4);
                    Console.WriteLine("остроугольный;");
                }
                else if ((a == b) || (a == c) || (b == c))
                {
                    Console.Write("равнобедренный,");
                    if (a == b)
                    {
                        S = Math.Round((c * Math.Sqrt(Math.Pow(a, 2) - (Math.Pow(c, 2) / 4))) / 2, 4);
                        DefKind(a, b, c);
                    }
                    else if (a == c)
                    {
                        S = Math.Round((b * Math.Sqrt(Math.Pow(a, 2) - (Math.Pow(b, 2) / 4))) / 2, 4);
                        DefKind(a, b, c);
                    }
                    else
                    {
                        S = Math.Round((a * Math.Sqrt(Math.Pow(b, 2) - (Math.Pow(a, 2) / 4))) / 2, 4);
                        DefKind(a, b, c);
                    }
                }
                else
                {
                    Console.Write("разносторонний,");
                    DefKind(a, b, c);
                    double p = (a + b + c) / 2;
                    S = Math.Round(Math.Sqrt(p * (p - a) * (p - b) * (p - c)), 4);
                }
                Console.ResetColor();
                Console.WriteLine($"\nЕго площадь равна {S}.");

                Console.Write("\n\nПовторить программу? Введите 1, если да, или любое другое значение для завершения: ");
                Console.ForegroundColor = ConsoleColor.Green;
                mainCounter = Console.ReadLine();
                Console.ResetColor();
                Console.WriteLine();

            } while (mainCounter == "1");
        }

        static int NumTest(string strSide)
        {
            if (uint.TryParse(strSide, out uint side))
            {
                if (side != 0)
                {
                    return 1;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка! Сторона треугольника не может равняться нулю.");
                    Console.ResetColor();
                    return 0;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка! Введенное значение не может быть обозначать сторону треугольника.");
                Console.ResetColor();
                return 0;
            }
        }

        static void DefKind(uint a, uint b, uint c)
        {
            List<uint> values = new List<uint>() { a, b, c };
            List<uint> orderedValues = values.OrderBy(n => n).ToList();
            a = orderedValues[0];
            b = orderedValues[1];
            c = orderedValues[2];
            if (Math.Pow(c, 2) > Math.Pow(b, 2) + Math.Pow(a, 2))
            {
                Console.WriteLine("тупоугольный;");
            }
            else if (Math.Pow(c, 2) < Math.Pow(b, 2) + Math.Pow(a, 2))
            {
                Console.WriteLine("остроугольный;");
            }
            else
            {
                Console.WriteLine("прямоугольный;");
            }
        }
    }
}
