// Урок 7. Двумерные массивы

//-----------------------------------------------------------------------------------

while (true)
{
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine("Введите номер задачи:");
    Console.WriteLine("47) Задача 47. Задайте двумерный массив размером m x n, заполненный случайными вещественными числами.");
    Console.WriteLine("50) Задача 50. Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, и возвращает значение этого элемента или же указание, что такого элемента нет.");
    Console.WriteLine("52) Задача 52. Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.");
    Console.WriteLine();
    Console.WriteLine("0) Или введите 0 для выхода из программы");
    int menuNum = SetNumber("");
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine();

    switch (menuNum)
    {
        case 0: return; break;
        case 47: Task47(); break;
        case 50: Task50(); break;
        case 52: Task52(); break;
        default: Console.WriteLine($"Задачи №{menuNum}, не существует"); break;
    }
}

//-----------------------------------------------------------------------------------

int SetNumber(string messageEnt)
{
    Console.WriteLine(messageEnt);
    int num = int.Parse(Console.ReadLine());
    return num;
}

double SetNumberReal(string messageEnt)
{
    Console.WriteLine(messageEnt);
    double num = double.Parse(Console.ReadLine());
    return num;
}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j]} ");
        }
        Console.WriteLine();
    }
}

void PrintMatrixReal(double[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{Math.Round(matrix[i, j], 2)} ");
        }
        Console.WriteLine();
    }
}

int[,] GetMatrix(int rows, int columns, int minValue, int maxValue)
{
    int[,] matrix = new int[rows, columns];

    Random random = new Random();

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            matrix[i, j] = random.Next(minValue, maxValue + 1);
        }
    }
    return matrix;
}

void PrintArrayReal(double[] array)
{
    int i = 0;
    System.Console.Write("[");
    for (i = 0; i < array.Length; i++)
    {
        System.Console.Write($"{Math.Round(array[i], 2)}");
        if (i != array.Length - 1) System.Console.Write("; ");
    }
    System.Console.Write("]");
    System.Console.WriteLine();
}



// Задача 47. Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.

// m = 3, n = 4.
// 0,5 7 -2 -0,2
// 1 -3,3 8 -9,9
// 8 7,8 -7,1 9

double[,] GetMatrixReal(int rows, int columns, int minValue, int maxValue)
{
    double[,] matrix = new double[rows, columns];

    Random random = new Random();

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            matrix[i, j] = random.NextDouble() * (maxValue - minValue) + minValue;
        }
    }
    return matrix;
}

void Task47()
{
    int rows = SetNumber("Введите количество строк m:");
    int columns = SetNumber("Введите количество столбцов n:");
    int min = SetNumber("Введите min:");
    int max = SetNumber("Введите max:");
    Console.WriteLine();

    double[,] matrix = GetMatrixReal(rows, columns, min, max);
    PrintMatrixReal(matrix);
}



// Задача 50. Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, и возвращает значение этого элемента или же указание, что такого элемента нет.

// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 17 -> такого числа в массиве нет

void MatrixElement(int[,] matrix, int row, int column)
{
    if (row < matrix.GetLength(0) && column < matrix.GetLength(1))
    {
        Console.WriteLine($"Элемент массива [{row}, {column}] = {matrix[row, column]}");
    }
    else
    {
        Console.WriteLine($"Элемент массива [{row}, {column}] не существует");
    }
}

void Task50()
{
    int rows = SetNumber("Введите количество строк:");
    int columns = SetNumber("Введите количество столбцов:");
    int min = SetNumber("Введите min:");
    int max = SetNumber("Введите max:");
    Console.WriteLine();

    int[,] matrix = GetMatrix(rows, columns, min, max);

    int rowNum = SetNumber("Введите строку:");
    int colNum = SetNumber("Введите столбец:");

    Console.WriteLine();
    Console.WriteLine();

    PrintMatrix(matrix);

    Console.WriteLine();
    Console.WriteLine();

    MatrixElement(matrix, rowNum, colNum);
}



// Задача 52. Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.

// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.

double[] ColumnAverage(int[,] matrix)
{
    double[] result = new double[matrix.GetLength(1)];

    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            result[j] += matrix[i, j];
        }
        result[j] /= matrix.GetLength(0);
    }
    return result;
}

void Task52()
{
    int rows = SetNumber("Введите количество строк:");
    int columns = SetNumber("Введите количество столбцов:");
    int min = SetNumber("Введите min:");
    int max = SetNumber("Введите max:");
    Console.WriteLine();

    int[,] matrix = GetMatrix(rows, columns, min, max);
    PrintMatrix(matrix);

    Console.WriteLine();
    Console.WriteLine();

    double[] colAverage = ColumnAverage(matrix);
    Console.Write("Среднее арифметическое каждого столбца: ");
    PrintArrayReal(colAverage);

    Console.WriteLine();
    Console.WriteLine();
}


