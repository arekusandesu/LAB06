using System;
using System.Collections.Generic;
using System.Text;

namespace LAB06
{
    internal class Matrix
    {
        private int size;
        public int Size
        {
            get
            {
                return size;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Размерность должна быть положительной.");
                }
                size = value;
            }
        }
        private double[,] data;
        public double[,] Data
        {
            get
            {
                return data;
            }
            set
            { 
                data = value;
            }
        }
        public Matrix(int size, double[,] data)
         {
            Size = size;
            if (data == null)
            {
                throw new ArgumentException($"Массив не должен быть null.");
            }

            if (data.GetLength(0) != size || data.GetLength(1) != size)
            {
                throw new ArgumentException($"Массив должен иметь размер {size} на {size}.");
            }
            Data = data;
        }
        public static Matrix operator +(Matrix a, Matrix b)
        {
            SameMatrixSize(a, b);
            double[,] newMatrix = new double[a.Size, a.Size];

            for (int i = 0;  i < a.Size; i++)
            {
                for (int j = 0; j < a.Size; j++)
                {
                    newMatrix[i, j] = a.Data[i, j] + b.Data[i, j];
                }
            }
            return new Matrix(a.Size, newMatrix);
        }
        public static Matrix operator -(Matrix a, Matrix b)
        {
            SameMatrixSize(a, b);
            double[,] newMatrix = new double[a.Size,a.Size];

            for (int i = 0; i < a.Size; i++)
            {
                for (int j = 0; j < a.Size; j++)
                {
                    newMatrix[i, j] = a.Data[i, j] - b.Data[i, j];
                }
            }
            return new Matrix(a.Size, newMatrix);
        }
        public static Matrix operator *(Matrix a, Matrix b)
        {
            SameMatrixSize(a, b);
            double[,] newMatrix = new double[a.Size,a.Size];

            for (int i = 0; i < a.Size; i++)
            {
                for (int j = 0; j < a.Size; j++)
                {
                    newMatrix[i, j] = a.Data[i, j] * b.Data[i, j];
                }
            }
            return new Matrix(a.Size, newMatrix);
        }
        public static Matrix operator /(Matrix a, double k)
        {
            if (k == 0)
            {
                throw new DivideByZeroException($"Нельзя делить матрицу на 0.");
            }

            double[,] newMatrix = new double[a.Size, a.Size];

            for (int i = 0; i < a.Size; i++)
            {
                for (int j = 0; j < a.Size; j++)
                {
                    newMatrix[i, j] = a.Data[i, j] / k;
                }
            }
            return new Matrix(a.Size, newMatrix);
        }
        private static void SameMatrixSize(Matrix a, Matrix b)
        {
            if (a.Size != b.Size)
            {
                throw new ArgumentException($"Размерность массивов должна быть одинаковой.");
            }
        }
        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < Size; i++)
            {
                result += "|  ";
                for (int j = 0; j < Size; j++)
                {
                    result += Data[i, j] + "  ";
                }
                result += "|\n";
            }
            return result;
        }
   }
}
