using System;
using System.Collections.Generic;

namespace TransferObject_Pattern
{
    /// <summary>
    /// 传输对象模式
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // 用于从客户端向服务器一次性传递带有多个属性的数据。传输对象也被称为数值对象。传输对象是一个具有 getter/setter 方法的简单的 POJO 类，它是可序列化的，所以它可以通过网络传输。它没有任何的行为。服务器端的业务类通常从数据库读取数据，然后填充 POJO，并把它发送到客户端或按值传递它。对于客户端，传输对象是只读的。客户端可以创建自己的传输对象，并把它传递给服务器，以便一次性更新数据库中的数值.

            StudentBO studentBusinessObject = new StudentBO();

            //输出所有的学生
            foreach (StudentVO student1 in studentBusinessObject.getAllStudents())
            {
                Console.WriteLine("Student: [RollNo : " + student1.getRollNo() + ", Name : " + student1.getName() + " ]");
            }

            //更新学生
            StudentVO student = studentBusinessObject.getAllStudents()[0];
            student.setName("Michael");
            studentBusinessObject.updateStudent(student);

            //获取学生
            studentBusinessObject.getStudent(0);
            Console.WriteLine("Student: [RollNo : "
            + student.getRollNo() + ", Name : " + student.getName() + " ]");

            Console.ReadLine();
        }
    }

    /// <summary>
    /// 数据实体类
    /// </summary>
    public class StudentVO
    {
        private String name;
        private int rollNo;

        public StudentVO(String name, int rollNo)
        {
            this.name = name;
            this.rollNo = rollNo;
        }

        public String getName()
        {
            return name;
        }

        public void setName(String name)
        {
            this.name = name;
        }

        public int getRollNo()
        {
            return rollNo;
        }

        public void setRollNo(int rollNo)
        {
            this.rollNo = rollNo;
        }
    }
    /// <summary>
    /// 数据访问者
    /// </summary>
    public class StudentBO
    {
        //列表是当作一个数据库
        List<StudentVO> students;

        public StudentBO()
        {
            students = new List<StudentVO>();
            StudentVO student1 = new StudentVO("Robert", 0);
            StudentVO student2 = new StudentVO("John", 1);
            students.Add(student1);
            students.Add(student2);
        }
        public void deleteStudent(StudentVO student)
        {
            students.Remove(student);
            Console.WriteLine("Student: Roll No "
            + student.getRollNo() + ", deleted from database");
        }

        //从数据库中检索学生名单
        public List<StudentVO> getAllStudents()
        {
            return students;
        }

        public StudentVO getStudent(int rollNo)
        {
            return students[rollNo];
        }

        public void updateStudent(StudentVO student)
        {
            students[student.getRollNo()].setName(student.getName());
            Console.WriteLine("Student: Roll No " + student.getRollNo() + ", updated in the database");
        }
    }
}
