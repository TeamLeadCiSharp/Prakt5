using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Prakt5
{
    public class Student : IComparable
    {
        string fullName;
        int course;
        string group;
        double runningResult;

        public Student()
        {
            this.fullName = "Іванов Іван Іванович";
            var r = new Random();
            this.course = r.Next(1, 6);
            this.group = "Група " + r.Next(1, 10);
            this.runningResult = r.NextDouble() * 100; 
        }

        public Student(string fullName, int course, string group, double runningResult)
        {
            this.fullName = fullName;
            this.course = course;
            this.group = group;
            this.runningResult = runningResult;
        }

        public string FullName { get { return this.fullName; } set { this.fullName = value; } }

        public int Course
        {
            get { return this.course; }
            set
            {
                if (value > 0 && value <= 6)
                    this.course = value;
                else throw new Exception("Invalid course");
            }
        }

        public string Group { get { return this.group; } set { this.group = value; } }

        public double RunningResult
        {
            get { return this.runningResult; }
            set
            {
                if (value >= 0)
                    this.runningResult = value;
                else throw new Exception("Invalid running result");
            }
        }

        public int CompareTo(object obj)
        {
            Student s = obj as Student;
            return runningResult.CompareTo(s.runningResult);
        }
    }
}
