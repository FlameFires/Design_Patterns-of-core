using System;

namespace Mediator_Pattern
{
    /// <summary>
    /// 中介者模式
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // 何时使用：多个类相互耦合，形成了网状结构。
            // 应用实例： 1、中国加入 WTO 之前是各个国家相互贸易，结构复杂，现在是各个国家通过 WTO 来互相贸易。 2、机场调度系统。 3、MVC 框架，其中C（控制器）就是 M（模型）和 V（视图）的中介者。
            User robert = new User("Robert");
            User john = new User("John");

            robert.sendMessage("Hi! John!");
            john.sendMessage("Hello! Robert!");

            Console.WriteLine("Hello World!");
        }
    }
    public class User
    {
        private String name;

        public String getName()
        {
            return name;
        }

        public void setName(String name)
        {
            this.name = name;
        }

        public User(String name)
        {
            this.name = name;
        }

        public void sendMessage(String message)
        {
            ChatRoom.showMessage(this, message);
        }
    }
    public class ChatRoom
    {
        public static void showMessage(User user, String message)
        {
            Console.WriteLine(DateTime.Now.ToString() + " [" + user.getName() + "] : " + message);
        }
    }
}
