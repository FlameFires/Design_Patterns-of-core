using System;

namespace Strategy_Pattern
{
    /// <summary>
    /// 策略模式
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // 何时使用：一个系统有许多许多类，而区分它们的只是他们直接的行为。

            Context context = new Context(new OperationAdd());
            Console.WriteLine("10 + 5 = " + context.executeStrategy(10, 5));

            context = new Context(new OperationSubstract());
            Console.WriteLine("10 - 5 = " + context.executeStrategy(10, 5));

            context = new Context(new OperationMultiply());
            Console.WriteLine("10 * 5 = " + context.executeStrategy(10, 5));

            Console.ReadKey();
        }
    }
    /// <summary>
    /// 上下文执行
    /// </summary>
    public class Context
    {
        private IStrategy strategy;

        public Context(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        public int executeStrategy(int num1, int num2)
        {
            return strategy.doOperation(num1, num2);
        }
    }
    public interface IStrategy
    {
        public int doOperation(int num1, int num2);
    }
    public class OperationAdd : IStrategy
    {
        public int doOperation(int num1, int num2)
        {
            return num1 + num2;
        }
    }
    public class OperationSubstract : IStrategy
    {
        public int doOperation(int num1, int num2)
        {
            return num1 - num2;
        }
    }
    public class OperationMultiply : IStrategy
    {
        public int doOperation(int num1, int num2)
        {
            return num1 * num2;
        }
    }

}
