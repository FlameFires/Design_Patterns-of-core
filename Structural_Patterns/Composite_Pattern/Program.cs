using System;
using System.Collections.Generic;

namespace Composite_Pattern
{
    /// <summary>
    /// 组合模式 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // 何时使用： 1、您想表示对象的部分-整体层次结构（树形结构）。 2、您希望用户忽略组合对象与单个对象的不同，用户将统一地使用组合结构中的所有对象。
            Employee CEO = new Employee("John", "CEO", 30000);

            Employee headSales = new Employee("Robert", "Head Sales", 20000);

            Employee headMarketing = new Employee("Michel", "Head Marketing", 20000);

            Employee clerk1 = new Employee("Laura", "Marketing", 10000);
            Employee clerk2 = new Employee("Bob", "Marketing", 10000);

            Employee salesExecutive1 = new Employee("Richard", "Sales", 10000);
            Employee salesExecutive2 = new Employee("Rob", "Sales", 10000);

            // 添加进CEO名下
            CEO.add(headSales);
            CEO.add(headMarketing);

            // 销售经理门下添加
            headSales.add(salesExecutive1);
            headSales.add(salesExecutive2);

            // 营销员添加
            headMarketing.add(clerk1);
            headMarketing.add(clerk2);

            Console.WriteLine(CEO);
            foreach (var headEmployee in CEO.getSubordinates())
            {
                Console.WriteLine(headEmployee);
                foreach (var employee in headEmployee.getSubordinates())
                {
                    Console.WriteLine(employee);
                }
            }

            Console.ReadLine();
        }
    }

    /// <summary>
    /// 雇员
    /// </summary>
    public class Employee
    {
        private String name;
        private String dept;
        private int salary;
        private List<Employee> subordinates;

        //构造函数
        public Employee(String name, String dept, int sal)
        {
            this.name = name;
            this.dept = dept;
            this.salary = sal;
            subordinates = new List<Employee>();
        }

        public void add(Employee e)
        {
            subordinates.Add(e);
        }

        public void remove(Employee e)
        {
            subordinates.Remove(e);
        }

        public List<Employee> getSubordinates()
        {
            return subordinates;
        }

        public override String ToString()
        {
            return ("Employee :[ Name : " + name
            + ", dept : " + dept + ", salary :"
            + salary + " ]");
        }
    }
}
