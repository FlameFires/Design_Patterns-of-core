using System;
using System.Collections.Generic;

namespace InterceptingFilter_Pattern
{
    /// <summary>
    /// 过滤拦截器模式
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // 用于对应用程序的请求或响应做一些预处理/后处理。定义过滤器，并在把请求传给实际目标应用程序之前应用在请求上。过滤器可以做认证/授权/记录日志，或者跟踪请求，然后把请求传给相应的处理程序。以下是这种设计模式的实体

            FilterManager filterManager = new FilterManager(new Target());
            filterManager.AddFilter(new AuthenticationFilter());
            filterManager.AddFilter(new DebugFilter());

            Client client = new Client();
            client.setFilterManager(filterManager);
            client.sendRequest("hello，I'm a programer");

            Console.ReadLine();
        }
    }

    /// <summary>
    /// 客户端
    /// </summary>
    public class Client
    {
        FilterManager filterManager;

        public void setFilterManager(FilterManager filterManager)
        {
            this.filterManager = filterManager;
        }
        /// <summary>
        /// 发送一个请求
        /// </summary>
        /// <param name="request"></param>
        public void sendRequest(String request)
        {
            filterManager.filterRequest(request);
        }
    }
    /// <summary>
    /// 过滤器接口
    /// </summary>
    public interface Filter
    {
        public void execute(String request);
    }
    public class AuthenticationFilter : Filter
    {
        public void execute(String request)
        {
            Console.WriteLine("Authenticating request: " + request);
        }
    }
    public class DebugFilter : Filter
    {
        public void execute(String request)
        {
            Console.WriteLine("request log: " + request);
        }
    }
    /// <summary>
    /// 过滤完毕请求执行者
    /// </summary>
    public class Target
    {
        public void execute(String request)
        {
            Console.WriteLine("Executing request: " + request);
        }
    }
    /// <summary>
    /// 过滤器链
    /// </summary>
    public class FilterChain
    {
        private List<Filter> filters = new List<Filter>();
        private Target target;

        public void addFilter(Filter filter)
        {
            filters.Add(filter);
        }

        public void execute(String request)
        {
            foreach (Filter filter in filters)
            {
                filter.execute(request);
            }
            target.execute(request);
        }

        public void setTarget(Target target)
        {
            this.target = target;
        }
    }
    /// <summary>
    /// 过滤器管理者
    /// </summary>
    public class FilterManager
    {
        FilterChain filterChain;

        public FilterManager(Target target)
        {
            filterChain = new FilterChain();
            filterChain.setTarget(target);
        }
        public void AddFilter(Filter filter)
        {
            filterChain.addFilter(filter);
        }

        public void filterRequest(String request)
        {
            filterChain.execute(request);
        }
    }
}
