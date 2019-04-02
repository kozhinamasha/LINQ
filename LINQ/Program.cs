using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    public class Program
    {
        static void Main(string[] args)
        {
            WorkWithLists();
            Console.ReadKey();
        }

        public static void WorkWithLists()
        {
            List<Student> students = new List<Student>()
            {
                new Student
                {
                    Name = "Tom",
                    Age = 12,
                    Addresses = new Address() {Country = "UK", City = "London"},
                    HomeAddresses = new List<HomeAddress>(){new HomeAddress(){Street = "Street1", Building = 11,}, new HomeAddress(){Street = "Street2", Building = 15}}
                },
                new Student
                {
                    Name = "Masha",
                    Age = 15,
                    Addresses = new Address() {Country = "Italy", City = "Rome"}
                }
            };

            //Instead of this:
            //foreach (var student in students)
            //{
            //    Console.WriteLine($"The student name is: {student.Name}");
            //}

            var studentsList1 = from student in students
                                select student.Name;                   //query expression
            var studentsList2 = students.Select(x => x.Name);         // method based


            var studentsList4 = from student in students              //query expression
                                where student.Age == 12
                                select student.Name;
            var studentsList3 = students.Where(x => x.Age == 15).Select(x => x.Name); // method based

            foreach (var student in studentsList1)
            {
                Console.WriteLine(student);
            }

            var studentsDetails5 = from student in students
                                   where student.Age == 12
                                   select new
                                   {
                                       StudentName = student.Name,
                                       StudentAge = student.Age,
                                       StudentAddress = student.Addresses
                                   }; //new anonymous type

            foreach (var student in studentsDetails5)
            {
                Console.WriteLine(student.StudentAddress.Country);
            }


            //var studentsDetails6 = from student in students
            //                       from homeaddresses in student.HomeAddresses
            //                       where student.Age == 12
            //                       select new
            //                       {
            //                           StudentName = student.Name,
            //                           StudentAge = student.Age,
            //                           HomeAddresses = homeaddresses
            //                       }; //new anonymous type

            var studentsDetails7 = students.Where(x => x.Age == 12).SelectMany(x => x.HomeAddresses);

            foreach (var student in studentsDetails7)
            {
                Console.WriteLine(student.Street);
            }

            Console.ReadKey();
        }
    }

    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Address Addresses { get; set; }
        public List<HomeAddress> HomeAddresses { get; set; }
    }

    public class Address
    {
        public string Country { get; set; }
        public string City { get; set; }
    }

    public class HomeAddress
    {
        public string Street { get; set; }
        public int Building { get; set; }
    }
}
