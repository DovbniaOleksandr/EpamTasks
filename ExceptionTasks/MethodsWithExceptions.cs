using System;

namespace ExceptionTasks
{
    public static class MethodsWithExceptions
    {
        public static int RecursiveMethod(int n) => n == 0 ? throw new StackOverflowException() : RecursiveMethod(n - 1);
        public static int OutOfRangeMethod(int[] arr) => arr[arr.Length + 1];

        public static void DoSomeMath(int a, int b)
        {
            if (a < 0)
                throw new ArgumentException("Parameter should be greater than 0", nameof(a));
            else if (b > 0)
                throw new ArgumentException("Parameter should be less than 0", nameof(b));
        }
    }
}
