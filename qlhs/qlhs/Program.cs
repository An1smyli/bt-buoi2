using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace qlhs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> dshs = new List<Student>
            {
                new Student(1, "A", 15),
                new Student(2, "B", 16),
                new Student(5, "C", 14),
                new Student(3, "D", 14),
                new Student(4, "E", 17),
            };

            //a
            var dsfull = from hs in dshs
                       select hs;
            Console.WriteLine("Danh sach full");
            foreach (Student hs in dsfull)
            {
                Console.WriteLine($"ID: {hs.Id}, Name: {hs.Name}, Age: {hs.Age}");
            }

            //b
            var dsAge = from hs in dshs 
                        where hs.Age > 14 && hs.Age < 19
                        select hs;
            Console.WriteLine(">15 <18");
            foreach (Student hs in dsAge)
            {
                Console.WriteLine($"ID: {hs.Id}, Name: {hs.Name}, Age: {hs.Age}");
            }

            //c
            var nameA = from hs in dshs
                        where hs.Name.StartsWith("A")
                        select hs;

            foreach (Student hs in nameA)
            {
                Console.WriteLine($"ID: {hs.Id}, Name: {hs.Name}, Age: {hs.Age}");
            }

            //d
            int totalAge = dshs.Sum(hs => hs.Age);

            Console.WriteLine($"Tong so tuoi: {totalAge}");

            //e
            Student oldest = dshs.OrderByDescending(hs => hs.Age).FirstOrDefault();

            Console.WriteLine($"Lon tuoi nhat: {oldest.Id}, {oldest.Name}, Tuoi: {oldest.Age}");

            //f
            var sortDs = dshs.OrderBy(hs => hs.Age);
            Console.WriteLine("Sap xep");
            foreach (var hs in sortDs)
            {
                Console.WriteLine($"ID: {hs.Id}, Name: {hs.Name}, Age: {hs.Age}");
            }
        }
    }
}