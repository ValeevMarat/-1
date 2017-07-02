using System;

namespace Практика_Задание__1
{
    // Задание: Два отрезка на плоскости заданы целочисленными координатами своих концов в декартовой системе координат.
    //          Требуется определить, существует ли у них общая точка.
    class Program
    {
        static string[] ReadFromFile()
        {
            return Console.ReadLine().Split(' ');
        }                                                     // Читает координаты отрезков

        static bool DoLineCross(string[] coords)
        {                       // Получает координаты
            int[] xArray = {int.Parse(coords[0]),int.Parse(coords[2]),int.Parse(coords[4]),int.Parse(coords[6])}; // Создание массива с координатами x
            int[] yArray = {int.Parse(coords[1]),int.Parse(coords[3]),int.Parse(coords[5]),int.Parse(coords[7])}; // Создание массива с координатами y

            ArrangeByAscending(ref xArray, ref yArray, 0);                                                        // Для корректного вычисления углового коэффициента требуется x1<=x2
            ArrangeByAscending(ref xArray, ref yArray, 2);                                                        // Для корректного вычисления углового коэффициента требуется x3<=x4

            double k1 = yArray[0] == yArray[1] ? 0 : (yArray[1] - yArray[0]) / (xArray[1] - xArray[0]);           // Если y1=y2, то коэффициент = 0 иначе считаем по уравнению прямой
            double k2 = yArray[2] == yArray[3] ? 0 : (yArray[3] - yArray[2]) / (xArray[3] - xArray[2]);           // Если y3=y4, то коэффициент = 0 иначе считаем по уравнению прямой

            if (k1==k2) return false;                                                                             // Прямые параллельны

            double x= (yArray[1] - k2 * xArray[2] - yArray[0] - k1 * xArray[0]) / (k1 - k2);                      // Вычисление точки пересечения прямых
            return (x < xArray[1]) & (x > xArray[0]) & (x < xArray[3]) & (x > xArray[2]);                         // Проверка на положение точки вне отрезков
        }                                           // Выясняет пересекаются ли отрезки с помощью угловых коэффициентов
        static void ArrangeByAscending(ref int[] xArray, ref int[] yArray, int startIndex)
        {                              // Массив х-ов   // Массив у-ов     // С какого индекса начать сравнение
            if (xArray[startIndex] > xArray[startIndex+1])
            {
                int temp = xArray[startIndex];
                xArray[startIndex] = xArray[startIndex+1];
                xArray[startIndex+1] = temp;

                temp = yArray[startIndex];
                yArray[startIndex] = yArray[startIndex+1];
                yArray[startIndex+1] = temp;
            }
        } // Для корректного вычисления углового коэффициента требуется x1<=x2,x3<=x4

        static void WriteToFile(bool doCross)
        {                       // Пересекаются ли отрезки
            Console.WriteLine(doCross ? "Yes" : "No"); // Соответсвенный ответ
        }                                              // Записывает "Yes", если общая точка есть, или слово "No" - в противном случае. 

        static void Main(string[] args)
        {
            WriteToFile(DoLineCross(ReadFromFile())); // Запись в файл ответа, исходящего из поиска коэффициентов после чтения координат из файла
        }
    }
}
