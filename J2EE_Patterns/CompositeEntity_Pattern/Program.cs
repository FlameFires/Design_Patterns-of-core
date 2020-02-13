using System;

namespace CompositeEntity_Pattern
{
    /// <summary>
    /// 组合实体模式
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // 组合实体模式（Composite Entity Pattern）用在 EJB 持久化机制中。一个组合实体是一个 EJB 实体 bean，代表了对象的图解。当更新一个组合实体时，内部依赖对象 beans 会自动更新，因为它们是由 EJB 实体 bean 管理的。以下是组合实体 bean 的参与者。

            Client client = new Client();
            client.setData("Test", "Data");
            client.printData();
            client.setData("Second Test", "Data1");
            client.printData();
        }
    }
    /// <summary>
    /// 组合实体的客户端
    /// </summary>
    public class Client
    {
        private CompositeEntity compositeEntity = new CompositeEntity();

        public void printData()
        {
            for (int i = 0; i < compositeEntity.getData().Length; i++)
            {
                Console.WriteLine("Data: " + compositeEntity.getData()[i]);
            }
        }

        public void setData(String data1, String data2)
        {
            compositeEntity.setData(data1, data2);
        }
    }
    public class DependentObject1
    {

        private String data;

        public void setData(String data)
        {
            this.data = data;
        }

        public String getData()
        {
            return data;
        }
    }
    public class DependentObject2
    {

        private String data;

        public void setData(String data)
        {
            this.data = data;
        }

        public String getData()
        {
            return data;
        }
    }
    /// <summary>
    /// 粗粒度对象
    /// </summary>
    public class CoarseGrainedObject
    {
        DependentObject1 do1 = new DependentObject1();
        DependentObject2 do2 = new DependentObject2();

        public void setData(String data1, String data2)
        {
            do1.setData(data1);
            do2.setData(data2);
        }

        public String[] getData()
        {
            return new String[] { do1.getData(), do2.getData() };
        }
    }
    /// <summary>
    /// 组合实体
    /// </summary>
    public class CompositeEntity
    {
        private CoarseGrainedObject cgo = new CoarseGrainedObject();

        public void setData(String data1, String data2)
        {
            cgo.setData(data1, data2);
        }

        public String[] getData()
        {
            return cgo.getData();
        }
    }
}
