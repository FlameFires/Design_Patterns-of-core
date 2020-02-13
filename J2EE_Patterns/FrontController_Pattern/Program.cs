using System;

namespace FrontController_Pattern
{
    /// <summary>
    /// 前端控制器模式
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // 前端控制器模式（Front Controller Pattern）是用来提供一个集中的请求处理机制，所有的请求都将由一个单一的处理程序处理。该处理程序可以做认证/授权/记录日志，或者跟踪请求，然后把请求传给相应的处理程序。以下是这种设计模式的实体。

            FrontController frontController = new FrontController();
            frontController.dispatchRequest("HOME");
            frontController.dispatchRequest("STUDENT");

            Console.ReadKey();
        }
    }
    public class HomeView
    {
        public void show()
        {
            Console.WriteLine("Displaying Home Page");
        }
    }
    public class StudentView
    {
        public void show()
        {
            Console.WriteLine("Displaying Student Page");
        }
    }
    /// <summary>
    /// 调度器，类似工厂的功能
    /// </summary>
    public class Dispatcher
    {
        private StudentView studentView;
        private HomeView homeView;
        public Dispatcher()
        {
            studentView = new StudentView();
            homeView = new HomeView();
        }

        public void dispatch(String request)
        {
            if (request.Equals("STUDENT",StringComparison.OrdinalIgnoreCase))
            {
                studentView.show();
            }
            else
            {
                homeView.show();
            }
        }
    }
    /// <summary>
    /// 前端控制者
    /// </summary>
    public class FrontController
    {
        private Dispatcher dispatcher;
        public FrontController()
        {
            dispatcher = new Dispatcher();
        }
        /// <summary>
        /// 身份验证
        /// </summary>
        /// <returns></returns>
        private Boolean isAuthenticUser()
        {
            Console.WriteLine("User is authenticated successfully.");
            return true;
        }
        private void trackRequest(String request)
        {
            Console.WriteLine("Page requested: " + request);
        }

        public void dispatchRequest(String request)
        {
            //记录每一个请求
            trackRequest(request);
            //对用户进行身份验证
            if (isAuthenticUser())
            {
                dispatcher.dispatch(request);
            }
        }
    }
}
