using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SpecificationLib
{
    public abstract class Specification<T>
    {
        public abstract Expression<Func<T, bool>> BuildExpression();

        public Func<T, bool> Compile()
        {
            Expression<Func<T, bool>> expression = BuildExpression();
            return expression.Compile();
        }

        public Specification<T> And(Specification<T> right) =>
            new AndSpecification<T>(this, right);

        public Specification<T> Or(Specification<T> right) =>
            new OrSpecification<T>(this, right);

        public Specification<T> Not() =>
            new NotSpecification<T>(this);
    }
}
