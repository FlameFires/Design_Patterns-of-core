using System;
using System.Collections.Generic;

namespace Observer_Pattern
{
    /// <summary>
    /// 观察者模式
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //何时使用：一个对象（目标对象）的状态发生改变，所有的依赖对象（观察者对象）都将得到通知，进行广播通知。

            Subject subject = new Subject();

            PlayObserver palyer = new PlayObserver(subject);
            StudyObserver studier = new StudyObserver(subject);

            Console.WriteLine("第一次改变");
            subject.setState(10);

            Console.WriteLine("第二次改变");
            subject.setState(20);


            Console.ReadKey();
        }
    }

    /// <summary>
    /// 状态监听者
    /// </summary>
    public class Subject
    {

        private List<Observer> observers
           = new List<Observer>();
        private int state;

        public int getState()
        {
            return state;
        }

        public void setState(int state)
        {
            this.state = state;
            notifyAllObservers();
        }

        public void attach(Observer observer)
        {
            observers.Add(observer);
        }

        public void notifyAllObservers()
        {
            foreach (Observer observer in observers)
            {
                observer.update();
            }
        }
    }

    /// <summary>
    /// 观察者
    /// </summary>
    public abstract class Observer
    {
        protected Subject subject;
        public abstract void update();
    }
    public class StudyObserver : Observer
    {
        public StudyObserver(Subject subject)
        {
            this.subject = subject;
            this.subject.attach(this);
        }
        public override void update()
        {
            Console.WriteLine(this.GetType().Name+" update!");
        }
    }
    public class PlayObserver : Observer
    {
        public PlayObserver(Subject subject)
        {
            this.subject = subject;
            this.subject.attach(this);
        }
        public override void update()
        {
            Console.WriteLine(this.GetType().Name + " update!");
        }
    }
}
