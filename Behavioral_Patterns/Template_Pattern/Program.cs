using System;

namespace Template_Pattern
{
    /// <summary>
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // 何时使用：有一些通用的方法。
            // 主要解决：一些方法通用，却在每一个子类都重新写了这一方法。
            // 应用实例： 1、在造房子的时候，地基、走线、水管都一样，只有在建筑的后期才有加壁橱加栅栏等差异。 2、西游记里面菩萨定好的 81 难，这就是一个顶层的逻辑骨架。 3、spring 中对 Hibernate 的支持，将一些已经定好的方法封装起来，比如开启事务、获取 Session、关闭 Session 等，程序员不重复写那些已经规范好的代码，直接丢一个实体就可以保存。

            Game game = new Cricket();
            game.play();
            Console.WriteLine();
            game = new Football();
            game.play();

            Console.ReadLine();
        }
    }

    public abstract class Game
    {
        public abstract void initialize();
        public abstract void startPlay();
        public abstract void endPlay();

        //模板
        public void play()
        {

            //初始化游戏
            initialize();

            //开始游戏
            startPlay();

            //结束游戏
            endPlay();
        }
    }

    public class Cricket : Game
    {
        public override void endPlay()
        {
            Console.WriteLine("Cricket Game Finished!");
        }
        public override void initialize()
        {
            Console.WriteLine("Cricket Game Initialized! Start playing.");
        }
        public override void startPlay()
        {
            Console.WriteLine("Cricket Game Started. Enjoy the game!");
        }
    }

    public class Football : Game
    {
        public override void endPlay()
        {
            Console.WriteLine("Football Game Finished!");
        }
        public override void initialize()
        {
            Console.WriteLine("Football Game Initialized! Start playing.");
        }
        public override void startPlay()
        {
            Console.WriteLine("Football Game Started. Enjoy the game!");
        }
    }
}
