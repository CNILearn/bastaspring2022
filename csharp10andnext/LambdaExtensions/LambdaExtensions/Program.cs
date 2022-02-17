// See https://aka.ms/new-console-template for more information
using System.Reflection;


Foo(new Action(() => Console.WriteLine("Hello")));
// Foo(() => Console.WriteLine("hello"));


void Foo(Delegate d)
{
    MethodInfo m = d.Method;
    d.DynamicInvoke();
}