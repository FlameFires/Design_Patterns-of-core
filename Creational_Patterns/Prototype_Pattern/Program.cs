using System;
using System.Collections.Generic;

namespace Prototype_Pattern
{
    /// <summary>
    /// 原型模式
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //何时使用： 1、当一个系统应该独立于它的产品创建，构成和表示时。 2、当要实例化的类是在运行时刻指定时，例如，通过动态装载。 3、为了避免创建一个与产品类层次平行的工厂类层次时。 4、当一个类的实例只能有几个不同状态组合中的一种时。建立相应数目的原型并克隆它们可能比每次用合适的状态手工实例化该类更方便一些。

            // 动态装载使用
            Shape circle = ShapeCache.GetShape("1") as Circle;
            Shape r_circle = ShapeCache.GetRealShape("1") as Circle;
            Console.WriteLine("clone circle is equal real circle : "+circle.Equals(r_circle));

            circle.Print();

            Console.ReadLine();
        }
    }

    public class ShapeCache
    {
        private static IDictionary<string, Shape> _shapeList = new Dictionary<string, Shape>();

        public static Object GetShape(string id)
        {
            var temp = _shapeList[id];
            // 动态复制实例
            return temp.Clone();
        }

        public static Shape GetRealShape(string id)
        {
            return _shapeList[id];
        }

        static ShapeCache()
        {
            // 提前实例装载进字典存储器
            _shapeList.Add("1",new Circle());
        }
    }

    public abstract class Shape : ICloneable
    {
        protected Type type { get; set; }

        public void Print()
        {
            var ass = type.Name;
            Console.WriteLine("class name is " + ass);
        }

        public object Clone()
        {
            Object obj = null;
            try
            {
                obj = this.MemberwiseClone(); // 深拷贝
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return obj;
        }
    }

    public class Circle : Shape
    {
        public Circle()
        {
            type = this.GetType();
        }
    }
}
