


using System.Text;
using System.Xml.Serialization;

namespace ConsoleApp8
{
    class Program
    {
        
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            StudentsManager students = new StudentsManager();
            //students.addStudent(new Student(1, "Bùi Quang Tuấn", 1, 9.0));
            //students.addStudent(new Student(2, "Bùi Quang A", 2, 8.0));
            //students.addStudent(new Student(3, "Bùi Quang B", 2, 8.0));
            //students.addStudent(new Student(4, "Bùi Quang C", 3, 8.0));
            //students.addStudent(new Student(5, "Bùi Quang D", 3, 8.0));
            //students.addStudent(new Student(6, "Bùi Quang E", 1, 8.0));
            //students.addStudent(new Student(7, "Bùi Quang F", 4, 7.0));
            //students.addClass(new Class(1, "22T_NHAT1", "CNTT"));
            //students.addClass(new Class(2, "22T_NHAT2", "CNTT"));
            //students.addClass(new Class(3, "22T_TDH1", "Điện"));
            //students.addClass(new Class(4, "22T_TDH2", "Điện"));
            //students.addClass(new Class(5, "22T_QLDA", "QLDA"));
            students.readStudents();
            students.readClasses();
            //students.addStudent();
            //students.addClass();
            students.ouputStudent();
            students.outputClasses();
            students.showStudent();
            students.tenPecentStudent();
            
        }
        
        //public void showStudents()
        //{
        //    for
        //}
    }
}