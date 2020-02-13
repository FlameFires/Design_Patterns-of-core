using System;

namespace Facade_Pattern
{
    /// <summary>
    /// 外观模式
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //何时使用： 1、客户端不需要知道系统内部的复杂联系，整个系统只需提供一个"接待员"即可。 2、定义系统的入口。

            ShapeMaker shapeMaker = new ShapeMaker();

            shapeMaker.DrawRectangle();
            shapeMaker.DrawSquare();

            Console.ReadKey();
        }
    }

    public interface IShape
    {
        void Draw();
    }
    public class Rectangle : IShape
    {
        public void Draw()
        {
            Console.WriteLine(this.GetType().Name + " drawed!");
        }
    }
    public class Square : IShape
    {
        public void Draw()
        {
            Console.WriteLine(this.GetType().Name + " drawed!");
        }
    }
    public class ShapeMaker
    {
        private Rectangle _rectangle;
        private Square _square;
        public ShapeMaker()
        {
            _rectangle = new Rectangle();
            _square = new Square();
        }
        public void DrawRectangle()
        {
            _rectangle?.Draw();
        }
        public void DrawSquare()
        {
            _square?.Draw();
        }
    }
}
