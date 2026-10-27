using LAB06;

double[,] aData =
    {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
    };

double[,] bData =
    {
                { 9, 8, 7 },
                { 6, 5, 4 },
                { 3, 2, 1 }
    };

Matrix A = new Matrix(3, aData);
Matrix B = new Matrix(3, bData);

Console.WriteLine($"Матрица A: \n{A}");
Console.WriteLine();

Console.WriteLine($"Матрица B: \n{B}");
Console.WriteLine();

Console.WriteLine($"A + B: \n{A + B}");
Console.WriteLine();

Console.WriteLine($"A - B: \n{A - B}");
Console.WriteLine();

Console.WriteLine($"A * B: \n{A * B}");
Console.WriteLine();

Console.WriteLine($"A / 2: \n{A / 2}");
Console.WriteLine();

try
{
    double[,] badData =
        { 
                 { 1, 2 },
                 { 3, 4 } 
        };
    Matrix badMatrix = new Matrix(3, badData);
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}

try
{
    Matrix badMatrix = new Matrix(0, new double[0, 0]);
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}

try
{
    Matrix C = A / 0;
}
catch (DivideByZeroException ex)
{
    Console.WriteLine(ex.Message);
}

try
{
    Matrix badMatrix = new Matrix(3, null);
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}
