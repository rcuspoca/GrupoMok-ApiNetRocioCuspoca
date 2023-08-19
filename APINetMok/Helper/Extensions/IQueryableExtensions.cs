using APINetMok.Dto;

namespace APINetMok.Helper.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, PaginacionDto paginacionDto)
        {
            return queryable
                .Skip((paginacionDto.Pagina - 1) * paginacionDto.RecordsPorPagina)
                .Take(paginacionDto.RecordsPorPagina);
        }
    }
}
