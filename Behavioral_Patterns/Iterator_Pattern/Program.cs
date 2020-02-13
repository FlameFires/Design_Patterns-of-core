using System;

namespace Iterator_Pattern
{
    /// <summary>
    /// 迭代器模式
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //何时使用：遍历一个聚合对象。

            NameRepository repository = new NameRepository();
            for (IIterator iter = repository.getIterator(); iter.hasNext();)
            {
                String name = (String)iter.next();
                Console.WriteLine("Name : " + name);
            }

            Console.ReadKey();
        }
    }

    public interface IIterator
    {
        public Boolean hasNext();
        public Object next();
    }
    public interface Container
    {
        public IIterator getIterator();
    }
    public class NameRepository : Container
    {
        public static String[] names = new string[] { "Robert", "John", "Julie", "Lora" };
        public IIterator getIterator()
        {
            return new NameIterator();
        }

        private class NameIterator : IIterator
        {
            int index;
            public Boolean hasNext()
            {
                if (index < names.Length)
                {
                    return true;
                }
                return false;
            }
            public Object next()
            {
                if (this.hasNext())
                {
                    return names[index++];
                }
                return null;
            }
        }
    }
}
