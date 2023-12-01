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