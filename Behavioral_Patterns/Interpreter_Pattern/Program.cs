using System;

namespace Interpreter_Pattern
{
    /// <summary>
    /// 解释器模式
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //何时使用：如果一种特定类型的问题发生的频率足够高，那么可能就值得将该问题的各个实例表述为一个简单语言中的句子。这样就可以构建一个解释器，该解释器通过解释这些句子来解决该问题。

            // 即通过自定义的解释器来筛选出想要的数据
            IExpression isMale = getMaleExpression();
            IExpression isMarriedWoman = getMarriedWomanExpression();

            Console.WriteLine("John is male? " + isMale.interpret("John"));
            Console.WriteLine("Julie is a married women? "
            + isMarriedWoman.interpret("Married Julie"));

            Console.ReadKey();
        }
        //规则：Robert 和 John 是男性
        public static IExpression getMaleExpression()
        {
            IExpression robert = new TerminalExpression("Robert");
            IExpression john = new TerminalExpression("John");
            return new OrExpression(robert, john);
        }

        //规则：Julie 是一个已婚的女性
        public static IExpression getMarriedWomanExpression()
        {
            IExpression julie = new TerminalExpression("Julie");
            IExpression married = new TerminalExpression("Married");
            return new AndExpression(julie, married);
        }

    }

    public interface IExpression
    {
        public Boolean interpret(String context);
    }
    public class TerminalExpression : IExpression
    {
        private String data;
        public TerminalExpression(String data)
        {
            this.data = data;
        }
        public Boolean interpret(String context)
        {
            if (context.Contains(data))
            {
                return true;
            }
            return false;
        }
    }
    public class OrExpression : IExpression
    {
        private IExpression expr1 = null;
        private IExpression expr2 = null;

        public OrExpression(IExpression expr1, IExpression expr2)
        {
            this.expr1 = expr1;
            this.expr2 = expr2;
        }
        public Boolean interpret(String context)
        {
            return expr1.interpret(context) || expr2.interpret(context);
        }
    }
    public class AndExpression : IExpression
    {
        private IExpression expr1 = null;
        private IExpression expr2 = null;
        public AndExpression(IExpression expr1, IExpression expr2)
        {
            this.expr1 = expr1;
            this.expr2 = expr2;
        }
        public Boolean interpret(String context)
        {
            return expr1.interpret(context) && expr2.interpret(context);
        }
    }
}
