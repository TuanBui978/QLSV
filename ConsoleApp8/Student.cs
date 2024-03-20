using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    [Serializable]
    public class Student
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public int Class_Id {  get; set; }
        public double Aos { get; set; }

        public Student() { }
        public Student(int id, string name, int class_Id, double aos)
        {
            Id = id;
            Name = name;
            Class_Id = class_Id;
            Aos = aos;
        }
    }
}
