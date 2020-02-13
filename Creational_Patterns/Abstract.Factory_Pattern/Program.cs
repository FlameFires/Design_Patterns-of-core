using System;

namespace Abstract.Factory_Pattern
{
    /// <summary>
    /// 抽象工厂模式，工厂模式的抽象化，扩大化
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var mouse = EquipmentFactory.GetKeyboard("Logitech");
            var keyboard = EquipmentFactory.GetMouse("Microsoft");

            mouse.Output();
            keyboard.Output();

            Console.ReadLine();
        }
    }
    /// <summary>
    /// 此思想的重要体现
    /// </summary>
    public class EquipmentFactory
    {

        public static Mouse GetMouse(string brand)
        {
            return MouseFactory.GetMouse(brand);
        }
        public static Keyboard GetKeyboard(string brand)
        {
            return KeyboardFactory.GetKeyboard(brand);
        }
    }

    #region 鼠标
    /// <summary>
    /// 鼠标生产工厂
    /// </summary>
    public class MouseFactory
    {
        public static Mouse GetMouse(string brand)
        {
            if (brand.Equals("Logitech"))
            {
                return new LogitechMouse();
            }
            else return new MicrosoftMouse();
        }

    }
    public abstract class Mouse
    {
        //鼠标品牌排行 https://www.chinapp.com/shidapinpai/73018
        public abstract void Output();
    }
    /// <summary>
    /// 罗技鼠标
    /// </summary>
    public class LogitechMouse : Mouse
    {
        public override void Output()
        {
            Console.WriteLine(this.GetType().Name + " print!");
        }
    }
    /// <summary>
    /// 微软鼠标
    /// </summary>
    public class MicrosoftMouse : Mouse
    {
        public override void Output()
        {
            Console.WriteLine(this.GetType().Name + " print!");
        }
    }
    #endregion

    #region 键盘
    /// <summary>
    /// 键盘工厂
    /// </summary>
    public class KeyboardFactory
    {
        public static Keyboard GetKeyboard(string brand)
        {
            if (brand.Equals("Logitech"))
            {
                return new LogitechKeyboard();
            }
            else return new RazerKeyboard();
        }

    }
    public abstract class Keyboard
    {
        // https://www.chinapp.com/paihang/jianpan
        public abstract void Output();
    }

    public class LogitechKeyboard : Keyboard
    {
        public override void Output()
        {
            Console.WriteLine(this.GetType().Name + " print!");
        }
    }
    public class RazerKeyboard : Keyboard
    {
        public override void Output()
        {
            Console.WriteLine(this.GetType().Name + " print!");
        }
    }
    #endregion
}
