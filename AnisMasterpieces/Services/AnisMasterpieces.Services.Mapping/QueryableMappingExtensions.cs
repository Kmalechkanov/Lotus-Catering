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

        public static TDestination То<TDestination>(this object value)
        {
            var instance = Activator.CreateInstance<TDestination>();
            var properties = instance.GetType().GetProperties();

            foreach (var property in properties)
            {
                var valueNames = value.GetType().GetProperties().Select(p => p.Name).ToArray();
                try
                {
                    if (valueNames.Contains(property.Name))
                    {
                        property.SetValue(instance, value.GetType().GetProperty(property.Name).GetValue(value, null), null);
                    }
                }
                catch
                {
                    property.SetValue(instance, value.GetType().GetProperty(property.Name).GetValue(value, null).ToString(), null);
                }
            }

            return instance;
        }
    }
}
