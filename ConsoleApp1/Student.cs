using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Student
    {
        private int id;
        private string name;
        private string rollNumber;

        public Student(string rollNumber, string name)
        {
            this.rollNumber = rollNumber;
            this.name = name;
        }

        public Student() { }

        public override string ToString()
        {
            return base.ToString();
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string RollNumber { get => rollNumber; set => rollNumber = value; }
    }
}
