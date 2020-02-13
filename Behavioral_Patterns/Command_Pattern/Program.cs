using System;
using System.Collections.Generic;

namespace Command_Pattern
{
    /// <summary>
    /// 命令模式
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //何时使用：在某些场合，比如要对行为进行"记录、撤销/重做、事务"等处理，这种无法抵御变化的紧耦合是不合适的。在这种情况下，如何将"行为请求者"与"行为实现者"解耦？将一组行为抽象为对象，可以实现二者之间的松耦合。

            Stock abcStock = new Stock();

            BuyStock buyStockOrder = new BuyStock(abcStock);
            SellStock sellStockOrder = new SellStock(abcStock);

            Broker broker = new Broker();
            broker.takeOrder(buyStockOrder);
            broker.takeOrder(sellStockOrder);

            broker.placeOrders();

            Console.ReadKey();
        }
    }
    public interface IOrder
    {
        void execute();
    }
    public class Stock
    {
        private String name = "ABC";
        private int quantity = 10;

        public void buy()
        {
            Console.WriteLine("Stock [ Name: " + name + ", Quantity: " + quantity + " ] bought");
        }
        public void sell()
        {
            Console.WriteLine("Stock [ Name: " + name + ", Quantity: " + quantity + " ] sold");
        }
    }
    public class BuyStock : IOrder
    {
        private Stock abcStock;

        public BuyStock(Stock abcStock)
        {
            this.abcStock = abcStock;
        }

        public void execute()
        {
            abcStock.buy();
        }
    }
    public class SellStock : IOrder
    {
        private Stock abcStock;

        public SellStock(Stock abcStock)
        {
            this.abcStock = abcStock;
        }

        public void execute()
        {
            abcStock.sell();
        }
    }
    public class Broker
    {
        private List<IOrder> orderList = new List<IOrder>();

        public void takeOrder(IOrder order)
        {
            orderList.Add(order);
        }

        public void placeOrders()
        {
            foreach (IOrder order in orderList)
            {
                order.execute();
            }
            orderList.Clear();
        }
    }
}
