using System;

namespace Lab2
{
    class Program
    {
        static bool CheckNext(int[,] data, (int, int) pos, (int, int) delta)
        {
            var i = pos.Item1 + delta.Item1;
            var j = pos.Item2 + delta.Item2;
            if (i >= 0 && i <= data.GetUpperBound(0) && j >= 0 && j <= data.GetUpperBound(1))
            {
                return data[i, j] == 0;
            }
            return false;
        }

        static void Main(string[] args)
        {
            // Входные данные
            var inputData = new int[] {3, 4};
            Console.WriteLine(string.Join(',', inputData));

            // Выходные данные
            var outputData = new int[inputData[0], inputData[1]];

            // Начало алгоритма. O(n * m)
            var filler = inputData[0] * inputData[1];
            var pos = (i: 0, j: inputData[1] - 1);
            var delta = (i: 0, j: -1);
            outputData[0, inputData[1] - 1] = filler--;
            while (filler != 0)
            {
                if (CheckNext(outputData, pos, delta))
                {
                    pos.i += delta.i;
                    pos.j += delta.j;
                    outputData[pos.i, pos.j] = filler--;
                }
                else
                {
                    switch (delta)
                    {
                        case (0, -1):
                            delta = (i: 1, j: 0);
                            break;
                        case (1, 0):
                            delta = (i: 0, j: 1);
                            break;
                        case (0, 1):
                            delta = (i: -1, j: 0);
                            break;
                        case (-1, 0):
                            delta = (i: 0, j: -1);
                            break;
                    }
                    pos.i += delta.i;
                    pos.j += delta.j;
                    outputData[pos.i, pos.j] = filler--;
                }
            }
            // Конец алгоритма

            // Вывод выходных данных на консоль
            for (int i = 0; i < inputData[0]; ++i)
            {
                for (int j = 0; j < inputData[1]; ++j) Console.Write($"{outputData[i, j],2} ");
                Console.WriteLine();
            }
        }
    }
}