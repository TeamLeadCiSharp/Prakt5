using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Prakt5
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;

    public class Students
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

        public void Sort()
        {
            SortByRunningResult sortByRunningResult = new SortByRunningResult();
            students.Sort(sortByRunningResult);
        }

        public void WriteFile(string fileName)
        {
            using (FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                serializer.Serialize(fileStream, students);
            }
        }

        public void ReadFile(string fileName)
        {
            using (FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                students = serializer.Deserialize(fileStream) as List<Student>;
            }
        }

        public List<Student> GetTopPerformers()
        {
            Sort();
            return students.GetRange(0, Math.Min(3, students.Count));
        }
    }
}
