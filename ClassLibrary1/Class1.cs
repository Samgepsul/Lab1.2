using System;

namespace ConsoleApp3
{
    public class ArrayProcessor
    {
        private int[,] arr;
        private readonly int HEIGHT;
        private readonly int WIDTH;

        public ArrayProcessor(int height, int width)
        {
            HEIGHT = height;
            WIDTH = width;
            arr = new int[HEIGHT, WIDTH];
        }
        public void SetArray(int[,] array)
        {
            if (array.GetLength(0) != HEIGHT || array.GetLength(1) != WIDTH)
                throw new ArgumentException("Размер массива не соответствует ожидаемому.");

            arr = array;
        }


        public int[,] GenerateRandomArray(int minValue, int maxValue)
        {
            Random random = new Random();
            for (int i = 0; i < HEIGHT; i++)
            {
                for (int j = 0; j < WIDTH; j++)
                {
                    arr[i, j] = random.Next(minValue, maxValue);
                }
            }
            return arr;
        }

        public int GetCountNegativeElementsInRow(int row)
        {
            int count = 0;
            for (int j = 0; j < WIDTH; j++) 
            {
                if (arr[row, j] < 0)
                    count++;
            }
            return count;
        }


        public bool IsSaddlePoint(int row, int col)
        {
            return Saddle(arr, row, col);
        }

        private static bool Saddle(int[,] arr, int indexHeight, int indexWidth)
        {
            int currentNumber = arr[indexHeight, indexWidth];
            int width = arr.GetLength(1);
            int height = arr.GetLength(0);

            // В седловой точке элемент должен быть самым маленьким в своей строке,
            // и самым большим в своём столбце.
            for (int i = 0; i < width; i++)
            {
                if (arr[indexHeight, i] < currentNumber)
                    return false;
            }

            for (int i = 0; i < height; i++)
            {
                if (arr[i, indexWidth] > currentNumber)
                    return false;
            }

            return true;
        }



    }
}
