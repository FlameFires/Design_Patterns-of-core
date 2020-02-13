using System;

namespace Decorator_Pattern
{
    /// <summary>
    /// 装饰器模式
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //何时使用：在不想增加很多子类的情况下扩展类。
            RedShapeDecorator decorator = new RedShapeDecorator(new Rectangle());
            decorator.Draw();

            Console.ReadLine();
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
    public class Circle : IShape
    {
        public void Draw()
        {
            Console.WriteLine(this.GetType().Name + " drawed!");
        }
    }
    /// <summary>
    /// 抽象图形装饰器
    /// </summary>
    public abstract class ShapeDecorator : IShape
    {
        protected IShape shape;
        protected ShapeDecorator(IShape shape)
        {
            this.shape = shape;
        }

        public virtual void Draw()
        {
            shape?.Draw();
        }
    }
    /// <summary>
    /// 实现的装饰器
    /// </summary>
    public class RedShapeDecorator : ShapeDecorator
    {
        public RedShapeDecorator(IShape shape) : base(shape)
        {
        }

        public override void Draw()
        {
            base.Draw();
            setRedBorder(shape);
        }

        /// <summary>
        /// 在已有的实例对象上继续添加功能
        /// </summary>
        /// <param name="decoratedShape"></param>
        private void setRedBorder(IShape decoratedShape)
        {
            Console.WriteLine("Border Color: Red");
        }
    }
}
