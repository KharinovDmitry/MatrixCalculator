using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixCalculator
{
    public static class MatrixLoader
    {
        public static Matrix ReadMatrix(string path)
        {
            string[] dataLines = File.ReadAllLines(path);
            int width = int.Parse(dataLines[0].Split(" ")[0]);
            int height = int.Parse(dataLines[0].Split(" ")[1]);
            int[,] values = new int[height, width];

            for (int i = 0; i < height; i++)
            {
                string[] numbers = dataLines[i + 1].Split(" ");
                for (int j = 0; j < width; j++)
                {
                    values[i, j] = int.Parse(numbers[j]);
                }
            }

            return new Matrix(values);
        }

        public static void SaveMatrix(Matrix matrix, string path)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{matrix.Width} {matrix.Height}\n");
            sb.Append(matrix.ToString());
            File.WriteAllText(Directory.GetCurrentDirectory() + path, sb.ToString());
        }
    }
}
