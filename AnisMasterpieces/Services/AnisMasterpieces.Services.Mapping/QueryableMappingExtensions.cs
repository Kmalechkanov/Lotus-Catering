namespace AnisMasterpieces.Services.Mapping
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using AutoMapper.QueryableExtensions;

    public static class QueryableMappingExtensions
    {
        public static IQueryable<TDestination> To<TDestination>(
            this IQueryable source,
            params Expression<Func<TDestination, object>>[] membersToExpand)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return source.ProjectTo(AutoMapperConfig.MapperInstance.ConfigurationProvider, null, membersToExpand);
        }

        public static IQueryable<TDestination> To<TDestination>(
            this IQueryable source,
            object parameters)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return source.ProjectTo<TDestination>(AutoMapperConfig.MapperInstance.ConfigurationProvider, parameters);
        }

        public static T CastTo<T>(this object value)
        {
            var destinationType = typeof(T);

            var result = default(T);

            var underlyingType = Nullable.GetUnderlyingType(destinationType) ?? destinationType;

            try
            {
                if (underlyingType == typeof(Guid))
                {
                    if (value is string)
                    {
                        value = new Guid(value as string);
                    }

                    if (value is byte[])
                    {
                        value = new Guid(value as byte[]);
                    }

                    return result = (T)Convert.ChangeType(value, underlyingType);
                }

                return result = (T)Convert.ChangeType(value, underlyingType);
            }
            catch (Exception ex)
            {
                var traceMessage = ex is InvalidCastException || ex is FormatException || ex is OverflowException
                                        ? string.Format("The given value {0} could not be cast as Type {1}.", value, underlyingType.FullName)
                                        : ex.Message;

                result = default(T);
                return result;
            }
        }
    }
}
