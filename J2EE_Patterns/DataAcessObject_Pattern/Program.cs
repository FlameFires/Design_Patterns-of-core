using System;
using System.Collections.Generic;

namespace DataAcessObject_Pattern
{
    /// <summary>
    /// 数据访问对象模式
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            IStudentDao studentDao = new StudentDaoImpl();

            //输出所有的学生
            foreach (Student student1 in studentDao.getAllStudents())
            {
                Console.WriteLine("Student: [RollNo : " + student1.getRollNo() + ", Name : " + student1.getName() + " ]");
            }


            //更新学生
            Student student = studentDao.getAllStudents()[0];
            student.setName("Michael");
            studentDao.updateStudent(student);

            //获取学生
            studentDao.getStudent(0);
            Console.WriteLine("Student: [RollNo : " + student.getRollNo() + ", Name : " + student.getName() + " ]");

            Console.ReadLine();
        }
    }

    /// <summary>
    /// 学生实体类
    /// </summary>
    public class Student
    {
        private String name;
        private int rollNo;

        public Student(String name, int rollNo)
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
    /// 学生数据访问接口
    /// </summary>
    public interface IStudentDao
    {
        public List<Student> getAllStudents();
        public Student getStudent(int rollNo);
        public void updateStudent(Student student);
        public void deleteStudent(Student student);
    }
    /// <summary>
    /// 服务实现类
    /// </summary>
    public class StudentDaoImpl : IStudentDao
    {
        //列表是当作一个数据库
        List<Student> students;
        public StudentDaoImpl()
        {
            students = new List<Student>();
            Student student1 = new Student("Robert", 0);
            Student student2 = new Student("John", 1);
            students.Add(student1);
            students.Add(student2);
        }
        public void deleteStudent(Student student)
        {
            students.Remove(student);
            Console.WriteLine("Student: Roll No " + student.getRollNo()
               + ", deleted from database");
        }
        //从数据库中检索学生名单    
        public List<Student> getAllStudents()
        {
            return students;
        }
        public Student getStudent(int rollNo)
        {
            return students[rollNo];
        }
        public void updateStudent(Student student)
        {
            students[student.getRollNo()].setName(student.getName());
            Console.WriteLine("Student: Roll No " + student.getRollNo()
               + ", updated in the database");
        }
    }
}
