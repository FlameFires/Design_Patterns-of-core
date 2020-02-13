using System;
using System.Collections.Generic;

namespace ServiceLocator_Pattern
{
    /// <summary>
    /// 服务定位器模式
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // 在我们想使用 JNDI 查询定位各种服务的时候。考虑到为某个服务查找 JNDI 的代价很高，服务定位器模式充分利用了缓存技术。在首次请求某个服务时，服务定位器在 JNDI 中查找服务，并缓存该服务对象。当再次请求相同的服务时，服务定位器会在它的缓存中查找，这样可以在很大程度上提高应用程序的性能。以下是这种设计模式的实体。

            IService service = ServiceLocator.getService("Service1");
            service.execute();
            service = ServiceLocator.getService("Service2");
            service.execute();
            service = ServiceLocator.getService("Service1");
            service.execute();
            service = ServiceLocator.getService("Service2");
            service.execute();

            Console.ReadLine();
        }
    }
    /// <summary>
    /// 服务定位者
    /// </summary>
    public class ServiceLocator
    {
        private static Cache cache;
        static ServiceLocator()
        {
            cache = new Cache();
        }

        public static IService getService(String jndiName)
        {
            IService service = cache.getService(jndiName);

            if (service != null)
            {
                return service;
            }

            InitialContext context = new InitialContext();
            IService service1 = (IService)context.lookup(jndiName);
            cache.addService(service1);
            return service1;
        }
    }
    /// <summary>
    /// 服务接口
    /// </summary>
    public interface IService
    {
        public String getName();
        public void execute();
    }
    public class Service1 : IService
    {
        public void execute()
        {
            Console.WriteLine("Executing Service1");
        }
        public String getName()
        {
            return "Service1";
        }
    }
    public class Service2 : IService
    {
        public void execute()
        {
            Console.WriteLine("Executing Service2");
        }
        public String getName()
        {
            return "Service2";
        }
    }
    /// <summary>
    /// 初始化上下文，类似工厂功能
    /// </summary>
    public class InitialContext
    {
        /// <summary>
        /// 查找服务
        /// </summary>
        /// <param name="jndiName"></param>
        /// <returns></returns>
        public Object lookup(String jndiName)
        {
            if (jndiName.Equals("SERVICE1", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Looking up and creating a new Service1 object");
                return new Service1();
            }
            else if (jndiName.Equals("SERVICE2", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Looking up and creating a new Service2 object");
                return new Service2();
            }
            return null;
        }
    }
    /// <summary>
    /// 缓存类，实际开发中可以使用自带的 System.Web.Caching 省去造轮子的时间
    /// </summary>
    public class Cache
    {
        private List<IService> services;
        public Cache()
        {
            services = new List<IService>();
        }
        public IService getService(String serviceName)
        {
            foreach (IService service in services)
            {
                if (service.getName().Equals(serviceName))
                {
                    Console.WriteLine("Returning cached  " + serviceName + " object");
                    return service;
                }
            }
            return null;
        }

        public void addService(IService newService)
        {
            Boolean exists = false;
            foreach (IService service in services)
            {
                if (service.getName().Equals(newService.getName()))
                {
                    exists = true;
                }
            }
            if (!exists)
            {
                services.Add(newService);
            }
        }
    }
}
