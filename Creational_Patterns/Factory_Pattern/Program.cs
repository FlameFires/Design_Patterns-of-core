using System;

namespace Factory_Pattern
{
    /// <summary>
    /// 工厂模式
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var obj = EquipmentFactory.GetObj("Mouse");
            if (obj != null)
            {
                obj.Output();
            }

            Console.ReadKey();
        }
    }

    /// <summary>
    /// 此思想的重要体现
    /// </summary>
    public class EquipmentFactory
    {

        public static IEquipment GetObj(string name)
        {
            if (name.Equals("Keyboard"))
            {
                return new Keyboard();
            }
            else
            {
                return new Mouse();
            }
        }
    }

    /// <summary>
    /// 要不要无所谓
    /// </summary>
    public interface IEquipment
    {
        public void Output();
    }

    public class Keyboard : IEquipment
    {
        public void Output()
        {
            Console.WriteLine("keyboard print!");
        }
    }

    public class Mouse : IEquipment
    {
        public void Output()
        {
            Console.WriteLine("mouse print!");
        }
    }
}
