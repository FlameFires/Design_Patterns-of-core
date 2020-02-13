using System;
using System.Collections.Generic;

namespace Filter.Criteria_Pattern
{
    /// <summary>
    /// 过滤器模式
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {

            // 过滤器模式（Filter Pattern）或标准模式（Criteria Pattern）是一种设计模式，这种模式允许开发人员使用不同的标准来过滤一组对象，通过逻辑运算以解耦的方式把它们连接起来。这种类型的设计模式属于结构型模式，它结合多个标准来获得单一标准。
            // 设计一个过滤器接口，其他过滤继承实现筛选并返回所对应的值
            List<Person> persons = new List<Person>();

            persons.Add(new Person("Robert", "Male", "Single"));
            persons.Add(new Person("John", "Male", "Married"));
            persons.Add(new Person("Laura", "Female", "Married"));
            persons.Add(new Person("Diana", "Female", "Single"));
            persons.Add(new Person("Mike", "Male", "Single"));
            persons.Add(new Person("Bobby", "Male", "Single"));

            ICriteria male = new CriteriaMale();
            ICriteria female = new CriteriaFemale();
            ICriteria single = new CriteriaSingle();
            ICriteria singleMale = new AndCriteria(single, male);
            ICriteria singleOrFemale = new OrCriteria(single, female);

            Console.WriteLine("Males: ");
            printPersons(male.meetCriteria(persons));

            Console.WriteLine("\nFemales: ");
            printPersons(female.meetCriteria(persons));

            Console.WriteLine("\nSingle Males: ");
            printPersons(singleMale.meetCriteria(persons));

            Console.WriteLine("\nSingle Or Females: ");
            printPersons(singleOrFemale.meetCriteria(persons));

            Console.ReadLine();
        }

        public static void printPersons(IList<Person> persons)
        {
            foreach (Person person in persons)
            {
                Console.WriteLine("Person : [ Name : " + person.getName()
                   + ", Gender : " + person.getGender()
                   + ", Marital Status : " + person.getMaritalStatus()
                   + " ]");
            }
        }
    }

    public class Person
    {

        private String name;
        private String gender;
        private String maritalStatus;

        public Person(String name, String gender, String maritalStatus)
        {
            this.name = name;
            this.gender = gender;
            this.maritalStatus = maritalStatus;
        }

        public String getName()
        {
            return name;
        }
        public String getGender()
        {
            return gender;
        }
        public String getMaritalStatus()
        {
            return maritalStatus;
        }
    }

    public interface ICriteria
    {
        public IList<Person> meetCriteria(List<Person> persons);
    }
    /// <summary>
    /// 男士标准
    /// </summary>
    public class CriteriaMale : ICriteria
    {
        public IList<Person> meetCriteria(List<Person> persons)
        {
            List<Person> malePersons = new List<Person>();
            foreach(Person person in persons)
            {
                if (person.getGender().Equals("MALE"))
                {
                    malePersons.Add(person);
                }
            }
            return malePersons;
        }
    }
    /// <summary>
    /// 女生标准
    /// </summary>
    public class CriteriaFemale : ICriteria
    {
        public IList<Person> meetCriteria(List<Person> persons)
        {
            List<Person> femalePersons = new List<Person>();
            foreach (Person person in persons) // 如果是女生
            {
                if (person.getGender().Equals("FEMALE"))
                {
                    femalePersons.Add(person);
                }
            }
            return femalePersons;
        }
    }
    public class CriteriaSingle : ICriteria
    {
        public IList<Person> meetCriteria(List<Person> persons)
        {
            List<Person> singlePersons = new List<Person>();
            foreach (Person person in persons)
            {
                if (person.getMaritalStatus().Equals("SINGLE"))
                {
                    singlePersons.Add(person);
                }
            }
            return singlePersons;
        }
    }
    public class AndCriteria : ICriteria
    {
        private ICriteria criteria;
        private ICriteria otherCriteria;

        public AndCriteria(ICriteria criteria, ICriteria otherCriteria)
        {
            this.criteria = criteria;
            this.otherCriteria = otherCriteria;
        }
        public IList<Person> meetCriteria(List<Person> persons)
        {
            List<Person> firstCriteriaPersons = criteria.meetCriteria(persons) as List<Person>;
            return otherCriteria.meetCriteria(firstCriteriaPersons);
        }
    }
    public class OrCriteria : ICriteria
    {
        private ICriteria criteria;
        private ICriteria otherCriteria;

        public OrCriteria(ICriteria criteria, ICriteria otherCriteria)
        {
            this.criteria = criteria;
            this.otherCriteria = otherCriteria;
        }
        public IList<Person> meetCriteria(List<Person> persons)
        {
            IList<Person> firstCriteriaItems = criteria.meetCriteria(persons);
            IList<Person> otherCriteriaItems = otherCriteria.meetCriteria(persons);

            foreach (Person person in otherCriteriaItems)
            {
                if (!firstCriteriaItems.Contains(person))
                {
                    firstCriteriaItems.Add(person);
                }
            }
            return firstCriteriaItems;
        }
    }
}
