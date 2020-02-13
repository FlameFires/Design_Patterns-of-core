using System;

namespace Singleton_Pattern
{
    /// <summary>
    /// 单例模式,关于单例，有很多种创建的解决办法，目前只介绍最简单的一种
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {

            var obj = SingletonDemo.GetInstance();
            obj.Print();

            Console.ReadKey();
        }
    }

    public class SingletonDemo
    {
        private SingletonDemo()
        {
            // 私有化构造函数
        }
        /// <summary>
        /// 单例，避免不了反射，线程问题
        /// </summary>
        /// <returns></returns>
        public static SingletonDemo GetInstance()
        {
            return new SingletonDemo();
        }

        public void Print()
        {
            Console.WriteLine(this.GetType().Name+" success print!");
        }
    }
}
