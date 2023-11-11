using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Prakt5
{
    public class Person : IComparable
    {
        int age;
        string name;
        double weight;
        public Person()
        {
            this.name = "Петро";
            var r = new Random();
            this.age = r.Next(10, 300);
            this.weight = r.Next(30, 300);
        }
        public Person(string name, int age, double weight)
        {
            this.age = age;
            this.name = name;
            this.weight = weight;
        }
        public string Name { get { return this.name; } set { this.name = value; } }
        public int Age
        {
            get { return this.age; }
            set
            {
                if (value > 0)
                    this.age = value;
                else throw new Exception("Age<=0");
            }
        }
        public double Weight
        {
            get { return this.weight; }
            set
            {
                if (value > 0)
                    this.weight = value;
                else throw new Exception("Weight<=0");
            }
        }
        public int CompareTo(object obj)
        {
            Person p = obj as Person;
            return weight.CompareTo(p.weight);
        }
    }
}
