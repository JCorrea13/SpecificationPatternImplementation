using System;
using System.Linq.Expressions;

namespace SpecificationLib
{
    public class OrSpecification<T> : Specification<T>
    {
        private readonly Specification<T> _left;
        private readonly Specification<T> _right;

        public OrSpecification(Specification<T> left, Specification<T> right)
        {
            _right = right;
            _left = left;
        }

        public override Expression<Func<T, bool>> BuildExpression() =>
            x => _left.Compile()(x) || _right.Compile()(x);
    }
}
