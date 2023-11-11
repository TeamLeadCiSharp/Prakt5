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
        public List<Student> students = new List<Student>();
        XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));

        public void Add(Student student)
        {
            students.Add(student);
        }

        public void Remove(int i)
        {
            students.RemoveAt(i);
        }

        public void SortByRunningResult()
        {
            SortByRunningResult sortByRunningResult = new SortByRunningResult();
            students.Sort(sortByRunningResult);
        }

        public List<Student> GetTopThreeRunners()
        {
            SortByRunningResult();
            int topCount = Math.Min(3, students.Count);
            List<Student> topRunners = students.GetRange(0, topCount);

            return topRunners;
        }

        public void WriteFile(string fileName)
        {
            FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None);
            serializer.Serialize(fileStream, students);
            fileStream.Close();
        }

        public void ReadFile(string fileName)
        {
            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            students = serializer.Deserialize(fileStream) as List<Student>;
            fileStream.Close();
        }
    }
}
