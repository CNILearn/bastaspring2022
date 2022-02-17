using System;

// C# 9
Func<int, bool> isEven = (int n) => n % 2 == 0;

// C# 10 - infer delegate type
// var isEven = (int n) => n % 2 == 0;

if (isEven(34))
{
    Console.WriteLine($"34 is even");
}


// C# 10
// Delegate d1 = bool (int n) => n % 2 == 0;

// C# 9

Delegate d1 = (Func<int, bool>)((int n) => n % 2 == 0);
