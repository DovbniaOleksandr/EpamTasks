using System;

namespace ExceptionTasks
{
    public static class MethodsWithExceptions
    {
        public static void RecursiveMethod(int n)
        {
            throw new StackOverflowException();
        }

        public static int OutOfRangeMethod(int[] arr)
        {
            return arr[arr.Length + 1];
        }

        public static void DoSomeMath(int a, int b)
        {
            if (a < 0)
                throw new ArgumentException("Parameter should be greater than 0", nameof(a));
            if (b > 0)
                throw new ArgumentException("Parameter should be less than 0", nameof(b));
        }
    }
}