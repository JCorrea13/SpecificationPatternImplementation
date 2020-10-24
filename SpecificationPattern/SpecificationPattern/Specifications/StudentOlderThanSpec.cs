using DAL.Models;
using SpecificationLib;
using System;
using System.Linq.Expressions;

namespace SpecificationPattern.Specifications
{
    public class StudentOlderThanSpec : Specification<Student>
    {
        private readonly int _age;

        public StudentOlderThanSpec(int age) => _age = age;

        public override Expression<Func<Student, bool>> BuildExpression() =>
            x => x.Age > _age;
    }
}
