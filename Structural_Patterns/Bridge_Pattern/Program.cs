using System;

namespace Bridge_Pattern
{
    /// <summary>
    /// 桥接模式
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //优点： 1、抽象和实现的分离。 2、优秀的扩展能力。 3、实现细节对客户透明。
            var girl = new Gril(150,"嘟嘟脸",new LovelyGirl());
            girl.Draw();

            var girl2 = new Gril(168,"瓜子脸",new ErotogenicGirl());
            girl2.Draw();

            Console.ReadKey();
        }
    }
    public class Gril : Person
    {
        public Gril(int height,string face, IDrawType drawType)
        {
            Height = height;
            Face = face;
            DrawType = drawType;
        }

        public override void Draw()
        {
            DrawType?.Draw(Height,Face);
        }
    }

    public abstract class Person
    {
        protected IDrawType DrawType;
        public int Height { get; protected set; }
        public string Face { get; protected set; }
        public abstract void Draw();
    }

    public interface IDrawType
    {
        
        void Draw(int height, string face);
    }
    public class LovelyGirl : IDrawType
    {
        public void Draw(int height, string face)
        {
            Console.WriteLine(string.Format("画了一个可爱型女孩\r\n  身高：{0}\r\n  脸型：{1}", height, face));
        }
    }
    public class ErotogenicGirl : IDrawType
    {
        public void Draw(int height, string face)
        {
            Console.WriteLine(string.Format("画了一个性感型女孩\r\n  身高：{0}\r\n  脸型：{1}", height, face));
        }
    }
}
