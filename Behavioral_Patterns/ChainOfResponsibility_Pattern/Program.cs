using System;

namespace ChainOfResponsibility_Pattern
{
    /// <summary>
    /// 责任链模式
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //何时使用：在处理消息的时候以过滤很多道。

            AbstractLogger consoleLogger = new ConsoleLogger();

            consoleLogger.logMessage(AbstractLogger.INFO,"hello ");
            Console.WriteLine();
            consoleLogger.logMessage(AbstractLogger.DEBUG, "this is a test");
            Console.WriteLine();
            consoleLogger.logMessage(AbstractLogger.ERROR, "fatal error");
            Console.WriteLine();

            Console.ReadKey();
        }
    }

    /// <summary>
    /// 若不是此等级则会传递个下一个等级处理，直到全部处理完
    /// </summary>
    public abstract class AbstractLogger
    {
        public static int INFO = 1;
        public static int DEBUG = 2;
        public static int ERROR = 3;

        protected int level;

        //责任链中的下一个元素
        protected AbstractLogger nextLogger;

        public void setNextLogger(AbstractLogger nextLogger)
        {
            this.nextLogger = nextLogger;
        }

        public void logMessage(int level, String message)
        {
            if (this.level <= level)
            {
                Write(message);
            }
            if (nextLogger != null)
            {
                nextLogger.logMessage(level, message);
            }
        }

        protected abstract void Write(String message);

    }
    /// <summary>
    /// 控制台日志
    /// </summary>
    public class ConsoleLogger : AbstractLogger
    {
        public ConsoleLogger()
        {
            this.level = AbstractLogger.INFO;
            setNextLogger(new FileLogger());
        }
        protected override void Write(String message)
        {
            Console.WriteLine("Standard Console::Logger: " + message);
        }
    }
    public class ErrorLogger : AbstractLogger
    {
        public ErrorLogger()
        {
            this.level = AbstractLogger.ERROR;
            setNextLogger(null);
        }
        protected override void Write(String message)
        {
            Console.WriteLine("Error Console::Logger: " + message);
        }
    }
    public class FileLogger : AbstractLogger
    {
        public FileLogger()
        {
            this.level = AbstractLogger.DEBUG;
            setNextLogger(new ErrorLogger());
        }
        protected override void Write(String message)
        {
            Console.WriteLine("File::Logger: " + message);
        }
    }
}
