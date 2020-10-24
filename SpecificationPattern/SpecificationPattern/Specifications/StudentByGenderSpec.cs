using DAL;
using DAL.Models;
using SpecificationLib;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace SpecificationPattern.Specifications
{
    public class StudentByGenderSpec : Specification<Student>
    {
        private readonly Genders[] _genders;

        public StudentByGenderSpec(params Genders[] genders) => _genders = genders;

        public override Expression<Func<Student, bool>> BuildExpression() =>
            x => _genders.Contains(x.Gender);
    }
}
