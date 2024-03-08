using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Core.Persistence.ModelBuilderExtensions;

public static class GlobalFilterExtensions
{
    public static ModelBuilder AddGlobalFilterWithExpression<TBaseEntity>(this ModelBuilder modelBuilder, Expression<Func<TBaseEntity, bool>> expression)
    {
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            if (entity.ClrType.IsAssignableTo(typeof(TBaseEntity)))
            {
                var parameter = Expression.Parameter(entity.ClrType);
                var body = ReplacingExpressionVisitor.Replace(expression.Parameters.First(), parameter, expression.Body);
                var lambdaExpression = Expression.Lambda(body, parameter);

                entity.SetQueryFilter(lambdaExpression);
            }
        }
        return modelBuilder;
    }
}
