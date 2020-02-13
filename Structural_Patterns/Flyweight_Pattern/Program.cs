using System;
using System.Collections.Generic;

namespace Flyweight_Pattern
{
    /// <summary>
    /// 享元模式
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //何时使用： 1、系统中有大量对象。 2、这些对象消耗大量内存。 3、这些对象的状态大部分可以外部化。 4、这些对象可以按照内蕴状态分为很多组，当把外蕴对象从对象中剔除出来时，每一组对象都可以用一个对象来代替。 5、系统不依赖于这些对象身份，这些对象是不可分辨的

            
            for (int i = 0; i < 20; ++i)
            {
                Circle circle =
                   (Circle)ShapeFactory.getCircle(getRandomColor());
                circle.setX(getRandomX());
                circle.setY(getRandomY());
                circle.setRadius(100);
                circle.draw();
            }

            Console.ReadLine();
        }
        private static string[] colors = new string[] { "Red", "Green", "Blue", "White", "Black" };
        private static Random rd = new Random();
        private static String getRandomColor()
        {
            return colors[rd.Next(colors.Length)];
        }
        private static int getRandomX()
        {
            var s = rd.Next();
            return (int)(rd.Next());
        }
        private static int getRandomY()
        {
            return (int)(rd.Next());
        }
    }
    public class ShapeFactory
    {
        private static Dictionary<String, IShape> circleMap = new Dictionary<string, IShape>();

        public static IShape getCircle(String color)
        {
            IShape circle = null;
            if (!circleMap.TryGetValue(color, out circle))
            {
                circle = new Circle(color);
                circleMap.Add(color, circle);
                Console.WriteLine("Creating circle of color : " + color);
            } else
                circle = circleMap[color];
            return circle;
        }
    }
    public class Circle : IShape
    {
        private String color;
        private int x;
        private int y;
        private int radius;

        public Circle(String color)
        {
            this.color = color;
        }

        public void setX(int x)
        {
            this.x = x;
        }

        public void setY(int y)
        {
            this.y = y;
        }

        public void setRadius(int radius)
        {
            this.radius = radius;
        }

        public void draw()
        {
            Console.WriteLine("Circle: Draw() [Color : " + color
               + ", x : " + x + ", y :" + y + ", radius :" + radius);
        }
    }
    public interface IShape
    {
        void draw();
    }
}
