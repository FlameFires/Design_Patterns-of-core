using System;

namespace State_Pattern
{
    /// <summary>
    /// 状态模式
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // 何时使用：代码中包含大量与对象状态有关的条件语句。

            // 简单说给状态拥有更细化的控制
            Context context = new Context();

            StartState startState = new StartState();
            startState.doAction(context);
            Console.WriteLine(startState);

            StopState stopState = new StopState();
            stopState.doAction(context);
            Console.WriteLine(startState);

            Console.ReadKey();
        }
    }

    /// <summary>
    /// 你的应用
    /// </summary>
    public class Context
    {
        private IState state;
        public Context()
        {
            state = null;
        }

        public void setState(IState state)
        {
            this.state = state;
        }

        public IState getState()
        {
            return state;
        }
    }
    public interface IState
    {
        public void doAction(Context context);
    }

    public class StartState : IState
    {
        public void doAction(Context context)
        {
            Console.WriteLine("Player is in start state");
            context.setState(this);
        }
        public override string ToString()
        {
            return "Start State";
        }
    }
    public class StopState : IState
    {
        public void doAction(Context context)
        {
            Console.WriteLine("Player is in stop state");
            context.setState(this);
        }
        public override string ToString()
        {
            return "Stop State";
        }
    }
}
