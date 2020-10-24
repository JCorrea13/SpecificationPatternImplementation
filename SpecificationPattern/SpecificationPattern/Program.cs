using DAL;
using DAL.Models;
using SpecificationPattern.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SpecificationPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var students = new List<Student>
            {
                new Student { StudentId = 1, Name = "Juan", Age = 23, Gender = Genders.Male },
                new Student { StudentId = 2, Name = "Pedro", Age = 22, Gender = Genders.Unknown },
                new Student { StudentId = 3, Name = "Maria", Age = 20, Gender = Genders.Female },
                new Student { StudentId = 4, Name = "Karina", Age = 20, Gender = Genders.Female },
            };

            students.Print("All Students");

            NormalVersion(students);
            ExrepssionVersion(students);
            SpecificationVersion(students);
            SpecificationWithDatabaseVersion();
            AndExaple();

            Console.ReadKey();
        }

        private static void NormalVersion(List<Student> students)
        {
            var woman = students.Where(x => x.Gender == Genders.Female);
            woman.Print("Woman Normal Version");
        }

        private static void ExrepssionVersion(IEnumerable<Student> students)
        {
            Expression<Func<Student, bool>> expression = x => x.Gender == Genders.Female;
            var woman = students.Where(expression.Compile());

            woman.Print("Woman Expresion Version");
        }
        private static void SpecificationVersion(IEnumerable<Student> students)
        {
            var woman = students.Where(new StudentByGenderSpec(Genders.Female).Compile());
            woman.Print("Woman Specification Version");
        }

        private static void SpecificationWithDatabaseVersion()
        {
            using var dbContext = new SchoolContext();
            var woman = dbContext.Students.Where(new StudentByGenderSpec(Genders.Female).Compile()).ToList();
            
            woman.Print("Woman Specification/Database Version");
        }

        private static void AndExaple()
        {
            using var dbContext = new SchoolContext();
            var andResult = dbContext.Students.Where(
                            new StudentByGenderSpec(Genders.Female, Genders.Unknown)
                            .And(new StudentOlderThanSpec(21)).Compile()).ToList();

            var orResult = dbContext.Students.Where(
                            new StudentByGenderSpec(Genders.Unknown)
                            .Or(new StudentOlderThanSpec(21)).Compile()).ToList();

            var notResult = dbContext.Students.Where(
                            new StudentByGenderSpec(Genders.Female, Genders.Unknown)
                            .Not()
                            .Compile()).ToList();

            andResult.Print("And Example");
            orResult.Print("Or Example");
            notResult.Print("Not Example");
        }
    }
}
