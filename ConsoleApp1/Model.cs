using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Model
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        public Model()
        {
            Initialize();
        }



        //Initialize values
        private void Initialize()
        {
            server = "localhost";
            database = "mydata_demo";
            uid = "root";
            password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid user name and/or password");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public void Insert(Student student)
        {
            string query = String.Format("INSERT INTO students (name, rollNumber) VALUES('{0}', '{0}')", student.Name, student.RollNumber);

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        public void Delete(Student student)
        {
            string query = String.Format("DELETE FROM students WHERE rollNumber = '{0}'", student.RollNumber);

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        public void Update(Student OldStudent, Student NewStudent)
        {
            string query = String.Format("UPDATE students SET name = \"{0}\" WHERE rollnumber = \"{0}\"", NewStudent.Name, OldStudent.RollNumber);

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        public List<Student> GetAllStudent()
        {
            List<Student> students = new List<Student>();
            string query = "SELECT name, rollNumber FROM students";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.NextResult())
                {
                    String rollNumber = reader.GetString("rollNumber");
                    String name = reader.GetString("name");
                    Student student = new Student(rollNumber, name);
                    students.Add(student);
                }
                //close connection
                this.CloseConnection();
            }
            return students;
        }

        public Student GetAStudent(string rollNumber)
        {
            Student student = new Student();
            string query = string.Format("SELECT name, rollNumber FROM students WHERE rollNumber = \"{0}\"", rollNumber);

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                MySqlDataReader reader = cmd.ExecuteReader();
                String name = reader.GetString("name");
                student = new Student(rollNumber, name);
                //close connection
                this.CloseConnection();
            }
            return student;
        }
    }
}
