using System;

namespace Proxy_Pattern
{
    /// <summary>
    /// 代理模式
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //何时使用：想在访问一个类时做一些控制。

            IImage image = new ProxyImage("test_10mb.jpg");

            // 图像将从磁盘加载
            image.Display();
            
            // 图像不需要从磁盘加载
            image.Display();

            Console.ReadKey();
        }
    }

    public interface IImage
    {
        void Display();
    }
    public class RealImage : IImage
    {
        private String fileName;

        public RealImage(String fileName)
        {
            this.fileName = fileName;
            loadFromDisk(fileName);
        }
        private void loadFromDisk(String fileName)
        {
            Console.WriteLine("Loading " + fileName);
        }
        public void Display()
        {
            Console.WriteLine("Displaying " + fileName);
        }
    }
    public class ProxyImage : IImage
    {
        private RealImage realImage;
        private String fileName;

        public ProxyImage(String fileName)
        {
            this.fileName = fileName;
        }
        public void Display()
        {
            if (realImage == null)
            {
                realImage = new RealImage(fileName);
            }
            realImage.Display();
        }
    }
}
