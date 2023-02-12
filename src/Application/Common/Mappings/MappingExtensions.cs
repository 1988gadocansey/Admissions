using AutoMapper;
using AutoMapper.QueryableExtensions;
using OnlineApplicationSystem.Application.Common.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace OnlineApplicationSystem.Application.Common.Mappings;

public static class MappingExtensions
{
    public static Task<PaginatedList<TDestination>> PaginatedListAsync<TDestination>(this IQueryable<TDestination> queryable, int pageNumber, int pageSize) where TDestination : class
        => PaginatedList<TDestination>.CreateAsync(queryable.AsNoTracking(), pageNumber, pageSize);

    public static Task<List<TDestination>> ProjectToListAsync<TDestination>(this IQueryable queryable, IConfigurationProvider configuration) where TDestination : class
        => queryable.ProjectTo<TDestination>(configuration).AsNoTracking().ToListAsync();

    /// <summary>
    /// Sets mapping from source property to destination property. Convenient extension method. 
    /// </summary>
    public static IMappingExpression<TSource, TDestination> MapProperty<TSource, TDestination, TProperty>(
        this IMappingExpression<TSource, TDestination> map,
        Expression<Func<TSource, TProperty>> sourceMember,
        Expression<Func<TDestination, object>> targetMember)
    {
        map.ForMember(targetMember, opt => opt.MapFrom(sourceMember));

        return map;
    }
    public static async Task<TDest> ProjectToObjAsync<TDest>(this IQueryable source, IMapper mapper, TDest obj, CancellationToken cancellationToken = default)
    {
        var loadedObj = await source.ProjectTo<TDest>(mapper.ConfigurationProvider).FirstOrDefaultAsync(cancellationToken);

        if (loadedObj != null)
        {
            mapper.Map(loadedObj, obj);
        }

        return obj;
    }

}
