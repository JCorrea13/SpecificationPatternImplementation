using System;
using System.Linq.Expressions;

namespace SpecificationLib
{
    public class NotSpecification<T> : Specification<T>
    {
        private readonly Specification<T> _spec;

        public NotSpecification(Specification<T> spec) => _spec = spec;

        public override Expression<Func<T, bool>> BuildExpression() =>
            x => !_spec.Compile()(x);
    }
}
