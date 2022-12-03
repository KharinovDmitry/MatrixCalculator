using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixCalculator
{
    public class Matrix
    {
        private readonly int[,] values;
        public readonly int Width;
        public readonly int Height;

        public int this[int height, int width]
        {
            get
            {
                return values[height, width];
            }
        }

        public Matrix(int[,] matrix)
        {
            values = matrix;
            Height = matrix.GetLength(0);
            Width = matrix.GetLength(1);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    sb.Append(this[i, j]);
                    if(j != Width - 1)
                    {
                        sb.Append(" ");
                    }
                }
                sb.Append("\n");
            }
            return sb.ToString();
        }

        public static Matrix Sum(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.Width != matrix2.Width || matrix1.Height != matrix2.Height)
                throw new ArgumentException("Операция невозможна");

            int[,] values = new int[matrix1.Height, matrix2.Width];
            for (int i = 0; i < matrix1.Height; i++)
            {
                for (int j = 0; j < matrix2.Width; j++)
                {
                    values[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }

            return new Matrix(values);
        }

        public static Matrix Minus(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.Width != matrix2.Width || matrix1.Height != matrix2.Height)
                throw new ArgumentException("Операция невозможна");

            int[,] values = new int[matrix1.Height, matrix2.Width];
            for (int i = 0; i < matrix1.Height; i++)
            {
                for (int j = 0; j < matrix2.Width; j++)
                {
                    values[i, j] = matrix1[i, j] - matrix2[i, j];
                }
            }

            return new Matrix(values);
        }

        public static Matrix Transponate(Matrix matrix)
        {
            int[,] values = new int[matrix.Width, matrix.Height];
            for (int i = 0; i < matrix.Height; i++)
            {
                for (int j = 0; j < matrix.Width; j++)
                {
                    values[j, i] = matrix[i, j];
                }
            }
            return new Matrix(values);
        }

        public static Matrix Multyply(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.Width != matrix2.Height)
                throw new ArgumentException("Операция невозможна");

            int[,] values = new int[matrix1.Height, matrix2.Width];
            for (int i = 0; i < matrix1.Height; i++)
            {
                for (int j = 0; j < matrix2.Width; j++)
                {
                    for (int c = 0; c < matrix1.Width; c++)
                    {
                        values[i, j] += matrix1[i, c] * matrix2[c, j];
                    }
                }
            }

            return new Matrix(values);
        }
    }
}
