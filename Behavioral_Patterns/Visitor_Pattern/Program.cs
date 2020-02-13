using System;

namespace Visitor_Pattern
{
    /// <summary>
    /// 访问者模式
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //何时使用：需要对一个对象结构中的对象进行很多不同的并且不相关的操作，而需要避免让这些操作"污染"这些对象的类，使用访问者模式将这些封装到类中

            IComputerPart computer = new Computer();
            ComputerPartDisplayVisitor visitor = new ComputerPartDisplayVisitor();
            computer.accept(visitor);

            Console.Read();
        }
    }

    /// <summary>
    /// 访问对象的暴露的接口
    /// </summary>
    public interface IComputerPart
    {
        void accept(IComputerPartVisitor computerPartVisitor);
    }
    public class Keyboard : IComputerPart
    {
        public void accept(IComputerPartVisitor computerPartVisitor)
        {
            computerPartVisitor.visit(this);
        }
    }
    public class Monitor : IComputerPart
    {
        public void accept(IComputerPartVisitor computerPartVisitor)
        {
            computerPartVisitor.visit(this);
        }
    }
    public class Mouse : IComputerPart
    {
        public void accept(IComputerPartVisitor computerPartVisitor)
        {
            computerPartVisitor.visit(this);
        }
    }
    public class Computer : IComputerPart
    {
        IComputerPart[] parts;
        public Computer()
        {
            parts = new IComputerPart[] { new Mouse(), new Keyboard(), new Monitor() };
        }
        public void accept(IComputerPartVisitor computerPartVisitor)
        {
            for (int i = 0; i < parts.Length; i++)
            {
                parts[i].accept(computerPartVisitor);
            }
            computerPartVisitor.visit(this);
        }
    }

    /// <summary>
    /// 访问者接口
    /// </summary>
    public interface IComputerPartVisitor
    {
        public void visit(Computer computer);
        public void visit(Mouse mouse);
        public void visit(Keyboard keyboard);
        public void visit(Monitor monitor);
    }

    /// <summary>
    /// 访问者
    /// </summary>
    public class ComputerPartDisplayVisitor : IComputerPartVisitor
    {
        public void visit(Computer computer)
        {
            Console.WriteLine("Displaying Computer.");
        }
        public void visit(Mouse mouse)
        {
            Console.WriteLine("Displaying Mouse.");
        }
        public void visit(Keyboard keyboard)
        {
            Console.WriteLine("Displaying Keyboard.");
        }
        public void visit(Monitor monitor)
        {
            Console.WriteLine("Displaying Monitor.");
        }
    }
}
