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
        public string FullName { get; set; }
        public int Course { get; set; }
        public string Group { get; set; }
        public double RunningResult { get; set; }

        public Student()
        {
            this.FullName = "Петро";
            var r = new Random();
            this.Group = "IP-22";
            this.RunningResult = r.Next(30, 300);
        }

        public Student(string fullName, int course, string group, double runningResult)
        {
            FullName = fullName;
            Course = course;
            Group = group;
            RunningResult = runningResult;
        }

        public int CompareTo(object obj)
        {
            Student otherStudent = obj as Student;
            return RunningResult.CompareTo(otherStudent.RunningResult);
        }
    }
}
