using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Prakt5
{
    public class People
    {
        public List<Person> people = new List<Person>();
        XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));

        public void Add(Person person)
        {
            people.Add(person);
        }
        public void Remove(int i)
        {
            people.RemoveAt(i);
        }
        public void Sort()
        {
            SortByAge sortByAge = new SortByAge();
            people.Sort(sortByAge);
        }
        public void WriteFile(string fileName)
        {
            FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None);
            serializer.Serialize(fileStream, people);
            fileStream.Close();
        }
        public void ReadFile(string fileName)
        {
            FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None);
            people = serializer.Deserialize(fileStream) as List<Person>;
            fileStream.Close();
        }
    }
}
