using System;
using System.Collections.Generic;

namespace Memento_Pattern
{
    /// <summary>
    /// 备忘录模式
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //何时使用：很多时候我们总是需要记录一个对象的内部状态，这样做的目的就是为了允许用户取消不确定或者错误的操作，能够恢复到他原先的状态，使得他有"后悔药"可吃。

            Originator originator = new Originator();
            CareTaker careTaker = new CareTaker();
            originator.SetState("State #1");
            originator.SetState("State #2");
            careTaker.Add(originator.SaveStateToMemento());
            originator.SetState("State #3");
            careTaker.Add(originator.SaveStateToMemento());
            originator.SetState("State #4");

           Console.WriteLine("Current State: " + originator.GetState());
            originator.GetStateFromMemento(careTaker.Get(0));
           Console.WriteLine("First saved State: " + originator.GetState());
            originator.GetStateFromMemento(careTaker.Get(1));
           Console.WriteLine("Second saved State: " + originator.GetState());


            Console.ReadLine();
        }
    }

    // 存档
    public class Memento
    {
        private string state;
        public Memento(string state)
        {
            this.state = state;
        }
        public string GetState()
        {
            return state;
        }
    }
    // 发起者
    public class Originator
    {
        private string state;
        public void SetState(string state)
        {
            this.state = state;
        }
        public string GetState()
        {
            return state;
        }
        public Memento SaveStateToMemento()
        {
            return new Memento(state);
        }
        public void GetStateFromMemento(Memento memento)
        {
            state = memento.GetState();
        }
    }
    // 存档管理
    public class CareTaker
    {
        private List<Memento> mementoList = new List<Memento>();
        public void Add(Memento memento)
        {
            mementoList.Add(memento);
        }
        public Memento Get(int index)
        {
            return mementoList[index];
        }
    }
}
