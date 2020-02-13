using System;

namespace BusinessDelegate_Pattern
{
    /// <summary>
    /// 业务代表模式
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            BusinessDelegate business = new BusinessDelegate();
            business.setServiceType("EJB");
            Client client = new Client(business);
            client.doTask();
        }
    }
    /// <summary>
    /// 客服端
    /// </summary>
    public class Client
    {
        BusinessDelegate businessService;

        public Client(BusinessDelegate businessService)
        {
            this.businessService = businessService;
        }

        public void doTask()
        {
            businessService.doTask();
        }
    }
    /// <summary>
    /// 单独业务
    /// </summary>
    public class BusinessDelegate
    {
        private BusinessLookUp lookupService = new BusinessLookUp();
        private IBusinessService businessService;
        private String serviceType;

        public void setServiceType(String serviceType)
        {
            this.serviceType = serviceType;
        }

        public void doTask()
        {
            businessService = lookupService.getBusinessService(serviceType);
            businessService.doProcessing();
        }
    }
    /// <summary>
    /// 业务查找
    /// </summary>
    public class BusinessLookUp
    {
        public IBusinessService getBusinessService(String serviceType)
        {
            if (serviceType.Equals("EJB", StringComparison.OrdinalIgnoreCase))
            {
                return new EJBService();
            }
            else
            {
                return new JMSService();
            }
        }
    }
    public interface IBusinessService
    {
        public void doProcessing();
    }
    public class JMSService : IBusinessService
    {
        public void doProcessing()
        {
            Console.WriteLine("Processing task by invoking JMS Service");
        }
    }
    public class EJBService : IBusinessService
    {
        public void doProcessing()
        {
            Console.WriteLine("Processing task by invoking EJB Service");
        }
    }
}
