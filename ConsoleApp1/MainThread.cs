using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class MainThread
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Student manager app");
            while (true)
            {
                Console.WriteLine("1. Add student");
                Console.WriteLine("2. Delete student");
                Console.WriteLine("3. Update student");
                Console.WriteLine("4. Print student list");
                Console.WriteLine("5. EXIT");
                Console.WriteLine("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddStudent();
                        break;
                    case 2:
                        DeleteStudent();
                        break;
                    case 3:
                        UpdateStudent();
                        break;
                    case 4:
                        PrintStudentList();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Wrong choice!");
                        break;
                }
            }
        }

        static List<Student> students = new List<Student>();
        static void AddStudent()
        {
            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your roll number: ");
            string rollNumber = Console.ReadLine();
            Student student = new Student(rollNumber, name);
            Model model = new Model();
            List<Student> students = model.GetAllStudent();
            for(int i = 0; i < students.Count(); i++){

            }
            model.Insert(student);
        }

        static void DeleteStudent()
        {
            PrintStudentList();
            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your roll number: ");
            string rollNumber = Console.ReadLine();
            Student student = new Student(rollNumber, name);
            Model model = new Model();
            model.Insert(student);
        }

        static void UpdateStudent()
        {

        }

        static void PrintStudentList()
        {
            Model model = new Model();
            List<Student> students = model.GetAllStudent();
            students.ForEach(s => Console.WriteLine(s));
        }
    }
}
