using System;

namespace NullObject_Pattern
{
    /// <summary>
    /// 空对象模式
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // 在空对象模式（Null Object Pattern）中，一个空对象取代 NULL 对象实例的检查。Null 对象不是检查空值，而是反应一个不做任何动作的关系。这样的 Null 对象也可以在数据不可用的时候提供默认的行为。

            AbstractCustomer customer1 = CustomerFactory.getCustomer("Rob");
            AbstractCustomer customer2 = CustomerFactory.getCustomer("Bob");
            AbstractCustomer customer3 = CustomerFactory.getCustomer("Julie");
            AbstractCustomer customer4 = CustomerFactory.getCustomer("Laura");

            
            Console.WriteLine(customer1.getName());
            Console.WriteLine(customer2.getName());
            Console.WriteLine(customer3.getName());
            Console.WriteLine(customer4.getName());


            Console.ReadKey();
        }
    }
    public abstract class AbstractCustomer
    {
        protected String name;
        public abstract Boolean isNil();
        public abstract String getName();
    }
    public class RealCustomer : AbstractCustomer
    {
        public RealCustomer(string name)
        {
            this.name = name;
        }

        public override string getName()
        {
            return name;
        }

        public override bool isNil()
        {
            return false;
        }
    }
    public class NullCustomer : AbstractCustomer
    {

        public override string getName()
        {
            return name;
        }

        public override bool isNil()
        {
            return true;
        }
    }
    public class CustomerFactory
    {
        public static string[] names = new string[] { "Rob", "Joe", "Julie" };
        public static AbstractCustomer getCustomer(String name)
        {
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i].Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    return new RealCustomer(name);
                }
            }
            return new NullCustomer();
        }
    }
}
