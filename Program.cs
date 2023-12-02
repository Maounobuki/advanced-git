// Задача 68: Напишите программу вычисления функции Аккермана 
//с помощью рекурсии. Даны два неотрицательных числа m и n.
// m = 2, n = 3 -> A(m,n) = 9
// m = 3, n = 2 -> A(m,n) = 29

Console.Write("введите число m: ");
int m = int.Parse(Console.ReadLine()!);

Console.Write("введите число n: ");
int n = int.Parse(Console.ReadLine()!);
if(m < 0 || n < 0) 
{
Console.WriteLine("Недопустимое значение");
 return;
 }

Console.WriteLine(AckermanFunction(m,n));

int AckermanFunction(int m, int n){
    if ( m == 0) return  n+1;
    if ( m>0 && n==0) return AckermanFunction(m-1,1);
    return AckermanFunction(m-1,AckermanFunction(m,n-1)); 
}
﻿/*Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2
*/

Console.WriteLine("Программа упорядочит элементы двумерного массива по строкам");
Console.WriteLine($"\nВведите размер массива m x n , максимальное и минимальное значение:");

int m = InputNumber("Введите m: ");
int n = InputNumber("Введите n: ");

if (m == 0 || n == 0)
{
    Console.WriteLine("Размер массива не может быть равен 0");
    Thread.Sleep(1500);
    Environment.Exit(0);
}

int minValue = InputNumber("Введите минимальное значаение: ");
int maxValue = InputNumber("Введите максимальное значаение: ");

if (minValue > maxValue)
{
    Console.WriteLine("Минимальное значение должно быть меньше максимального");
    Thread.Sleep(1500);
    Environment.Exit(0);
}


Console.WriteLine("Созданный массив: ");
int[,] matrix = CreateMatrixInt(m, n, minValue, maxValue);
PrintMatrix(matrix);

Console.WriteLine("Упорядоченный построчно массив: ");
StreamlineMatrix(matrix);
PrintMatrix(matrix);

#region Methods
int InputNumber(string message)
{
    while (true)
    {
        Console.Write(message);
        bool result = int.TryParse(Console.ReadLine(), out int value);

        if (!result)
        {
            Console.WriteLine($"Введены некоректные данные. {message} еще раз!");
            Thread.Sleep(1500);
            Console.Clear();

            continue;
        }

        return value;
    }
}

int[,] CreateMatrixInt(int rows, int colums, int minValue, int maxValue)
{
    Random random = new Random();
    int[,] matrix = new int[rows, colums];

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = random.Next(minValue, maxValue);
        }
    }

    return matrix;
}


void StreamlineMatrix(int[,] matrix)
{

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            for (int k = 0; k < matrix.GetLength(1) - 1; k++)
            {
                if (matrix[i, k] < matrix[i, k + 1])
                {
                    int temp = matrix[i, k + 1];
                    matrix[i, k + 1] = matrix[i, k];
                    matrix[i, k] = temp;
                }
            }
        }
    }

}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j],5}");
        }
        Console.WriteLine();
    }
}


#endregion

﻿/*Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7
Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка
*/

Console.WriteLine("Программа,найдет строку с наименьшей суммой элементов.");
Console.WriteLine($"\nВведите размер массива m x n , максимальное и минимальное значение:");

int m = InputNumber("Введите m: ");
int n = InputNumber("Введите n: ");

if (m == 0 || n == 0)
{
    Console.WriteLine("Размер массива не может быть равен 0");
    Thread.Sleep(1500);
    Environment.Exit(0);
}

int minValue = InputNumber("Введите минимальное значаение: ");
int maxValue = InputNumber("Введите максимальное значаение: ");

if (minValue > maxValue)
{
    Console.WriteLine("Минимальное значение должно быть меньше максимального");
    Thread.Sleep(1500);
    Environment.Exit(0);
}

Console.WriteLine("Созданный массив: ");
int[,] matrix = CreateMatrixInt(m, n, minValue, maxValue);
PrintMatrix(matrix);

(int, int) minSum = MinSumRowElements(matrix);

Console.WriteLine($"Минимальная сумма элементов Найдена в {minSum.Item1} строке, \nИ равна {minSum.Item2}");


#region Methods
int InputNumber(string message)
{
    while (true)
    {
        Console.Write(message);
        bool result = int.TryParse(Console.ReadLine(), out int value);

        if (!result)
        {
            Console.WriteLine($"Введены некоректные данные. {message} еще раз!");
            Thread.Sleep(1500);
            Console.Clear();

            continue;
        }

        return value;
    }
}

int[,] CreateMatrixInt(int rows, int colums, int minValue, int maxValue)
{
    Random random = new Random();
    int[,] matrix = new int[rows, colums];

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = random.Next(minValue, maxValue);
        }
    }

    return matrix;
}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j],5}");
        }
        Console.WriteLine();
    }
}

(int, int) MinSumRowElements(int[,] matrix)
{
    int minSumRows = 0;
    int sum = int.MaxValue;

    for (int i = 0; i < matrix.GetLength(0); i++)
    {

        int temp = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            temp += matrix[i, j];
        }

        if (temp < sum)
        {
            sum = temp;
            minSumRows = i;
        }
    }

    return (minSumRows, sum);
}

#endregion
﻿/*Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18
*/

Console.WriteLine("Программа, найдет произведение двух матриц.");
Console.WriteLine("Колличество строк первой матрицы должно быть равно количеству столбцов второй матрицы");
Console.WriteLine($"Введите размеры матриц (m x n):");
int firstMatrixRows = InputNumber("Введите колличество строк 1-й матрицы(m1): ");
int firstMatrixColums = InputNumber("Введите колличество столбцов 1-й матрицы (и строк 2-й)(n1 = m2): ");
int secondMatrixColums = InputNumber("Введите колличество столбцов 2-й матрицы (n2): ");

if (firstMatrixRows == 0 || firstMatrixColums == 0 || secondMatrixColums == 0)
{
    Console.WriteLine("Размер массива не может быть равен 0");
    Thread.Sleep(1500);
    Environment.Exit(0);
}

int minValue = InputNumber("Введите минимальное значаение: ");
int maxValue = InputNumber("Введите максимальное значаение: ");

if (minValue > maxValue)
{
    Console.WriteLine("Минимальное значение должно быть меньше максимального");
    Thread.Sleep(1500);
    Environment.Exit(0);
}

Console.WriteLine("Первый массив: ");
int[,] firstMatrix = CreateMatrixInt(firstMatrixRows, firstMatrixColums, minValue, maxValue);
PrintMatrix(firstMatrix);

Console.WriteLine("Второй массив: ");
int[,] secondMatrix = CreateMatrixInt(firstMatrixColums, secondMatrixColums, minValue, maxValue);
PrintMatrix(secondMatrix);

Console.WriteLine("Результат перемножения 2х массивов");
int[,] multiplyMatrix = MultiplyMatrix(firstMatrix, secondMatrix);
PrintMatrix(multiplyMatrix);



#region Methods
int InputNumber(string message, bool number = false)
{
    while (true)
    {
        Console.Write(message);
        bool result = int.TryParse(Console.ReadLine(), out int value);

        if (!result)
        {
            Console.WriteLine($"Введены некоректные данные. {message} еще раз!");
            Thread.Sleep(1500);
            Console.Clear();

            continue;
        }

        return value;
    }
}

int[,] CreateMatrixInt(int rows, int colums, int minValue, int maxValue)
{
    Random random = new Random();
    int[,] matrix = new int[rows, colums];

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = random.Next(minValue, maxValue);
        }
    }

    return matrix;
}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j],10}");
        }
        Console.WriteLine();
    }
}

int[,] MultiplyMatrix(int[,] firstMartrix, int[,] secomdMartrix)
{
    int[,] multiplyMatrix = new int[firstMartrix.GetLength(0), secomdMartrix.GetLength(1)];
    for (int i = 0; i < multiplyMatrix.GetLength(0); i++)
    {
        for (int j = 0; j < multiplyMatrix.GetLength(1); j++)
        {
            int multiply = 0;
            for (int k = 0; k < firstMartrix.GetLength(1); k++)
            {
                multiply += firstMartrix[i, k] * secomdMartrix[k, j];
            }
            multiplyMatrix[i, j] = multiply;
        }
    }
    return multiplyMatrix;
}

#endregion