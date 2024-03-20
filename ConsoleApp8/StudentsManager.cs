using ConsoleApp8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApp8
{
    internal class StudentsManager
    {
        public List<Student> students;

        public List<Class> classes;
        public StudentsManager()
        {
            students = new List<Student>();
            classes = new List<Class>();
        }
        public void addStudent(Student student)
        {
            if (students == null)
            {
                students = new List<Student>();
                students.Add(student);
            }
            else
            {
                students.Add(student);
            }
        }
        public void addStudent()
        {
            int maxId = 0;
            foreach (Student student in students)
            {
                if (student.Id >= maxId) maxId = student.Id;
            }
            Console.WriteLine("Nhập Tên: ");
            String name = Console.ReadLine();
            Console.WriteLine("Nhập khoa: ");
            foreach (Class @class in classes)
            {
                    Console.WriteLine($"{@class.Id}. {@class.Name}");
            }
            int classId = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhập điểm trung bình: ");
            Double Aos = Double.Parse(Console.ReadLine());
            while (true) {
                try
                {
                    var query = from @class in classes where @class.Id == classId select @class;
                    if (query.Count() == 0) throw new Exception();
                    Student temp = new Student(maxId + 1, name, classId, Aos);
                    students.Add(temp);
                    return;

                }
                catch (Exception ex)
                {
                    Console.WriteLine("mày chọn sai mã lớp r.");
                }
            }
        }
        public void addClass()
        {
            int maxId = 0;
            foreach (Class @class in classes)
            {
                if (@class.Id >= maxId) maxId = @class.Id;
            }
            Console.WriteLine("Nhập Tên: ");
            String name = Console.ReadLine();
            Console.WriteLine("Nhập khoa: ");
            String faculty = Console.ReadLine();
            Class temp = new Class(maxId + 1, name, faculty);
            classes.Add(temp);
        }
        public void removeStudent(int Id)
        {
            if (students == null)
            {
                return;
            }
            else
            {
                foreach (Student student in students)
                {
                    if (student.Id == Id)
                    {
                        students.Remove(student);
                    }
                }

            }
        }
        public void addClass(Class _class)
        {
            if (classes == null)
            {
                classes = new List<Class>();
                classes.Add(_class);
            }
            else
            {
                classes.Add(_class);
            }
        }
        public void removeClass(int Id)
        {
            if (classes == null)
            {
                return;
            }
            else
            {
                foreach (Class _class in classes)
                {
                    if (_class.Id == Id)
                    {
                        classes.Remove(_class);
                    }
                }

            }
        }
        public void ouputStudent()
        {
            Stream stream = new FileStream("D:\\.NET 22.99\\ConsoleApp8\\ConsoleApp8\\Strudents.txt", FileMode.Truncate, FileAccess.ReadWrite);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Student>));
            xmlSerializer.Serialize(stream, students);
            stream.Close();
        }
        public void outputClasses()
        {
            Stream stream = new FileStream("D:\\.NET 22.99\\ConsoleApp8\\ConsoleApp8\\Classes.txt", FileMode.Truncate, FileAccess.ReadWrite);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Class>));
            xmlSerializer.Serialize(stream, classes);
            stream.Close();
        }
        public void showStudent()
        {
            var query = from student in students join _Class in classes on student.Class_Id equals _Class.Id 
                        select new {
                            Name = student.Name,
                            ClassName = _Class.Name,
                            Faculty = _Class.Faculty,
                            Aos = student.Aos,
                        };

            foreach (var student in query)
            {
                Console.WriteLine($"Tên: {student.Name}, Lớp: {student.ClassName}, Khoa: {student.Faculty}, Điểm trung bình: {student.Aos}");
            }
        }
        public void tenPecentStudent()
        {
            foreach (Class _class in classes)
            {
                double tenPecent = Math.Ceiling(Convert.ToDouble((double)students.Count() / 10));

                var topTen = (from student in students
                              join _Class in classes on student.Class_Id equals _Class.Id
                              where student.Aos >= 8.0 && _Class.Id == _class.Id
                              orderby student.Aos descending
                              select new
                              {
                                  Name = student.Name,
                                  ClassName = _Class.Name,
                                  Faculty = _Class.Faculty,
                                  Aos = student.Aos,
                              }).Take((int)tenPecent);
                if (topTen.Count() == 0) { 
                    continue;
                }
                double minInTopTen = topTen.Min(p => p.Aos);

                var query = from student in students
                            join _Class in classes on student.Class_Id equals _Class.Id
                            where student.Aos >= minInTopTen && _Class.Id == _class.Id
                            orderby student.Aos descending
                            select new
                            {
                                Name = student.Name,
                                ClassName = _Class.Name,
                                Faculty = _Class.Faculty,
                                Aos = student.Aos,
                            };
                foreach (var student in query)
                {
                    Console.WriteLine($"{ student.ClassName}: ");
                    Console.WriteLine($"Tên: {student.Name}, Lớp: {student.ClassName}, Khoa: {student.Faculty}, Điểm trung bình: {student.Aos}");
                }
            }


            
        }
        public void readClasses()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Class>));
            var myFileStream = new FileStream("D:\\.NET 22.99\\ConsoleApp8\\ConsoleApp8\\Classes.txt", FileMode.Open);
            var myObject = (List<Class>)xmlSerializer.Deserialize(myFileStream);
            this.classes = myObject;
            myFileStream.Close();
        }
        public void readStudents()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof (List<Student>));
            var myFileStream = new FileStream("D:\\.NET 22.99\\ConsoleApp8\\ConsoleApp8\\Strudents.txt", FileMode.Open, FileAccess.Read);
            var myObject = (List<Student>)xmlSerializer.Deserialize(myFileStream);
            this.students = myObject;
            myFileStream.Close();
        }
    }

}
