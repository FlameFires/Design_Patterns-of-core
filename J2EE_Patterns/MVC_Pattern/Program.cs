using System;

namespace MVC_Pattern
{
    /// <summary>
    /// MVC 模式
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //从数据库获取学生记录
            Student model = retrieveStudentFromDatabase();

            //创建一个视图：把学生详细信息输出到控制台
            StudentView view = new StudentView();

            // 其实就是将视图和实体交给Controller处理
            StudentController controller = new StudentController(model, view);

            controller.updateView();

            //更新模型数据
            controller.setStudentName("John");

            controller.updateView();

            Console.ReadLine();
        }

        private static Student retrieveStudentFromDatabase()
        {
            Student student = new Student();
            student.setName("Robert");
            student.setRollNo("10");
            return student;
        }
    }

    public class Student
    {
        private String rollNo;
        private String name;
        public String getRollNo()
        {
            return rollNo;
        }
        public void setRollNo(String rollNo)
        {
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
    }

    public class StudentView
    {
        public void printStudentDetails(String studentName, String studentRollNo)
        {
            Console.WriteLine("Student: ");
            Console.WriteLine("Name: " + studentName);
            Console.WriteLine("Roll No: " + studentRollNo);
        }
    }
    public class StudentController
    {
        private Student model;
        private StudentView view;

        public StudentController(Student model, StudentView view)
        {
            this.model = model;
            this.view = view;
        }

        public void setStudentName(String name)
        {
            model.setName(name);
        }

        public String getStudentName()
        {
            return model.getName();
        }

        public void setStudentRollNo(String rollNo)
        {
            model.setRollNo(rollNo);
        }

        public String getStudentRollNo()
        {
            return model.getRollNo();
        }

        public void updateView()
        {
            view.printStudentDetails(model.getName(), model.getRollNo());
        }
    }
}
