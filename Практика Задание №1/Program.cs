using System;

namespace Практика_Задание__1
{
    // Задание: Два отрезка на плоскости заданы целочисленными координатами своих концов в декартовой системе координат.
    //          Требуется определить, существует ли у них общая точка.
    public class Program
    {
        public static string[] ReadFromFile()
        {
            string[] coords = new string[8];
            for (int i = 0; i < 8; i += 2) // Распределяет координаты попарно x1,y1,x2...
            {
                string coordsPair = Console.ReadLine();
                coords[i] = coordsPair.Split(' ')[0];
                coords[i + 1] = coordsPair.Split(' ')[1];
            }
            return coords;
        }                                                     // Читает координаты отрезков

        public static void DoLineCross(string[] coords)
        {                            // Получает координаты
            long x1 = int.Parse(coords[0]), x2 = int.Parse(coords[2]), x3 = int.Parse(coords[4]), x4 = int.Parse(coords[6]), // Координаты х и у
                y1 = int.Parse(coords[1]), y2 = int.Parse(coords[3]), y3 = int.Parse(coords[5]), y4 = int.Parse(coords[7]);

            bool pseudoscalarProduct1 = ((x2 - x1) * (y4 - y1) - (x4 - x1) * (y2 - y1)) * ((x2 - x1) * (y3 - y1) - (x3 - x1) * (y2 - y1)) <= 0, // Произведение косых произведений: [P1P2, P1P4] * [P1P2, P1P3], P1-P4, имеют координаты с соответсвующими индексами, требуется для того, чтобы проверить, что концы каждого из отрезков лежат по разные стороны относительного концов другого отрезка
                 pseudoscalarProduct2 = ((x4 - x3) * (y1 - y3) - (x1 - x3) * (y4 - y3)) * ((x4 - x3) * (y2 - y3) - (x2 - x3) * (y4 - y3)) <= 0, // Произведение косых произведений: [P3P4, P3P1] * [P3P4, P3P2], P1-P4, имеют координаты с соответсвующими индексами, требуется для того, чтобы проверить, что концы каждого из отрезков лежат по разные стороны относительного концов другого отрезка
                 scalarProduct1 = (x1 - x3) * (x2 - x3) + (y1 - y3) * (y2 - y3) <= 0, // Скалярное произведение (P3P1,P3P2)
                 scalarProduct2 = (x1 - x4) * (x2 - x4) + (y1 - y4) * (y2 - y4) <= 0, // Скалярное произведение (P4P1,P4P2)
                 scalarProduct3 = (x3 - x1) * (x4 - x1) + (y3 - y1) * (y4 - y1) <= 0, // Скалярное произведение (P1P3,P1P4)
                 scalarProduct4 = (x3 - x2) * (x4 - x2) + (y3 - y2) * (y4 - y2) <= 0; // Скалярное произведение (P2P3,P2P4)

            if (pseudoscalarProduct1 & pseudoscalarProduct2 & // Если оба произведения косых произведений <=0 значит концы каждого из отрезков лежат по разные стороны относительного концов другого отрезка 
                (scalarProduct1 | scalarProduct2 | scalarProduct3 | scalarProduct4)) // Но, требуется проверить, что хотя бы один из концов одного отрезка принадлежит другому отрезку, в случае если отрезки части одной прямой (произведение косых произведений=0)
                Console.WriteLine("Yes"); // Записывает "Yes", если общая точка есть

            Console.WriteLine("No"); // Или "No" - в противном случае
        }                                           // Выясняет пересекаются ли отрезки с помощью угловых коэффициентов

        public static void Main(string[] args)
        {
            DoLineCross(ReadFromFile());
        }
    }
}
